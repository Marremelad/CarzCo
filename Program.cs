using Spectre.Console;

namespace CarzCo;

class Program
{
    static void Main(string[] args)
    {
        List<Vehicle> vehiclesList =
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