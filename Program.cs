namespace CarzCo;

class Program
{
    static void Main(string[] args)
    {
        // Skapa några fordon
        Car car = new Car("Volvo", "V60", 5);
        Motorcycle motorcycle = new Motorcycle("Harley-Davidson", "Street 750", false);
        Truck truck = new Truck("Scania", "R500", 3);

        // Skriv ut alla fordon
        Console.WriteLine("Alla fordon:");
        Console.WriteLine(car);
        Console.WriteLine(motorcycle);
        Console.WriteLine(truck);

        // Filtrera och skriv ut bara bilar
        Console.WriteLine("\nBara bilar:");
        if (car is Car)
        {
            Console.WriteLine(car);
        }

        // Kör alla fordon
        Console.WriteLine("\nKör alla fordon:");
        car.Drive();
        motorcycle.Drive();
        truck.Drive();
    }
}