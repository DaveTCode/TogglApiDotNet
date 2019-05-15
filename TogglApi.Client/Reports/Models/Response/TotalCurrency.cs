namespace TogglApi.Client.Reports.Models.Response
{
    public class TotalCurrency
    {
        public string Currency { get; }

        public double? Amount { get; }

        public TotalCurrency(string currency, double? amount)
        {
            Currency = currency;
            Amount = amount;
        }
    }
}
