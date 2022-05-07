namespace Repository.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Executor { get; }
        public string DateOfEvent { get; }
        public double Amount { get; }
        public string Purpose { get; }
        public string Status { get; }

        public Transaction(int id, string executor, string dateOfEvent, double amount, string purpose, string status)
        {
            Id = id;
            Executor = executor;
            DateOfEvent = dateOfEvent;
            Amount = amount;
            Purpose = purpose;
            Status = status;
        }
    }
}
