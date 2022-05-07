namespace BusinessLogic.Interfaces
{
    public interface IATMService
    {
        public bool Validate(long cardNumber, int pinCode);
    }
}
