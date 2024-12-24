using ParkingSystem.Interfaces;
using ParkingSystem.Services;

namespace ParkingSystem.Commands
{
    public class CommandHandler
    {
        private IParkingLotService? _parkingService;

        public void HandleCommand(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please enter a command");
                return;
            }

            string[] inputs = input.Split(' ');

            try
            {
                switch (inputs[0].ToLower())
                {
                    case "create_parking_lot":
                        int totalSlots = int.Parse(inputs[1]);
                        _parkingService = new ParkingLotService(totalSlots);
                        Console.WriteLine($"Created a parking lot with {totalSlots} slots");
                        break;

                    case "park":
                        ValidateService();
                        if (_parkingService != null)
                        {
                            Console.WriteLine(_parkingService.Park(inputs[1], inputs[2], inputs[3]));
                        }
                        break;

                    case "leave":
                        ValidateService();
                        if (_parkingService != null)
                        {
                            Console.WriteLine(_parkingService.Leave(int.Parse(inputs[1])));
                        }
                        break;

                    case "status":
                        ValidateService();
                        _parkingService?.Status();
                        break;

                    case "type_of_vehicles":
                        ValidateService();
                        if (_parkingService != null)
                        {
                            Console.WriteLine(_parkingService.GetVehiclesByType(inputs[1]));
                        }
                        break;

                    case "registration_numbers_for_vehicles_with_odd_plate":
                        ValidateService();
                        if (_parkingService != null)
                        {
                            Console.WriteLine(_parkingService.GetRegistrationNumbersByParity(true));
                        }
                        break;

                    case "registration_numbers_for_vehicles_with_even_plate":
                        ValidateService();
                        if (_parkingService != null)
                        {
                            Console.WriteLine(_parkingService.GetRegistrationNumbersByParity(false));
                        }
                        break;

                    case "registration_numbers_for_vehicles_with_color":
                        ValidateService();
                        if (_parkingService != null)
                        {
                            Console.WriteLine(_parkingService.GetRegistrationNumbersByColor(inputs[1]));
                        }
                        break;

                    case "slot_numbers_for_vehicles_with_color":
                        ValidateService();
                        if (_parkingService != null)
                        {
                            Console.WriteLine(_parkingService.GetSlotNumbersByColor(inputs[1]));
                        }
                        break;

                    case "slot_number_for_registration_number":
                        ValidateService();
                        if (_parkingService != null)
                        {
                            Console.WriteLine(_parkingService.GetSlotNumberByRegistrationNumber(inputs[1]));
                        }
                        break;

                    case "exit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void ValidateService()
        {
            if (_parkingService == null)
            {
                throw new Exception("Parking lot not initialized");
            }
        }
    }
}