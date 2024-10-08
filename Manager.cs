using System.Xml.Serialization;

namespace CarzCo;

public abstract class Manager
{
    private static List<Vehicle> _vehicles = new List<Vehicle>();
    private static Dictionary<int, MaintenanceRecord> _maintenanceRecords = new Dictionary<int, MaintenanceRecord>();

    public static void AddVehicle(Vehicle vehicle)
    {
        _vehicles.Add(vehicle);
    }

    public static void AddVehicle(IList<Vehicle> vehicles)
    {
        foreach (var vehicle in vehicles)
        {
            _vehicles.Add(vehicle);
        }
    }
    
    public static void DisplayVehicles()
    {
        foreach (var vehicle in _vehicles)
        {
            Console.WriteLine($"{vehicle.Make} {vehicle.Model} - Fuel Type:" +
                              $" {vehicle.FuelType}, Max Velocity: {vehicle.MaxSpeed} km/h");
        }
    }

    public static void AddService(MaintenanceRecord service)
    {
        _maintenanceRecords.Add(service.Id, service);
    }

    public static void DisplayService(int vehicleId)
    {
        
        Console.WriteLine($"Vehicle Id: {_maintenanceRecords[vehicleId].Id}\n" +
                          $"Service Type: {_maintenanceRecords[vehicleId].ServiceType}\n" +
                          $"Date: {_maintenanceRecords[vehicleId].Date:d}");
    }
}