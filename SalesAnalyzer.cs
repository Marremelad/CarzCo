namespace CarzCo
{
    internal class SalesAnalyzer
    {
        protected List<SaleRecord> FilterVehicleType<T>(List<SaleRecord> records) where T : Vehicle
        {
            if (typeof(T) != typeof(Vehicle))
            {
                records = records.Where(v => v.Vehicle.GetType() == typeof(T)).ToList();
            }
            return records;
            
        }
        public double TotalRevenue<T>(List<SaleRecord> records) where T : Vehicle
        {
            records = FilterVehicleType<T>(records);
            return records.Sum(r => r.SellPrice);
        }
        public double AveragePrice<T>(List<SaleRecord> records) where T : Vehicle
        {   
            records = FilterVehicleType<T>(records);
            return records.Average(r => r.SellPrice);
        }
    }
}
