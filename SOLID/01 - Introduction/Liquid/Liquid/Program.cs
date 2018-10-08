using System.Collections.Generic;
using Liquid.IO;
using Liquid.IO.CsvFiles;
using Liquid.Models;

namespace Liquid
{
    // Read from a csv file
    // Get the total value of insured houses
    // Store the Value by country
    // The last line must have the total and the current date
    // -----
    // Client 1: Ignore Residential type of housing.
    // Client 2: Ignore Commercial type of housing.

    // Violations:
    // SRP, OCP, DIP
    
    public class Program
    {
       
        private static IInsuranceRecordReader MakeInsuranceReader(TypeOfHousing typeOfHousing)
        {
            return new TypeOfHouseFilteredRecordReader(new CsvFileReader(), typeOfHousing);
        }

        private static IInsuranceRecordWriter MakeInsuranceWriter()
        {
            return new CsvFileWriter();
        }
        
        private static TypeOfHousing GetTypeOfHousing(IReadOnlyList<string> args)
        {
            int.TryParse(args[0], out var client);

            return (TypeOfHousing)client;
        }

        public static void Main(string[] args)
        {
            var typeOfHousing = GetTypeOfHousing(args);

            var insuranceWriter = MakeInsuranceWriter();
            var insuranceReader = MakeInsuranceReader(typeOfHousing);

            var exporter = new Exporter(insuranceWriter, insuranceReader);
            exporter.Export(typeOfHousing);
        }
    }

}
