namespace CarzCo;

class Program
{
    static void Main(string[] args)
    {
        // Lägg till några fordon
        List<Vehicle> vehicles = new List<Vehicle>
    {
        new Car("Volvo", "V60", 5, "Diesel", 200),
        new Motorcycle("Harley-Davidson", "Street 750", false, "Bensin", 180),
        new Truck("Scania", "R500", 3, "Diesel", 160),
        new Bus("Mercedes", "Citaro", 40, "Hybrid", 100),
        new Boat("Yamaha", "242X", 8, "Bensin", 45)
    };
        // Skriv ut alla fordon
        Console.WriteLine("Alla fordon:");
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle);
        }

        // Filtrera och skriv ut bara bilar
        Console.WriteLine("\nBara bilar:");
        var cars = FilterVehicles<Car>(vehicles);
        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }

        // Sälj ett fordon
        var vehicleToSell = vehicles.Find(v => v.Make == "Toyota");
        if (vehicleToSell != null)
        {
            SellVehicle(vehicles, vehicleToSell);
        }

        // Skriv ut uppdaterad lista
        Console.WriteLine("\nUppdaterad lista efter försäljning:");
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle);
        }
        static List<T> FilterVehicles<T>(List<Vehicle> vehicles) where T : Vehicle
        {
            return vehicles.OfType<T>().ToList();
        }

        static void SellVehicle(List<Vehicle> vehicles, Vehicle vehicle)
        {
            Console.WriteLine($"\nSäljer fordon: {vehicle}");
            vehicles.Remove(vehicle);
        }
    }
}