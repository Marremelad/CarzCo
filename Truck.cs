namespace CarzCo;

public class Truck : Vehicle
{
    public int NumberOfAxels { get; set; }

    public Truck(string make, string model, int numberOfAxels) :
        base(make, model)
    {
        NumberOfAxels = numberOfAxels;
    }
}