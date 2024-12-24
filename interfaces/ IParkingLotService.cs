namespace ParkingSystem.Interfaces
{
    public interface IParkingLotService
    {
        string Park(string registrationNumber, string color, string type);
        string Leave(int slotNumber);
        void Status();
        int GetVehiclesByType(string type);
        string GetRegistrationNumbersByParity(bool isOdd);
        string GetRegistrationNumbersByColor(string color);
        string GetSlotNumbersByColor(string color);
        string GetSlotNumberByRegistrationNumber(string registrationNumber);
    }
}