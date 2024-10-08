using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarzCo
{
    public class Bus : Vehicle
    {
        public int PassengerCapacity { get; set; }

        public Bus(string make, string model, int passengerCapacity, string fuelType, int maxSpeed) :
            base(make, model, fuelType, maxSpeed)
        {
            PassengerCapacity = passengerCapacity;
        }
        public override void Drive()
        {
            Console.WriteLine($"The bus is driving.");
        }
        public override string ToString()
        {
            return $"Make: {Make},  Model: {Model},  Passenger capacity: {PassengerCapacity}.";
        }
    }
}
