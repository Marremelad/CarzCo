using Spectre.Console;
namespace CarzCo;

public class Menu
{
    // A list of vehicle types used for filtering.
    private static readonly List<string> VehicleTypes = [
        "Cars", "Motorcycles",
        "Trucks", "Buses", "Boats"];
    
    // Type variable to store the selected vehicle type.
    private static Type? _type;
    
    // Displays the reserved vehicle's attributes and allows the user to choose further actions.
    public static void DisplayReservedVehicle(Vehicle vehicle)
    {
        Console.WriteLine($"{vehicle.DisplayAttributes()}");
        
        // Prompt the user to choose between viewing reserved vehicles or returning to the main menu.
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .PageSize(10)
                .AddChoiceGroup("", "Reserved Vehicles", "Main Menu"));
        
        // Handle the user's selection.
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
    
    // Displays the main menu options to the user.
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
        
        // Handle the user's selection from the main menu.
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
    
    // Displays the list of available vehicles and allows the user to interact with them.
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
        
        // Handle the user's selection to filter vehicles or return to the main menu.
        switch (choice)
        {
            case "Filter Vehicles":
                VehicleTypeMenu();
                break;
            case "Main Menu":
                MainMenu();
                break;
        }
        
        // After selecting a vehicle, show the options menu for that vehicle.
        VehicleOptionsMenu((Vehicle)choice);
    }

    // Displays the list of reserved vehicles and allows the user to view details or return to the main menu.
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

        // Handle the user's selection to return to the main menu or display the reserved vehicle's details.
        switch (choice)
        {
            case "Main Menu":
                MainMenu();
                break;
        }
        DisplayReservedVehicle((Vehicle)choice);
    }
    
    // Displays a menu to select the type of vehicle for filtering.
    private static void VehicleTypeMenu() { 
        var input = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("\n  What type of vehicle are you interested in?")
                .PageSize(10)
                .AddChoices(VehicleTypes)
                .AddChoiceGroup("", "All Vehicles", "Main Menu")); 

        // Set the type based on the user's selection.
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
        
        // Display the filtered vehicles.
        VehiclesMenu(Manager.GetFilteredVehicles(_type));
    }

    // Displays options for a specific vehicle (buy, reserve, return to main menu).
    private static void VehicleOptionsMenu(Vehicle vehicle)
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(vehicle.DisplayAttributes())
                .PageSize(10)
                .AddChoiceGroup("", "Buy this vehicle", "Reserve this vehicle", "Main Menu"));
        
        // Handle the user's selection for the vehicle.
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
        
        // Pause before returning to the main menu.
        Thread.Sleep(3000);
        MainMenu();
    }
}
