using Liquid.IO;
using Liquid.IO.CsvFiles;
using Liquid.Models;

namespace Liquid
{
    public static class InsuranceReports
    {
        
        private static IInsuranceRecordReader MakeInsuranceReader(TypeOfHousing typeOfHousing)
        {
            return new TypeOfHouseFilteredRecordReader(new CsvFileReader(), typeOfHousing);
        }

        private static IInsuranceRecordWriter MakeInsuranceWriter(TypeOfHousing typeOfHousing)
        {
            return new CsvFileWriter(typeOfHousing);
        }

        public static IReport GetReportWithTotal(TypeOfHousing typeOfHousing)
        {
            var insuranceWriter = MakeInsuranceWriter(typeOfHousing);
            var insuranceReader = MakeInsuranceReader(typeOfHousing);

            return new InsuranceReportWithTotal(insuranceWriter, insuranceReader);
        }
    }
}