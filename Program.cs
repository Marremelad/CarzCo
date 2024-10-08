namespace CarzCo;

class Program
{
    static void Main(string[] args)
    {
        // Car car = new Car("Honda", "Civic", 4, "Petrol", 500);

        List<Vehicle> listOfVehicles =
        [
            new Car("Honda", "Civic", 4, "Petrol", 500),
            new Car("Honda", "Civic", 4, "Petrol", 500),
            new Car("Honda", "Civic", 4, "Petrol", 500)
        ];
        
        Manager.AddVehicle(listOfVehicles);
        Manager.DisplayVehicles();
    }
}