using Spectre.Console;
using ParkingSystem.Models;
using ParkingSystem.UI.Helpers;


namespace ParkingSystem.UI
{
    public class ConsoleUI
    {
        public static void ShowWelcomeScreen()
        {
            Console.Clear();
            var rule = new Rule("[yellow]Parking Management System[/]");
            rule.Style = Style.Parse("yellow");
            
            AnsiConsole.Write(rule);
            AnsiConsole.WriteLine();
            
            TableHelper.ShowCommandsTable();
            AnsiConsole.WriteLine();
        }

        public static void ShowStatus(Dictionary<int, Vehicle> slots)
        {
            TableHelper.ShowStatusTable(slots);
        }

        public static void ShowSuccess(string message)
        {
            var panel = new Panel($"[green]{message}[/]");
            panel.Border = BoxBorder.Rounded;
            panel.Padding = new Padding(1, 0, 1, 0);
            
            AnsiConsole.Write(panel);
            AnsiConsole.WriteLine();
        }

        public static void ShowError(string message)
        {
            var panel = new Panel($"[red]{message}[/]");
            panel.Border = BoxBorder.Heavy;
            panel.BorderStyle = Style.Parse("red");
            panel.Padding = new Padding(1, 0, 1, 0);
            
            AnsiConsole.Write(panel);
            AnsiConsole.WriteLine();
        }

        public static string? GetCommand()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>("[blue]Enter command:[/]")
                    .AllowEmpty());
        }
    }
}