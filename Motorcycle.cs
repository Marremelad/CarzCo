namespace CarzCo;

public class Motorcycle : Vehicle
{
    public bool HasSideCart { get; set; }

    public Motorcycle(string model, string make, bool hasSideCart) :
        base(make, model)
    {
        HasSideCart = hasSideCart;
    }
}