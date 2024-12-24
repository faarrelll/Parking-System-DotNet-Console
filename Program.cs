using ParkingSystem.Commands;
using ParkingSystem.UI;

namespace ParkingSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            var commandHandler = new CommandHandler();
            ConsoleUI.ShowWelcomeScreen();

            while (true)
            {
                string? command = ConsoleUI.GetCommand();
                if (command != null)
                {
                    commandHandler.HandleCommand(command);
                }
            }
        }
    }
}