
namespace TariffComparison
{
    public interface IElectricityTariff
    {
        string Name { get; }
        double GetAnnualCosts(double electricity);
    }
}
