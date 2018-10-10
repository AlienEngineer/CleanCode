using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liquid.Models;

namespace Liquid.IO
{
    internal class GroupByCountryReader : IInsuranceRecordReader
    {
        private readonly IInsuranceRecordReader reader;

        public GroupByCountryReader(IInsuranceRecordReader reader)
        {
            this.reader = reader;
        }

        public IEnumerable<InsuranceRecord> GetInsuranceRecords()
        {
            return reader.GetInsuranceRecords()
                .GroupBy(e => e.Country)
                .Select(groupedByCountry => new InsuranceRecord
                {
                    Country = groupedByCountry.Key,
                    TypeOfHouse = groupedByCountry.First().TypeOfHouse,
                    Value = groupedByCountry.Sum(e => e.Value)
                });
        }
    }
}
