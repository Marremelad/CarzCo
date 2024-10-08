using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarzCo
{
    public abstract class Vehicle
    {
    public string Model { get; set; }
    public string Make { get; set; }
        internal Vehicle(string make, string model)
        {
            Make = make;
            Model = model;
            
        }
    }
}
