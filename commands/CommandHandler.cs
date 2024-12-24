using ParkingSystem.Constants;
using ParkingSystem.Interfaces;
using ParkingSystem.Services;
using ParkingSystem.UI;

namespace ParkingSystem.Commands
{
    public class CommandHandler
    {
        private IParkingLotService? _parkingService;

        public void HandleCommand(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                ConsoleUI.ShowError("Please enter a command");
                return;
            }

            string[] inputs = input.Split(' ');

            try
            {
                switch (inputs[0].ToLower())
                {
                    case CommandConstants.CREATE_PARKING_LOT:
                        int totalSlots = int.Parse(inputs[1]);
                        _parkingService = new ParkingLotService(totalSlots);
                        ConsoleUI.ShowSuccess($"Created a parking lot with {totalSlots} slots");
                        break;

                    case CommandConstants.PARK:
                        ValidateService();
                        if (_parkingService != null)
                        {
                            ConsoleUI.ShowSuccess(_parkingService.Park(inputs[1], inputs[2], inputs[3]));
                        }
                        break;

                    case CommandConstants.LEAVE:
                        ValidateService();
                        if (_parkingService != null)
                        {
                            ConsoleUI.ShowSuccess(_parkingService.Leave(int.Parse(inputs[1])));
                        }
                        break;

                    case CommandConstants.STATUS:
                        ValidateService();
                        _parkingService?.Status();
                        break;

                    case CommandConstants.TYPE_OF_VEHICLES:
                        ValidateService();
                        if (_parkingService != null)
                        {
                            ConsoleUI.ShowSuccess($"Number of vehicles of type {inputs[1]}: {_parkingService.GetVehiclesByType(inputs[1])}");
                        }
                        break;

                    case CommandConstants.REG_NUMBERS_ODD:
                        ValidateService();
                        if (_parkingService != null)
                        {
                            ConsoleUI.ShowSuccess($"Vehicles with odd plate numbers: {_parkingService.GetRegistrationNumbersByParity(true)}");
                        }
                        break;

                    case CommandConstants.REG_NUMBERS_EVEN:
                        ValidateService();
                        if (_parkingService != null)
                        {
                            ConsoleUI.ShowSuccess($"Vehicles with even plate numbers: {_parkingService.GetRegistrationNumbersByParity(false)}");
                        }
                        break;

                    case CommandConstants.REG_NUMBERS_COLOR:
                        ValidateService();
                        if (_parkingService != null)
                        {
                            ConsoleUI.ShowSuccess($"Vehicles with color {inputs[1]}: {_parkingService.GetRegistrationNumbersByColor(inputs[1])}");
                        }
                        break;

                    case CommandConstants.SLOT_NUMBERS_COLOR:
                        ValidateService();
                        if (_parkingService != null)
                        {
                            ConsoleUI.ShowSuccess($"Slot numbers for color {inputs[1]}: {_parkingService.GetSlotNumbersByColor(inputs[1])}");
                        }
                        break;

                    case CommandConstants.SLOT_NUMBER_REG:
                        ValidateService();
                        if (_parkingService != null)
                        {
                            ConsoleUI.ShowSuccess($"Slot number: {_parkingService.GetSlotNumberByRegistrationNumber(inputs[1])}");
                        }
                        break;

                    case CommandConstants.EXIT:
                        ConsoleUI.ShowSuccess("Thank you for using Parking System!");
                        Environment.Exit(0);
                        break;

                    default:
                        ConsoleUI.ShowError("Invalid command");
                        break;
                }
            }
            catch (Exception ex)
            {
                ConsoleUI.ShowError($"Error: {ex.Message}");
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