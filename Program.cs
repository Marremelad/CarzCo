using Spectre.Console;

namespace CarzCo;

class Program
{
    static void Main(string[] args)
    {
        List<Vehicle> vehiclesList =
        [
            new Car("Honda", "Civic", Color.Blue, 4, FuelType.Petrol, 500),
            new Car("Toyota", "Yaris", Color.Black, 4, FuelType.Petrol, 500),
            new Car("Hyundai", "I30 N", Color.Grey, 4, FuelType.Petrol, 500),

            new Motorcycle("Kawasaki", "Ninja", Color.Red, false, FuelType.Petrol, 300),
            new Motorcycle("BMW", "S1000RR", Color.Green, false, FuelType.Petrol, 300),
            new Motorcycle("Yamaha", "R9", Color.Silver, false, FuelType.Petrol, 300),

            new Truck("Ford", "Raptor", Color.Yellow, 4, FuelType.Diesel, 200),
            new Truck("Dodge", "Ram", Color.White, 6, FuelType.Diesel, 200),
            new Truck("Toyota", "Hilux", Color.Orange, 8, FuelType.Diesel, 200),

            new Boat("Big", "Boat", Color.Silver, 100, FuelType.Diesel, 50),
            new Boat("Medium", "Boat", Color.Gold, 50, FuelType.Diesel, 50),
            new Boat("Small", "Boat", Color.Brown, 10, FuelType.Diesel, 50)
        ];
        
        List<Vehicle> vehiclesToReserve =
        [
            vehiclesList[0],
            vehiclesList[3],
            vehiclesList[6],
            vehiclesList[9]

        ];
        
        Manager.AddVehicle(vehiclesList);
        Manager.ReserveVehicle(vehiclesToReserve);
        
        Menu.MainMenu();
    }
}