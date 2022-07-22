namespace Telephony.Models
{
    using Interfaces;
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            return $"Dialing... {phoneNumber}";
        }
    }
}
