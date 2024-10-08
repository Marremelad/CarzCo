﻿namespace CarzCo;

public class Motorcycle : Vehicle
{
    public bool HasSideCart { get; set; }

    public Motorcycle(string make, string model, bool hasSideCart, string fuelType, int maxSpeed) :
        base(make, model, fuelType, maxSpeed)
    {
        HasSideCart = hasSideCart;
    }
    public override void Drive()
    {
        Console.WriteLine($"The motorcycle is driving.");
    }
    public override string ToString()
    {
        return $"Make: {Make},  Model: {Model}, Has sidecart: {HasSideCart}.";
    }
}