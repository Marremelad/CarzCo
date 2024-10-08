namespace CarzCo;

public abstract class Manager
{
    private static List<Vehicle> _vehicles = new List<Vehicle>();


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
            Console.WriteLine($"{vehicle.Make} {vehicle.Model} - Fuel Type: {vehicle.FuelType}, Max Velocity: {vehicle.MaxSpeed} km/h");
        }
    }
}