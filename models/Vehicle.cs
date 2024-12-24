namespace ParkingSystem.Models
{
    public class Vehicle
    {
        public Vehicle(string registrationNumber, string color, string type)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            Type = type;
            CheckInTime = DateTime.Now;
        }

        public string RegistrationNumber { get; private set; }
        public string Color { get; private set; }
        public string Type { get; private set; }
        public DateTime CheckInTime { get; private set; }
    }
}