namespace CarzCo;

// Vehicles class.
public abstract class Vehicle : IDrivable
{
    private static int _id;

    public int VehicleId { get; set; }
    public string Model { get; set; }
    public string Make { get; set; }
    public FuelType FuelType { get; set; }
    public int MaxSpeed { get; set; }
    internal Vehicle(string make, string model, FuelType fuelType, int maxSpeed)
    {
        VehicleId = _id;
        _id++;
        
        Make = make;
        Model = model;
        FuelType = fuelType;
        MaxSpeed = maxSpeed;
    }

    public override string ToString()
    {
        return $" {Make} {Model}";
    }
    public  abstract void Drive();
}

// Car class.
public class Car : Vehicle
{
    public int Doors { get; set; }
    public Car(string make, string model, int doors, FuelType fuelType, int maxSpeed) : 
        base(make, model, fuelType, maxSpeed) {
        Doors = doors;
    }
    public override void Drive()
    {
        Console.WriteLine($"The car is driving.");
    }
}

// Motorcycle class.
public class Motorcycle : Vehicle
{
    public bool HasSideCart { get; set; }

    public Motorcycle(string make, string model, bool hasSideCart, FuelType fuelType, int maxSpeed) :
        base(make, model, fuelType, maxSpeed)
    {
        HasSideCart = hasSideCart;
    }
    public override void Drive()
    {
        Console.WriteLine($"The motorcycle is driving.");
    }
}

// Truck class.
public class Truck : Vehicle
{
    public int NumberOfAxels { get; set; }

    public Truck(string make, string model, int numberOfAxels, FuelType fuelType, int maxSpeed) :
        base(make, model, fuelType, maxSpeed)
    {
        NumberOfAxels = numberOfAxels;
    }
    public override void Drive()
    {
        Console.WriteLine($"The truck is driving.");
    }
}

// Bus class.
public class Bus : Vehicle
{
    public int PassengerCapacity { get; set; }

    public Bus(string make, string model, int passengerCapacity, FuelType fuelType, int maxSpeed) :
        base(make, model, fuelType, maxSpeed)
    {
        PassengerCapacity = passengerCapacity;
    }
    public override void Drive()
    {
        Console.WriteLine($"The bus is driving.");
    }
}

// Boat class.
public class Boat : Vehicle
{
    public int PassengerCapacity { get; set; }

    public Boat(string make, string model, int passengerCapacity, FuelType fuelType, int maxSpeed) :
        base(make, model, fuelType, maxSpeed)
    {
        PassengerCapacity = passengerCapacity;
    }
    public override void Drive()
    {
        Console.WriteLine($"The boat is driving.");
    }
}