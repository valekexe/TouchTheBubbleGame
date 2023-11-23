
using System.Collections.Generic;
using System.Linq;

public class Pull<T> where T : IPositionControllable, IActivityProvider
{
    private IPositionProvider _pointer;
    private IFactory<T> _factory;
    private int _capacity;

    private List<T> _pulledObjects;

    public Pull(IFactory<T> factory, int capacity, IPositionProvider pointer)
    {
        _pointer = pointer;
        _factory = factory;
        _capacity = capacity;
        _pulledObjects = new List<T>(_capacity);
        CreatePull();
    }
    
    public Pull(IFactory<T> factory, IPositionProvider pointer)
    {
        _pointer = pointer;
        _factory = factory;
        _pulledObjects = new List<T>(5);
    }

    private void CreatePull()
    {
        for (int i = 0; i < _capacity; i++)
        {
            CreateOne();
        }
    }

    private void CreateOne()
    {
        var obj = _factory.Create();
        obj.SetInActive();
        _pulledObjects.Add(obj);
    }

    public T Get()
    {
        if (_pulledObjects.Count == 0)
            CreateOne();
        
        var go = _pulledObjects.First();
        _pulledObjects.Remove(go);
        SetPosition(go);
        go.SetActive();
        return go;
    }

    public void Return(List<T> objs)
    {
        foreach (var obj in objs)
        {
            Return(obj);
        }
    }

    public void Return(T obj)
    {
        obj.SetInActive();
        _pulledObjects.Add(obj);
    }

    public void SetPosition(T model)
    {
        model.SetPosition(_pointer.GetPosition());
    }
}