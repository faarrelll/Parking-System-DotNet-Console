using ParkingSystem.Models;
using ParkingSystem.Interfaces;

namespace ParkingSystem.Services
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly int _totalSlots;
        private readonly Dictionary<int, Vehicle> _slots;

        public ParkingLotService(int totalSlots)
        {
            _totalSlots = totalSlots;
            _slots = new Dictionary<int, Vehicle>();
        }

        public string Park(string registrationNumber, string color, string type)
        {
            if (_slots.Count >= _totalSlots)
            {
                return "Sorry, parking lot is full";
            }

            int slotNumber = Enumerable.Range(1, _totalSlots)
                .First(i => !_slots.ContainsKey(i));

            _slots[slotNumber] = new Vehicle(registrationNumber, color, type);

            return $"Allocated slot number: {slotNumber}";
        }

        public string Leave(int slotNumber)
        {
            if (!_slots.ContainsKey(slotNumber))
            {
                return "Invalid slot number";
            }

            _slots.Remove(slotNumber);
            return $"Slot number {slotNumber} is free";
        }

        public void Status()
        {
            Console.WriteLine("Slot No. Registration No Type Colour");
            foreach (var slot in _slots.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{slot.Key} {slot.Value.RegistrationNumber} {slot.Value.Type} {slot.Value.Color}");
            }
        }

        public int GetVehiclesByType(string type)
        {
            return _slots.Count(x => x.Value.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
        }

        public string GetRegistrationNumbersByParity(bool isOdd)
        {
            var numbers = _slots.Values
                .Where(v => 
                {
                    var numPart = v.RegistrationNumber.Split('-')[1];
                    return int.TryParse(numPart, out int num) && 
                           (isOdd ? num % 2 == 1 : num % 2 == 0);
                })
                .Select(v => v.RegistrationNumber);
            
            return string.Join(", ", numbers);
        }

        public string GetRegistrationNumbersByColor(string color)
        {
            var numbers = _slots.Values
                .Where(v => v.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
                .Select(v => v.RegistrationNumber);
            
            return string.Join(", ", numbers);
        }

        public string GetSlotNumbersByColor(string color)
        {
            var slots = _slots
                .Where(s => s.Value.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
                .Select(s => s.Key.ToString());
            
            return string.Join(", ", slots);
        }

        public string GetSlotNumberByRegistrationNumber(string registrationNumber)
        {
            var slot = _slots.FirstOrDefault(s => 
                s.Value.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase));
            
            return slot.Key != 0 ? slot.Key.ToString() : "Not found";
        }
    }
}