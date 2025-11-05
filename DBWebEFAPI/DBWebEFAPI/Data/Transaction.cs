namespace DBWebEFAPI.Data
{
    public class Transaction
    {
        public int accountNO { get; set; }
        public string transactionId { get; set; }
        public decimal amount { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
    }
}
