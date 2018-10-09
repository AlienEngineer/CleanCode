using System.Collections.Generic;
using System.Linq;
using Liquid.Models;

namespace Liquid.IO
{
    internal class TypeOfHouseFilteredRecordReader : IInsuranceRecordReader
    {
        private readonly IInsuranceRecordReader recordReader;
        private readonly string typeOfHousing;

        public TypeOfHouseFilteredRecordReader(IInsuranceRecordReader recordReader, TypeOfHousing typeOfHousing)
        {
            this.recordReader = recordReader;
            this.typeOfHousing = typeOfHousing.ToString();
        }

        public IEnumerable<InsuranceRecord> GetInsuranceRecords()
        {
            return recordReader.GetInsuranceRecords()
                .Where(e => e.TypeOfHouse == typeOfHousing);
        }
    }
}