using ParkingSystem.Commands;

namespace ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandHandler = new CommandHandler();

            while (true)
            {
                string? command = Console.ReadLine();
                if (command != null)
                {
                    commandHandler.HandleCommand(command);
                }
            }
        }
    }
}