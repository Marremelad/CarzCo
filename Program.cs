namespace CarzCo;

class Program
{
    static void Main(string[] args)
    {
        Car car = new Car("Toyota", "Supra", 4, FuelType.Bensin, 500);

        MaintenanceRecord service = new MaintenanceRecord(car.VehicleId, ServiceType.Oil);
        
        Manager.AddService(service);
        Manager.DisplayService(car.VehicleId);


    }
}