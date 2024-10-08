namespace CarzCo;

class Program
{
    static void Main(string[] args)
    {
        List<Vehicle> listOfVehicles =
        [
            new Car("Honda", "Civic", 4, FuelType.Bensin, 500),
            new Car("Honda", "Civic", 4, FuelType.Diesel, 500),
            new Car("Honda", "Civic", 4, FuelType.Ethanol, 500)
        ];

        foreach (var vehicle in listOfVehicles)
        {
            Console.WriteLine(vehicle.VehicleId);
        }
    }
}