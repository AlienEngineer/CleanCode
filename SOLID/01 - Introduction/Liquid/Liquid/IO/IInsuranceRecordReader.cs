using System.Collections.Generic;
using Liquid.Models;

namespace Liquid.IO
{
    internal interface IInsuranceRecordReader
    {
        IEnumerable<InsuranceRecord> GetInsuranceRecords();
    }
}