namespace CarzCo;

// Vehicles class.
public abstract class Vehicle : IDrivable
{
    private static int _id; // Static variable to track vehicle IDs.
    public int VehicleId { get; set; } // Unique identifier for the vehicle.
    public string Model { get; set; } // Model of the vehicle.
    public string Make { get; set; } // Make of the vehicle.
    public Color Color { get; set; } // Color of the vehicle.
    public FuelType FuelType { get; set; } // Fuel type used by the vehicle.
    public int MaxSpeed { get; set; } // Maximum speed of the vehicle.
    public int Price { get; set; } // Price of the vehicle.
    
    // Constructor for initializing the vehicle's properties.
    internal Vehicle(string make, string model, Color color, FuelType fuelType, int maxSpeed, int price)
    {
        VehicleId = _id; // Assign current ID to the vehicle.
        _id++; // Increment ID for the next vehicle.
        
        Make = make;
        Model = model;
        Color = color;
        FuelType = fuelType;
        MaxSpeed = maxSpeed;
        Price = price;
    }

    // Override ToString to display vehicle information.
    public override string ToString()
    {
        return $"{Color} {Make} {Model}";
    }
    
    // Abstract method for displaying vehicle attributes.
    public abstract string DisplayAttributes();
    
    // Method from IDrivable interface to drive the vehicle.
    public abstract void Drive();
}

// Car class.
public class Car : Vehicle
{
    public int Doors { get; set; } // Number of doors in the car.
    
    // Constructor for initializing car properties.
    public Car(string make, string model, Color color, int doors, FuelType fuelType, int maxSpeed, int price) : 
        base(make, model, color, fuelType, maxSpeed, price) {
        Doors = doors;
    }
    
    // Implementation of Drive method for the car.
    public override void Drive()
    {
        Console.WriteLine($"The car is driving.");
    }
    
    // Implementation of DisplayAttributes for the car.
    public override string DisplayAttributes()
    {
        return $"\n  {Make} {Model}\n  Color: {Color}\n  Number of doors: {Doors}\n  Fuel Type: {FuelType}\n  Max Speed: {MaxSpeed}\n  Price: {Price:c}";
    }
}

// Motorcycle class.
public class Motorcycle : Vehicle
{
    public bool HasSideCart { get; set; } // Indicates if the motorcycle has a side cart.

    // Constructor for initializing motorcycle properties.
    public Motorcycle(string make, string model, Color color, bool hasSideCart, FuelType fuelType, int maxSpeed, int price) :
        base(make, model, color, fuelType, maxSpeed, price)
    {
        HasSideCart = hasSideCart;
    }
    
    // Implementation of Drive method for the motorcycle.
    public override void Drive()
    {
        Console.WriteLine($"The motorcycle is driving.");
    }
    
    // Implementation of DisplayAttributes for the motorcycle.
    public override string DisplayAttributes()
    {
        string hasSideCart = HasSideCart ? "Yes" : "No"; // Check if it has a side cart.
        return $"\n  {Make} {Model}\n  Color: {Color}\n  Has a side cart: {hasSideCart}\n  Fuel Type: {FuelType}\n  Max Speed: {MaxSpeed}\n  Price: {Price:c}";
    }
}

// Truck class.
public class Truck : Vehicle
{
    public int NumberOfAxels { get; set; } // Number of axles in the truck.

    // Constructor for initializing truck properties.
    public Truck(string make, string model, Color color, int numberOfAxels, FuelType fuelType, int maxSpeed, int price) :
        base(make, model, color, fuelType, maxSpeed, price)
    {
        NumberOfAxels = numberOfAxels;
    }
    
    // Implementation of Drive method for the truck.
    public override void Drive()
    {
        Console.WriteLine($"The truck is driving.");
    }
    
    // Implementation of DisplayAttributes for the truck.
    public override string DisplayAttributes()
    {
        return $"\n  {Make} {Model}\n  Color: {Color}\n  Number of Axels: {NumberOfAxels}\n  Fuel Type: {FuelType}\n  Max Speed: {MaxSpeed}\n  Price: {Price:c}";
    }
}

// Bus class.
public class Bus : Vehicle
{
    public int PassengerCapacity { get; set; } // Number of passengers the bus can carry.

    // Constructor for initializing bus properties.
    public Bus(string make, string model, Color color, int passengerCapacity, FuelType fuelType, int maxSpeed, int price) :
        base(make, model, color, fuelType, maxSpeed, price)
    {
        PassengerCapacity = passengerCapacity;
    }

    // Implementation of Drive method for the bus.
    public override void Drive()
    {
        Console.WriteLine($"The bus is driving.");
    }
    
    // Implementation of DisplayAttributes for the bus.
    public override string DisplayAttributes()
    {
        return $"\n  {Make} {Model}\n  Color: {Color}\n  Passenger capacity: {PassengerCapacity}\n  Fuel Type: {FuelType}\n  Max Speed: {MaxSpeed}\n  Price: {Price:c}";
    }
}

// Boat class.
public class Boat : Vehicle
{
    public int PassengerCapacity { get; set; } // Number of passengers the boat can carry.

    // Constructor for initializing boat properties.
    public Boat(string make, string model, Color color, int passengerCapacity, FuelType fuelType, int maxSpeed, int price) :
        base(make, model, color, fuelType, maxSpeed, price)
    {
        PassengerCapacity = passengerCapacity;
    }

    // Implementation of Drive method for the boat.
    public override void Drive()
    {
        Console.WriteLine($"The boat is driving.");
    }
    
    // Implementation of DisplayAttributes for the boat.
    public override string DisplayAttributes()
    {
        return $"\n  {Make} {Model}\n  Color: {Color}\n  Passenger capacity: {PassengerCapacity}\n  Fuel Type: {FuelType}\n  Max Speed: {MaxSpeed}\n  Price: {Price:c}";
    }
}
