using System.Collections.Generic;
using System.Linq;
using Liquid.Models;

namespace Liquid.IO
{
    internal class TypeOfHouseFilteredRecordReader : IInsuranceRecordReader
    {
        private readonly IInsuranceRecordReader csvFile;
        private readonly string typeOfHousing;

        public TypeOfHouseFilteredRecordReader(IInsuranceRecordReader csvFile, TypeOfHousing typeOfHousing)
        {
            this.csvFile = csvFile;
            this.typeOfHousing = typeOfHousing.ToString();
        }

        public IEnumerable<InsuranceRecord> GetInsuranceRecords()
        {
            return csvFile.GetInsuranceRecords()
                .Where(e => e.TypeOfHouse == typeOfHousing);
        }
    }
}