﻿using Spectre.Console;
namespace CarzCo;

public class Menu
{
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
                }));
        
        switch (choice)
        {
            case "All Vehicles":
                VehiclesMenu(Manager.GetVehicles());
                break;
            case "Reserved Vehicles":
                ReservedVehiclesMenu(Manager.GetReservedVehicles());
                break;
        }
    }

    private static bool CheckChoice(object choice)
    {
        if (choice is string stringValue)
        {
            if (stringValue == "Return to main menu")
            {
                return true;
            }
        }
        return false;
    }

    private static void VehiclesMenu(List<Vehicle> vehicles)
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<object>()
                .Title("\n  Vehicles in stock")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more vehicles)[/]")
                .AddChoices(vehicles)
                .AddChoices("Return to main menu"));
        
        if (CheckChoice(choice)) MainMenu();
        else VehicleOptionsMenu((Vehicle)choice);
    }

    private static void ReservedVehiclesMenu(Dictionary<int, Vehicle> reservedVehicles)
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<object>()
                .Title("\n  Reserved vehicles")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more vehicles)[/]")
                .AddChoices(reservedVehicles.Values)
                .AddChoices("Return to main menu"));
        
        if (CheckChoice(choice)) MainMenu();
    }

    private static void VehicleOptionsMenu(Vehicle vehicle)
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(vehicle.DisplayAttributes())
                .PageSize(5)
                .MoreChoicesText("[grey](Move up and down to reveal more vehicles)[/]")
                .AddChoices(new[] {
                    "Buy this vehicle",
                    "Reserve this vehicle",
                }));
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
}