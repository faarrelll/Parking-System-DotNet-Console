using Spectre.Console;
using ParkingSystem.Models;
using ParkingSystem.Constants;

namespace ParkingSystem.UI.Helpers
{
    public static class TableHelper
    {
        public static void ShowCommandsTable()
        {
            var table = new Table();
            table.AddColumn("[green]Available Commands[/]");
            table.AddColumn("[blue]Description[/]");
            
            table.AddRow(CommandConstants.CREATE_PARKING_LOT + " <capacity>", "Create a new parking lot");
            table.AddRow(CommandConstants.PARK + " <reg_number:ex = N-123> <color> <type>", "Park a vehicele");
            table.AddRow(CommandConstants.LEAVE + " <slot_number>", "Remove a vehicle from slot");
            table.AddRow(CommandConstants.STATUS, "Show parking lot status");
            table.AddRow(CommandConstants.TYPE_OF_VEHICLES + " <type>", "Count vehicles by type");
            table.AddRow(CommandConstants.REG_NUMBERS_ODD, "Get vehicles with odd plates");
            table.AddRow(CommandConstants.REG_NUMBERS_EVEN, "Get vehicles with even plates");
            table.AddRow(CommandConstants.REG_NUMBERS_COLOR + " <color>", "Get vehicles by color");
            table.AddRow(CommandConstants.SLOT_NUMBERS_COLOR + " <color>", "Get slot numbers by color");
            table.AddRow(CommandConstants.SLOT_NUMBER_REG + " <reg_number>", "Find slot by registration number");
            table.AddRow(CommandConstants.EXIT, "Exit the application");
            
            AnsiConsole.Write(table);
        }

        public static void ShowStatusTable(Dictionary<int, Vehicle> slots)
        {
            var table = new Table();
            table.AddColumn(new TableColumn("[yellow]Slot No.[/]").Centered());
            table.AddColumn(new TableColumn("[green]Registration No[/]").Centered());
            table.AddColumn(new TableColumn("[blue]Type[/]").Centered());
            table.AddColumn(new TableColumn("[purple]Colour[/]").Centered());
            table.AddColumn(new TableColumn("[orange3]Check-in Time[/]").Centered());

            foreach (var slot in slots.OrderBy(x => x.Key))
            {
                table.AddRow(
                    slot.Key.ToString(),
                    slot.Value.RegistrationNumber,
                    slot.Value.Type,
                    slot.Value.Color,
                    slot.Value.CheckInTime.ToString("HH:mm:ss")
                );
            }

            AnsiConsole.Write(table);
            AnsiConsole.WriteLine();
        }
    }
}