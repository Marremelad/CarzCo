namespace CarzCo;

public class Truck : Vehicle
{
    public int NumberOfAxels { get; set; }

    public Truck(string make, string model, int numberOfAxels) :
        base(make, model)
    {
        NumberOfAxels = numberOfAxels;
    }
    public override void Drive()
    {
        Console.WriteLine($"The truck is driving.");
    }
    public override string ToString()
    {
        return $"Make: {Make},  Model: {Model},  Axels: {NumberOfAxels}.";
    }
}