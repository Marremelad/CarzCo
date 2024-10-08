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
        internal Vehicle(string model, string make)
        {
            Model = model;
            Make = make;
        }
    public  abstract void Drive();
    }
}
