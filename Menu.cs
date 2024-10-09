using Spectre.Console;
namespace CarzCo;

public class Menu
{
    private static readonly List<string> _vehicleTypes = [
             "All types", "Cars", "Motorcycles",
                        "Trucks", "Buses", "Boats"];
    private static Type? _type = null;

    public static void MainMenu()
    {
        Console.Clear();
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("\n  Welcome to Carz Co. The leading console app for buying cars!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(new[] {
                    "All Vehicles",
                    "Reserved Vehicles",
                    "Filter Vehicles"
                }));
        
        switch (choice)
        {
            case "All Vehicles":
                VehiclesMenu(Manager.GetVehicles(_type));
                break;
            case "Reserved Vehicles":
                ReservedVehiclesMenu(Manager.GetReservedVehicles(_type));
                break;
            case "Filter Vehicles":
                VehicleTypeMenu();
                break;
        }
    }

    private static bool CheckChoice(object choice)
    {
        if (choice is string stringValue)
        {
            if (stringValue == "Main menu")
            {
                return true;
            }
        }
        return false;
    }

    public static void DisplayReservedVehicle(Vehicle vehicle)
    {
        Console.WriteLine($"{vehicle.DisplayAttributes()}");
        
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more vehicles)[/]")
                .AddChoiceGroup("", "Reserved vehicles", "Main menu"));
        
        switch (choice)
        {
            case "Main menu":
                MainMenu();
                break;
            case "Reserved vehicles":
                ReservedVehiclesMenu(Manager.GetReservedVehicles());
                break;
        }
    }

    private static void VehiclesMenu(List<Vehicle> vehicles)
    {
        Console.Clear();
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<object>()
                .Title("\n  Vehicles in stock")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more vehicles)[/]")
                .AddChoices(vehicles)
                .AddChoiceGroup("", "Main menu")); 
        
        if (CheckChoice(choice)) MainMenu();
        else VehicleOptionsMenu((Vehicle)choice);
    }

    private static void ReservedVehiclesMenu(Dictionary<int, Vehicle> reservedVehicles)
    {
        Console.Clear();
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<object>()
                .Title("\n  Reserved vehicles")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more vehicles)[/]")
                .AddChoices(reservedVehicles.Values)
                .AddChoiceGroup("", "Main menu"));
        
        if (CheckChoice(choice)) MainMenu();
        DisplayReservedVehicle((Vehicle)choice);
    }

    private static void VehicleOptionsMenu(Vehicle vehicle)
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(vehicle.DisplayAttributes())
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more vehicles)[/]")
                .AddChoiceGroup("", "Buy this vehicle", "Reserve this vehicle", "Main menu"));
        if (CheckChoice(choice)) MainMenu();
        
        switch (choice)
        {
            case "Buy this vehicle":
                Manager.SellVehicle(vehicle, 500);
                Console.WriteLine("\nThank you for visiting Carz Co. Have a nice ride.");
                break;
            case "Reserve this vehicle":
                Manager.ReserveVehicle(vehicle);
                Console.WriteLine("\nYour vehicle has been reserved.");
                break;
        }
        Thread.Sleep(3000);
        MainMenu();
    }
    private static void VehicleTypeMenu() { 
        var input = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("What type of vehicle are you interested in?")
            .PageSize(10)
            .AddChoices(_vehicleTypes)
             .AddChoiceGroup("", "Main menu")); 

            switch (input)
            {
                case "All types":
                    _type = null;
                    break;

                case "Cars":
                    _type = typeof(Car);
                    break;

                case "Motorcycles":
                    _type = typeof(Motorcycle);
                    break;

                case "Trucks":
                    _type = typeof(Truck);
                    break;

                case "Buses":
                    _type = typeof(Bus);
                    break;

                case "Boats":
                    _type = typeof(Boat);
                    break;

                case "Main menu":
                    break;
            }
            MainMenu();
       }
}
