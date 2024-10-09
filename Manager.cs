using Spectre.Console;

namespace CarzCo;

public abstract class Manager
{
    private static List<Vehicle> _vehicles = new List<Vehicle>();

    private static Dictionary<int, Vehicle> _reservedVehicles = new Dictionary<int, Vehicle>();
    
    private static Dictionary<int, MaintenanceRecord> _maintenanceRecords = new Dictionary<int, MaintenanceRecord>();

    private static Dictionary<int, DateTime> _dateAddedToStock = new Dictionary<int, DateTime>();
    
    public static List<SaleRecord> _SaleRecords = new List<SaleRecord>();
    
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
    
    public static List<Vehicle> GetVehicles()
    {
        List<Vehicle> availableVehicles = new List<Vehicle>();
        foreach (Vehicle vehicle in _vehicles)
        {
            if (_reservedVehicles.ContainsValue(vehicle)) continue;
            else availableVehicles.Add(vehicle);
        }
        return availableVehicles;
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
    
    public static Dictionary<int, Vehicle> GetReservedVehicles()
    {
        return _reservedVehicles;
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
    
    public static void SellVehicle(Vehicle vehicle, int price)
    {
        DateTime dateAdded = _dateAddedToStock[vehicle.VehicleId];
        _dateAddedToStock.Remove(vehicle.VehicleId);

        SaleRecord salerecord = new SaleRecord(vehicle, price, dateAdded);
        _SaleRecords.Add(salerecord);

        _vehicles.Remove(vehicle);
    }
}
