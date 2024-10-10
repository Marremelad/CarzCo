using Spectre.Console;

namespace CarzCo;

public abstract class Manager
{
    // List to store all vehicles in stock.
    private static List<Vehicle> _vehicles = new List<Vehicle>();

    // Dictionary to store reserved vehicles with VehicleId as the key.
    private static Dictionary<int, Vehicle> _reservedVehicles = new Dictionary<int, Vehicle>();
    
    // Dictionary to store maintenance records for each vehicle.
    private static Dictionary<int, MaintenanceRecord> _maintenanceRecords = new Dictionary<int, MaintenanceRecord>();

    // Dictionary to track when each vehicle was added to stock.
    private static Dictionary<int, DateTime> _dateAddedToStock = new Dictionary<int, DateTime>();
    
    // List to store all sale records.
    public static List<SaleRecord> _SaleRecords = new List<SaleRecord>();
    
    // Adds a single vehicle to the vehicle list and records the date it was added.
    public static void AddVehicle(Vehicle vehicle)
    {
        _vehicles.Add(vehicle);
        _dateAddedToStock.Add(vehicle.VehicleId, DateTime.Now);
    }
    
    // Adds multiple vehicles to the vehicle list and records the date each was added.
    public static void AddVehicle(IList<Vehicle> vehicles)
    {
        foreach (var vehicle in vehicles)
        {
            _vehicles.Add(vehicle);
            _dateAddedToStock.Add(vehicle.VehicleId, DateTime.Now);
        }
    }
    
    // Returns a list of available (non-reserved) vehicles.
    public static List<Vehicle> GetVehicles()
    {
        List<Vehicle> availableVehicles = new List<Vehicle>();
        
        foreach (Vehicle vehicle in _vehicles)
        {
            // Skip if the vehicle is reserved.
            if (_reservedVehicles.ContainsValue(vehicle)) continue;
            availableVehicles.Add(vehicle);
        }
        return availableVehicles;
    }
    
    // Returns a list of vehicles filtered by type, excluding reserved vehicles.
    public static List<Vehicle> GetFilteredVehicles(Type? type = null)
    {
        List<Vehicle> filteredVehicles = new List<Vehicle>();

        if (type != null)
        {
            filteredVehicles = _vehicles.Where(v => v.GetType() == type && !_reservedVehicles.ContainsValue(v))
                .ToList();
        }

        return filteredVehicles;
    } 
    
    // Reserves a single vehicle by adding it to the reserved vehicles dictionary.
    public static void ReserveVehicle(Vehicle vehicle)
    {
        _reservedVehicles.Add(vehicle.VehicleId, vehicle);
    }
    
    // Reserves multiple vehicles by adding them to the reserved vehicles dictionary.
    public static void ReserveVehicle(List<Vehicle> vehicles)
    {
        foreach (var vehicle in vehicles)
        {
            _reservedVehicles.Add(vehicle.VehicleId, vehicle);
        }
        
    }
    
    // Returns the dictionary of reserved vehicles.
    public static Dictionary<int, Vehicle> GetReservedVehicles()
    {
        return _reservedVehicles;
    }
    
    // Adds a maintenance record for a vehicle.
    public static void AddService(MaintenanceRecord service)
    {
        _maintenanceRecords.Add(service.Id, service);
    }

    // Displays the service details for a specific vehicle by its ID.
    public static void DisplayService(int vehicleId)
    {
        Console.WriteLine($"Vehicle Id: {_maintenanceRecords[vehicleId].Id}\n" +
                          $"Service Type: {_maintenanceRecords[vehicleId].ServiceType}\n" +
                          $"Date: {_maintenanceRecords[vehicleId].Date:d}");
    }
    
    // Sells a vehicle, removes it from the vehicle list, and logs the sale.
    public static void SellVehicle(Vehicle vehicle)
    {
        DateTime dateAdded = _dateAddedToStock[vehicle.VehicleId];
        _dateAddedToStock.Remove(vehicle.VehicleId);

        // Create a sale record and add it to the sale records list.
        SaleRecord salerecord = new SaleRecord(vehicle, vehicle.Price, dateAdded);
        _SaleRecords.Add(salerecord);

        // Remove the vehicle from the vehicles list.
        _vehicles.Remove(vehicle);
    }
}
