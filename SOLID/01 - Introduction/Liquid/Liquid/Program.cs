using System.Collections.Generic;
using Liquid.Models;

namespace Liquid
{
    // Read from a csv file
    // Get the total value of insured houses
    // Store the Value by country
    // The last line must have the total and the current date
    // -----
    // Client 1: Residential type of housing.
    // Client 2: Commercial type of housing.
    public static class Program
    {
        private static TypeOfHousing GetTypeOfHousing(this IReadOnlyList<string> args)
        {
            int.TryParse(args[0], out var client);

            return (TypeOfHousing)client;
        }

        public static void Main(string[] args)
        {
            InsuranceReports
                .GetReportWithTotal(args.GetTypeOfHousing())
                .Export();
        }
    }
}
