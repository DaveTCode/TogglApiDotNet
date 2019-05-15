using System.Collections.Generic;
using Newtonsoft.Json;

namespace TogglApi.Client.Reports.Models.Response
{
    public abstract class ReportResponse
    {
        public long? TotalGrand { get; }

        public long? TotalBillable { get; }
        
        public List<TotalCurrency> TotalCurrencies { get; }

        [JsonConstructor]
        public ReportResponse(long? totalGrand, long? totalBillable, List<TotalCurrency> totalCurrencies)
        {
            TotalGrand = totalGrand;
            TotalBillable = totalBillable;
            TotalCurrencies = totalCurrencies;
        }
    }
}
