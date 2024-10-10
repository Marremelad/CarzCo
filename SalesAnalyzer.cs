namespace CarzCo
{
    // Generic class for analyzing sales records of a specific type of vehicle.
    internal class SalesAnalyzer<T> where T : Vehicle
    {
        // Filters the sale records to include only those of the specified vehicle type.
        private static List<SaleRecord> FilterVehicleType(List<SaleRecord> records)
        {
            // Check if the specified type is not the base Vehicle type.
            if (typeof(T) != typeof(Vehicle))
            {
                // Filter records to include only those matching the specified vehicle type.
                records = records.Where(v => v.Vehicle.GetType() == typeof(T)).ToList();
            }
            return records;
        }

        // Calculates the total revenue from the filtered sale records.
        public static double TotalRevenue(List<SaleRecord> records)
        {
            records = FilterVehicleType(records);
            return records.Sum(r => r.SellPrice); // Sum the selling prices of the filtered records.
        }

        // Calculates the average selling price from the filtered sale records.
        public static double AveragePrice(List<SaleRecord> records)
        {
            records = FilterVehicleType(records);
            return records.Average(r => r.SellPrice); // Compute the average selling price of the filtered records.
        }
    }
}