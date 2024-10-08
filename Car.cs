using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarzCo
{
    public class Car : Vehicle, IDrivable
    {
        public int Doors { get; set; }
        public Car(string model, string make, int doors) : base(model, make) {
            Doors = doors;
        }
        public void Drive()
        {
            Console.WriteLine($"The car is driving.");
        }
        public override string ToString()
        {
            return $"Model: {Model},  Make: {Make},  Doors: {Doors}.";
        }
    }
}
