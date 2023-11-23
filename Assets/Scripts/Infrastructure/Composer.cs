using System.Collections.Generic;
using UnityEngine;

public class Composer : MonoBehaviour
{
    [SerializeField] private Ui _uiPrefab;
    [SerializeField] private List<ObstacleView> _obstaclesPrefabs;
    [SerializeField] private FinishView _finishViewPrefab;
    
    [SerializeField] private StorageConfig _storageConfig;
    [SerializeField] private SphereConfig _sphereConfig;
    [SerializeField] private int _startSpheresCapacity;
    [SerializeField] private MapConfig _mapConfig;
    
    [SerializeField] private SphereView _reservePrefab;
    [SerializeField] private HittingSphereView _hittingSpherePrefab;

    [SerializeField] private Transform _startPointer;
    [SerializeField] private Transform _finishPointer;


    private EventBinder _eventBinder;
    
    private void Awake()
    {
        LifeCirce lifeCirce = new LifeCirce();
        GlobalStateMachine stateMachine = new GlobalStateMachine();
        InputSystem input = new InputSystem();
        Updater updater = gameObject.AddComponent<Updater>();

        ObstaclesFactory obstaclesFactory = new ObstaclesFactory(_obstaclesPrefabs, new GameObject("Obstacles").transform);
        SummarPositionProvider obstaclesPositionProvider = new SummarPositionProvider(_mapConfig);
        Pull<ObstacleView> obstaclesPull = new Pull<ObstacleView>(obstaclesFactory, obstaclesPositionProvider);
        ObstaclesSpawner obstaclesSpawner = new ObstaclesSpawner(_mapConfig, obstaclesPull,obstaclesPositionProvider);

        FinishFactory finishFactory = new FinishFactory(_finishViewPrefab, new PointerPositionProvider(_finishPointer));
        FinishView finishView = finishFactory.Create();
        Winner winner = new Winner(finishView.WinnerPoint, stateMachine);
        FinishCreator finishCreator = new FinishCreator(finishView);

        Ui ui = Instantiate(_uiPrefab);
        
        Exploder exploder = new Exploder(new SphereOverlaper());
        StorageFactory storageFactory = new StorageFactory(_storageConfig, _reservePrefab, exploder, stateMachine);
        SpheresFactory spheresFactory = new SpheresFactory(_hittingSpherePrefab, _sphereConfig, exploder, new GameObject("Spheres").transform);

        PointerPositionProvider positionProvider = new PointerPositionProvider(_startPointer);

        Pull<HittingSphereModel> casterPull = new Pull<HittingSphereModel>(spheresFactory, _startSpheresCapacity, positionProvider);
        Pull<Storage> storagePull = new Pull<Storage>(storageFactory, 1, positionProvider);
        
        SpheresCaster caster = new SpheresCaster(casterPull);
        StorageController storageController = new StorageController(caster, storagePull);
        
        StatsDataParser reserveParser = new StatsDataParser(storageController, _storageConfig.StartCapacity - _storageConfig.MinimalSphereSize);
        StatsDataParser castingSphereParser = new StatsDataParser(caster, _storageConfig.MaxEnergyPerTime);

        UiPlaying uiPlaying = new UiPlaying(new GameInfoModel(ui.CapacitySliderView, reserveParser), 
            new GameInfoModel(ui.CastingSphereSliderView, castingSphereParser), ui);

        lifeCirce.Add(caster);
        lifeCirce.Add((ICreator)storageController);
        lifeCirce.Add((IResetable)storageController);
        lifeCirce.Add((IResetable)obstaclesSpawner);
        lifeCirce.Add((ICreator)obstaclesSpawner);
        lifeCirce.Add(obstaclesPositionProvider);
        lifeCirce.Add((IResetable)finishCreator);
        lifeCirce.Add((ICreator)finishCreator);

        updater.Add(storageController);
        updater.Add(input);

        StatesDependencies statesDependencies = new StatesDependencies(input, updater, lifeCirce);
        
        stateMachine.AddState(new PlayingState(statesDependencies, uiPlaying), States.Playing);
        stateMachine.AddState(new FinishingState(statesDependencies, new UiWinningState(ui)), States.Win);
        stateMachine.AddState(new FinishingState(statesDependencies, new UiLoosingState(ui)), States.Lose);

        _eventBinder = new EventBinder(input, storageController, ui, uiPlaying, stateMachine);
        
        stateMachine.Start();
    }

    private void OnEnable()
    {
        _eventBinder.BindInput();
        _eventBinder.BindEnergySystem();
        _eventBinder.BindUi();
    }

    private void OnDisable()
    {
        _eventBinder.UnBindInput();
        _eventBinder.UnBindEnergySystem();
        _eventBinder.UnBindUi();
    }
}