namespace CarzCo;

class Program
{
    static void Main()
    {
        // List of various vehicles (cars, motorcycles, trucks, buses, boats) being created and added to the list.
        List<Vehicle> vehiclesList =
        [
            new Car("Honda", "Civic", Color.Blue, 4, FuelType.Petrol, 500, 400000),
            new Car("Toyota", "Yaris", Color.Black, 4, FuelType.Petrol, 500, 300000),
            new Car("Hyundai", "I30 N", Color.Grey, 4, FuelType.Petrol, 500, 650000),

            new Motorcycle("Kawasaki", "Ninja", Color.Red, false, FuelType.Petrol, 300, 199000),
            new Motorcycle("BMW", "S1000RR", Color.Green, false, FuelType.Petrol, 300, 250000),
            new Motorcycle("Yamaha", "R9", Color.Silver, false, FuelType.Petrol, 300, 200000),

            new Truck("Ford", "Raptor", Color.Yellow, 4, FuelType.Diesel, 200, 700000),
            new Truck("Dodge", "Ram", Color.White, 6, FuelType.Diesel, 200, 550000),
            new Truck("Toyota", "Hilux", Color.Orange, 8, FuelType.Diesel, 200, 500000),
            
            new Bus("Volvo", "GTB", Color.Red, 100, FuelType.Diesel, 110, 700000),
            new Bus("Volvo", "GTB", Color.Yellow, 100, FuelType.Diesel, 110, 700000),
            new Bus("Volvo", "GTB", Color.Black, 100, FuelType.Diesel, 110, 700000),

            new Boat("Big", "Boat", Color.Silver, 100, FuelType.Diesel, 50, 5000000),
            new Boat("Medium", "Boat", Color.Gold, 50, FuelType.Diesel, 50, 500000),
            new Boat("Small", "Boat", Color.Brown, 10, FuelType.Diesel, 50, 50000)
        ];
        
        // List of vehicles to be reserved, referencing specific indices from the vehiclesList.
        List<Vehicle> vehiclesToReserve =
        [
            vehiclesList[0],   // Reserving the Honda Civic.
            vehiclesList[3],   // Reserving the Kawasaki Ninja.
            vehiclesList[6],   // Reserving the Ford Raptor.
            vehiclesList[9],   // Reserving the Volvo GTB (Red Bus).
            vehiclesList[12],  // Reserving the Big Boat.
        ];
        
        // Adding the full list of vehicles to the system.
        Manager.AddVehicle(vehiclesList);
        
        // Reserving the selected vehicles from the vehiclesToReserve list.
        Manager.ReserveVehicle(vehiclesToReserve);
        
        // Displaying the main menu of the application.
        Menu.MainMenu();
    }
}
