using Spectre.Console;
namespace CarzCo;

public class Menu
{
    public static void MainMenu()
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Welcome to Carz Co")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(new[] {
                    "Vehicles", "Reserved Vehicles",
                }));
        
        switch (choice)
        {
            case "Vehicles":
                VehiclesMenu(Manager.GetVehicles());
                break;
            case "Reserved Vehicles":
                ReservedVehiclesMenu(Manager.GetReservedVehicles());
                break;
        }
    }

    private static void VehiclesMenu(List<Vehicle> vehicles)
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<Vehicle>()
                .Title("Vehicles in stock")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more vehicles)[/]")
                .AddChoices(vehicles));
    }

    private static void ReservedVehiclesMenu(Dictionary<int, Vehicle> reservedVehicles)
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<Vehicle>()
                .Title("Reserved vehicles")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more vehicles)[/]")
                .AddChoices(reservedVehicles.Values));
    }
}