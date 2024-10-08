namespace CarzCo;

class Program
{
    static void Main(string[] args)
    {
        List<Vehicle> vehicles = new List<Vehicle>
    {
        new Car("Volvo", "V60", 5, "Diesel", 200),
        new Motorcycle("Harley-Davidson", "Street 750", false, "Bensin", 180),
        new Truck("Scania", "R500", 3, "Diesel", 160),
        new Bus("Mercedes", "Citaro", 40, "Hybrid", 100),
        new Boat("Yamaha", "242X", 8, "Bensin", 45)
    };

        Console.WriteLine("Alla fordon:");
        PrintVehicles(vehicles);

        Console.WriteLine("\nFordon som går på diesel och har en maxhastighet över 150 km/h:");
        var filteredVehicles = FilterVehicles(vehicles, v => v.FuelType == "Diesel" && v.MaxSpeed > 150);
        PrintVehicles(filteredVehicles);

        Console.WriteLine("\nFordon sorterade efter maxhastighet (fallande):");
        var sortedVehicles = vehicles.OrderByDescending(v => v.MaxSpeed).ToList();
        PrintVehicles(sortedVehicles);

        Console.WriteLine("\nDiesel vehicles in alphabetical order:");
        var dieselSort = vehicles.Where(v => v.FuelType == "Diesel").OrderBy(v => v.Make).ToList();
        PrintVehicles(dieselSort);
    }

    static List<Vehicle> FilterVehicles(List<Vehicle> vehicles, Func<Vehicle, bool> criteria)
    {
        return vehicles.Where(criteria).ToList();
    }

    static void PrintVehicles(List<Vehicle> vehicles)
    {
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"{vehicle.Make} {vehicle.Model} - Bränsle: {vehicle.FuelType}, Max hastighet: {vehicle.MaxSpeed} km/h");
        }
    }
}