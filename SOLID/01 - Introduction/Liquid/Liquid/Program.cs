namespace Liquid
{
    // Read from a csv file
    // Get the total value of insured houses
    // Store the Value by country
    // The last line must have the total and the current date
    // -----
    // Client 1: Residential type of housing.
    // Client 2: Commercial type of housing.
    //
    // Uml: https://yuml.me/diagram/plain;dir:LR/class/[Program%7CMain(args)]-uses%3E[InsuranceRecord],%20[CsvFile]-reads%3E[InsuranceRecord],%20[Program%7CMain(args)]%3C%3E-%3E[CsvFile].jpg
    public class Program
    {

        public static void Main(string[] args)
        {
            var csvFile = new CsvFile();

            int.TryParse(args[0], out var client);

            var total = 0.0;

            csvFile.StartExport(client);

            foreach (var record in csvFile.GetInsuranceRecords())
            {
                if (client == 1)
                {
                    if (record.TypeOfHouse == "Residential")
                    {
                        csvFile.StoreRecord(record);
                        total += record.Value;
                    }
                }
                if (client == 2)
                {
                    if (record.TypeOfHouse == "Commercial")
                    {
                        csvFile.StoreRecord(record);
                        total += record.Value;
                    }
                }
            }

            csvFile.StoreTotalValue(total);
        }
    }
}
