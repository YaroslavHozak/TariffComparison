using System;

namespace TariffComparison
{
    public class PackagedTariff : IElectricityTariff
    {
        private readonly double _consumptionCosts;
        private readonly double _packageConsumptionThreshold;
        private readonly double _packageCost;

        public string Name => "Packaged tariff";

        public PackagedTariff(double packageConsumptionThreshold, double packageCost, double consumptionCosts)
        {
            _consumptionCosts = consumptionCosts;
            _packageConsumptionThreshold = packageConsumptionThreshold;
            _packageCost = packageCost;
        }

        public PackagedTariff() : this(4000, 800, 0.30) { }

        public double GetAnnualCosts(double consumption)
        {
            if (consumption < 0)
                throw new ArgumentException("Consumption can't be less then 0");

            if (consumption <= _packageConsumptionThreshold)
            {
                return _packageCost;
            }
            else
            {
                var consumptionOverhead = consumption - _packageConsumptionThreshold;
                return _packageCost + consumptionOverhead * _consumptionCosts;
            }
        }
    }
}
