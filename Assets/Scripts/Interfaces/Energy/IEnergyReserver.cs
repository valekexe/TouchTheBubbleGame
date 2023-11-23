public interface IEnergyReserver : IEnergyProvider, IExplodable
{
    void AddEnergy(float offset);
    void SetEnergy(float offset);
    void ResetEnergy();
}