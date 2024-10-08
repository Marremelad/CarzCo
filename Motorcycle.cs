namespace CarzCo;

public class Motorcycle : Vehicle
{
    public bool HasSideCart { get; set; }

    public Motorcycle(string make, string model, bool hasSideCart) :
        base(make, model)
    {
        HasSideCart = hasSideCart;
    }
}