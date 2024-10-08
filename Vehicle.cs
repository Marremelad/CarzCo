using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarzCo
{
    public abstract class Vehicle : IDrivable
    {
    public string Model { get; set; }
    public string Make { get; set; }
    public string FuelType { get; set; }
    public int MaxSpeed { get; set; }
        internal Vehicle(string make, string model, string fuelType, int maxSpeed)
        {
            Make = make;
            Model = model;
            FuelType = fuelType;
            MaxSpeed = maxSpeed;
        }
        public  abstract void Drive();
    }
}
