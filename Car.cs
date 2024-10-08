using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarzCo
{
    public class Car : Vehicle
    {
        public int Doors { get; set; }
        public Car(string make, string model, int doors) : base(make, model) {
            Doors = doors;
        }
        public override void Drive()
        {
            Console.WriteLine($"The car is driving.");
        }
        public override string ToString()
        {
            return $"Model: {Model},  Make: {Make},  Doors: {Doors}.";
        }
    }
}
