namespace CarzCo
{
    internal class SalesAnalyzer<T> where T : Vehicle
    {
        private static List<SaleRecord> FilterVehicleType(List<SaleRecord> records)
        {
            if (typeof(T) != typeof(Vehicle))
            {
                records = records.Where(v => v.Vehicle.GetType() == typeof(T)).ToList();
            }
            return records;
        }

        public static double TotalRevenue(List<SaleRecord> records)
        {
            records = FilterVehicleType(records);
            return records.Sum(r => r.SellPrice);
        }

        public static double AveragePrice(List<SaleRecord> records)
        {
            records = FilterVehicleType(records);
            return records.Average(r => r.SellPrice);
        }
    }
}