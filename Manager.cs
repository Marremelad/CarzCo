namespace CarzCo;

public abstract class Manager
{
    private static List<Vehicle> _vehicles =
    [
        new Car("Honda", "Civic", 4, FuelType.Petrol, 500),
        new Car("Toyota", "Yaris", 4, FuelType.Petrol, 500),
        new Car("Hyundai", "I30 N", 4, FuelType.Petrol, 500),

        new Motorcycle("Kawasaki", "Ninja", false, FuelType.Petrol, 300),
        new Motorcycle("BMW", "S1000RR", false, FuelType.Petrol, 300),
        new Motorcycle("Yamaha", "R9", false, FuelType.Petrol, 300),

        new Truck("Ford", "Raptor", 4, FuelType.Diesel, 200),
        new Truck("Dodge", "Ram", 6, FuelType.Diesel, 200),
        new Truck("Toyota", "Hilux", 8, FuelType.Diesel, 200),

        new Boat("Big", "Boat", 100, FuelType.Diesel, 50),
        new Boat("Medium", "Boat", 50, FuelType.Diesel, 50),
        new Boat("Small", "Boat", 10, FuelType.Diesel, 50)
    ];

    private static Dictionary<int, Vehicle> _reservedVehicles = new Dictionary<int, Vehicle>()
    {
        {_vehicles[0].VehicleId, _vehicles[0]},
        {_vehicles[3].VehicleId, _vehicles[3]},
        {_vehicles[6].VehicleId, _vehicles[6]},
        {_vehicles[9].VehicleId, _vehicles[9]},
    };
    
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
                              $" {vehicle.FuelType}, Max Velocity: {vehicle.MaxSpeed} km/h\n");
        }
    }

    public static void ReserveVehicle(Vehicle vehicle)
    {
        _reservedVehicles.Add(vehicle.VehicleId, vehicle);
    }

    public static void DisplayReservedVehicles()
    {
        foreach (var vehicle in _reservedVehicles.Values)
        {
            Console.WriteLine(vehicle.Make);
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