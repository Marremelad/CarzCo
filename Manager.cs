namespace CarzCo;

public abstract class Manager
{
    private static List<Vehicle> _vehicles = new List<Vehicle>();

    private static Dictionary<int, Vehicle> _reservedVehicles = new Dictionary<int, Vehicle>();
    
    private static Dictionary<int, MaintenanceRecord> _maintenanceRecords = new Dictionary<int, MaintenanceRecord>();

    private static Dictionary<int, DateTime> _dateAddedToStock = new Dictionary<int, DateTime>();

    public static void AddVehicle(Vehicle vehicle)
    {
        _vehicles.Add(vehicle);
        _dateAddedToStock.Add(vehicle.VehicleId, DateTime.Now);
    }

    public static void AddVehicle(IList<Vehicle> vehicles)
    {
        foreach (var vehicle in vehicles)
        {
            _vehicles.Add(vehicle);
            _dateAddedToStock.Add(vehicle.VehicleId, DateTime.Now);
        }
    }

    public static void DisplayDateAddedToStock()
    {
        foreach (DateTime date in _dateAddedToStock.Values)
        {
            Console.WriteLine(date);
        }
    }
    
    public static void DisplayVehicles()
    {
        foreach (var vehicle in _vehicles)
        {
            Console.WriteLine($"{vehicle.Make} {vehicle.Model} - Fuel Type:" +
                              $" {vehicle.FuelType}, Max Velocity: {vehicle.MaxSpeed} km/h\n");
        }
    }

    public static void ReserveVehicle(Vehicle vehicle)
    {
        _reservedVehicles.Add(vehicle.VehicleId, vehicle);
    }
    
    public static void ReserveVehicle(List<Vehicle> vehicles)
    {
        foreach (var vehicle in vehicles)
        {
            _reservedVehicles.Add(vehicle.VehicleId, vehicle);
        }
        
    }

    public static void DisplayReservedVehicles()
    {
        Console.WriteLine("Reserved Vehicles-");
        foreach (var vehicle in _reservedVehicles.Values)
        {
            Console.WriteLine($"Vehicle ID: {vehicle.VehicleId}\n" +
                              $"Make: {vehicle.Make}\n" +
                              $"Model: {vehicle.Model}\n");
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