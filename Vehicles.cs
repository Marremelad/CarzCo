namespace CarzCo;

// Vehicles class.
public abstract class Vehicle : IDrivable
{
    private static int _id;
    public int VehicleId { get; set; }
    public string Model { get; set; }
    public string Make { get; set; }
    public Color Color { get; set; }
    public FuelType FuelType { get; set; }
    public int MaxSpeed { get; set; }
    public int Price { get; set; }
    
    internal Vehicle(string make, string model, Color color, FuelType fuelType, int maxSpeed, int price)
    {
        VehicleId = _id;
        _id++;
        
        Make = make;
        Model = model;
        Color = color;
        FuelType = fuelType;
        MaxSpeed = maxSpeed;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Color} {Make} {Model}";
    }
    
    public abstract string DisplayAttributes();
    
    public  abstract void Drive();
}

// Car class.
public class Car : Vehicle
{
    public int Doors { get; set; }
    public Car(string make, string model, Color color, int doors, FuelType fuelType, int maxSpeed, int price) : 
        base(make, model, color, fuelType, maxSpeed, price) {
        Doors = doors;
    }
    
    public override void Drive()
    {
        Console.WriteLine($"The car is driving.");
    }
    
    public override string DisplayAttributes()
    {
        return $"\n  {Make} {Model}\n  Color: {Color}\n  Number of doors: {Doors}\n  Fuel Type: {FuelType}\n  Max Speed: {MaxSpeed}\n  Price: {Price:c}";
    }
}

// Motorcycle class.
public class Motorcycle : Vehicle
{
    public bool HasSideCart { get; set; }

    public Motorcycle(string make, string model, Color color, bool hasSideCart, FuelType fuelType, int maxSpeed, int price) :
        base(make, model, color, fuelType, maxSpeed, price)
    {
        HasSideCart = hasSideCart;
    }
    
    public override void Drive()
    {
        Console.WriteLine($"The motorcycle is driving.");
    }
    
    public override string DisplayAttributes()
    {
        string hasSideCart = HasSideCart ? "Yes" : "No";
        return $"\n  {Make} {Model}\n  Color: {Color}\n  Has a side cart: {hasSideCart}\n  Fuel Type: {FuelType}\n  Max Speed: {MaxSpeed}\n  Price: {Price:c}";
    }
}

// Truck class.
public class Truck : Vehicle
{
    public int NumberOfAxels { get; set; }

    public Truck(string make, string model, Color color, int numberOfAxels, FuelType fuelType, int maxSpeed, int price) :
        base(make, model, color, fuelType, maxSpeed, price)
    {
        NumberOfAxels = numberOfAxels;
    }
    
    public override void Drive()
    {
        Console.WriteLine($"The truck is driving.");
    }
    
    public override string DisplayAttributes()
    {
        return $"\n  {Make} {Model}\n  Color: {Color}\n  Number of Axels: {NumberOfAxels}\n  Fuel Type: {FuelType}\n  Max Speed: {MaxSpeed}\n  Price: {Price:c}";
    }
}

// Bus class.
public class Bus : Vehicle
{
    public int PassengerCapacity { get; set; }

    public Bus(string make, string model, Color color, int passengerCapacity, FuelType fuelType, int maxSpeed, int price) :
        base(make, model, color, fuelType, maxSpeed, price)
    {
        PassengerCapacity = passengerCapacity;
    }
    public override void Drive()
    {
        Console.WriteLine($"The bus is driving.");
    }
    
    public override string DisplayAttributes()
    {
        return $"\n  {Make} {Model}\n  Color: {Color}\n  Passenger capacity: {PassengerCapacity}\n  Fuel Type: {FuelType}\n  Max Speed: {MaxSpeed}\n  Price: {Price:c}";
    }
}

// Boat class.
public class Boat : Vehicle
{
    public int PassengerCapacity { get; set; }

    public Boat(string make, string model, Color color, int passengerCapacity, FuelType fuelType, int maxSpeed, int price) :
        base(make, model, color, fuelType, maxSpeed, price)
    {
        PassengerCapacity = passengerCapacity;
    }
    public override void Drive()
    {
        Console.WriteLine($"The boat is driving.");
    }
    
    public override string DisplayAttributes()
    {
        return $"\n  {Make} {Model}\n  Color: {Color}\n  Passenger capacity: {PassengerCapacity}\n  Fuel Type: {FuelType}\n  Max Speed: {MaxSpeed}\n  Price: {Price:c}";
    }
}