namespace BusinessLogic.Interfaces
{
    public interface ICard
    {
        string Type { get; }
        string BankName { get; }
        int Id { get; }
        string OwnerFullName { get; }
        int Password { get; }
    }
}
