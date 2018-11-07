using System;
using System.Collections.Generic;
using System.Linq;

namespace TariffComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            var comparisonResults = CompareConsumptionCosts(new List<IElectricityTariff> { new BasicTariff(), new PackagedTariff() }, 3500);
            Console.WriteLine("{0,25}: {1,13}", "Tariff name", "Annual costs");
            foreach (var comparisonRow in comparisonResults)
            {
                Console.WriteLine("{0,25}: {1,13:N2}", comparisonRow.Name, comparisonRow.AnnualCosts);
            }
            Console.ReadLine();
        }

        static IEnumerable<TariffComparisonResult> CompareConsumptionCosts(IEnumerable<IElectricityTariff> tariffs, double consumption)
        {
            return tariffs.Select(t => new TariffComparisonResult
            {
                Name = t.Name,
                AnnualCosts = t.GetAnnualCosts(consumption)
            }).OrderBy(tc => tc.AnnualCosts);
        }
    }
}
