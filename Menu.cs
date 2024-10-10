using Spectre.Console;
namespace CarzCo;

public class Menu
{
    private static readonly List<string> VehicleTypes = [
        "Cars", "Motorcycles",
        "Trucks", "Buses", "Boats"];
    private static Type? _type;
    
    public static void DisplayReservedVehicle(Vehicle vehicle)
    {
        Console.WriteLine($"{vehicle.DisplayAttributes()}");
        
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .PageSize(10)
                .AddChoiceGroup("", "Reserved Vehicles", "Main Menu"));
        
        switch (choice)
        {
            case "Main Menu":
                MainMenu();
                break;
            case "Reserved Vehicles":
                ReservedVehiclesMenu(Manager.GetReservedVehicles());
                break;
        }
    }
    
    public static void MainMenu()
    {
        Console.Clear();
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("\n  Welcome to Carz Co. The leading console app for buying cars!")
                .PageSize(10)
                .AddChoices(new[] {
                    "All Vehicles",
                    "Reserved Vehicles",
                    "Filter Vehicles"
                }));
        
        switch (choice)
        {
            case "All Vehicles":
                VehiclesMenu(Manager.GetVehicles());
                break;
            case "Reserved Vehicles":
                ReservedVehiclesMenu(Manager.GetReservedVehicles());
                break;
            case "Filter Vehicles":
                VehicleTypeMenu();
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
                .MoreChoicesText("[blue](Move up and down to reveal more options)[/]")
                .AddChoices(vehicles)
                .AddChoiceGroup("", "Filter Vehicles", "Main Menu"));
        
        switch (choice)
        {
            case "Filter Vehicles":
                VehicleTypeMenu();
                break;
            case "Main Menu":
                MainMenu();
                break;
        }
        VehicleOptionsMenu((Vehicle)choice);
    }

    private static void ReservedVehiclesMenu(Dictionary<int, Vehicle> reservedVehicles)
    {
        Console.Clear();
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<object>()
                .Title("\n  Reserved Vehicles")
                .PageSize(10)
                .MoreChoicesText("[blue](Move up and down to reveal more options)[/]")
                .AddChoices(reservedVehicles.Values)
                .AddChoiceGroup("", "Main Menu"));

        switch (choice)
        {
            case "Main Menu":
                MainMenu();
                break;
        }
        DisplayReservedVehicle((Vehicle)choice);
    }
    
    private static void VehicleTypeMenu() { 
        var input = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("\n  What type of vehicle are you interested in?")
                .PageSize(10)
                .AddChoices(VehicleTypes)
                .AddChoiceGroup("", "All Vehicles", "Main Menu")); 

        switch (input)
        {
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
            case "All Vehicles":
                VehiclesMenu(Manager.GetVehicles());
                break;
            case "Main Menu":
                MainMenu();
                break;
        }
        VehiclesMenu(Manager.GetFilteredVehicles(_type));
    }

    private static void VehicleOptionsMenu(Vehicle vehicle)
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(vehicle.DisplayAttributes())
                .PageSize(10)
                .AddChoiceGroup("", "Buy this vehicle", "Reserve this vehicle", "Main Menu"));
        
        switch (choice)
        {
            case "Buy this vehicle":
                Manager.SellVehicle(vehicle);
                Console.WriteLine("\nThank you for visiting Carz Co. Have a nice ride.");
                break;
            case "Reserve this vehicle":
                Manager.ReserveVehicle(vehicle);
                Console.WriteLine("\nYour vehicle has been reserved.");
                break;
            case "Main Menu":
                MainMenu();
                break;
        }
        Thread.Sleep(3000);
        MainMenu();
    }
}
