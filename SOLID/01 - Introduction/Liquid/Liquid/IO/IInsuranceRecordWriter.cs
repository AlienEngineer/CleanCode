using Liquid.Models;

namespace Liquid.IO
{
    internal interface IInsuranceRecordWriter
    {
        void StartExport();
        void StoreTotalValue(double total);
        void StoreRecord(InsuranceRecord record);
    }
}