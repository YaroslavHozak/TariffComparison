using System;

namespace TariffComparison
{
    public class BasicTariff : IElectricityTariff
    {
        private readonly double _baseCostPerMonth;
        private readonly double _consumptionCosts;

        public string Name => "Basic electricity tariff";

        public BasicTariff(double baseCostPerMonth, double consumptionCosts)
        {
            _baseCostPerMonth = baseCostPerMonth;
            _consumptionCosts = consumptionCosts;
        }

        public BasicTariff() : this(5, 0.22) { }

        public double GetAnnualCosts(double consumption)
        {
            if (consumption < 0)
                throw new ArgumentException("Consumption can't be less then 0");

            return 12 * _baseCostPerMonth + consumption * _consumptionCosts;
        }
    }
}
