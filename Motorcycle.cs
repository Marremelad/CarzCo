namespace CarzCo;

public class Motorcycle : Vehicle
{
    public bool HasSideCart { get; set; }

    public Motorcycle(string make, string model, bool hasSideCart) :
        base(make, model)
    {
        HasSideCart = hasSideCart;
    }
    public override void Drive()
    {
        Console.WriteLine($"The motorcycle is driving.");
    }
    public override string ToString()
    {
        return $"Model: {Model},  Make: {Make},  Has sidecart: {HasSideCart}.";
    }
}