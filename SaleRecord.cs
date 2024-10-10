namespace CarzCo
{
    // Class representing a record of a vehicle sale.
    public class SaleRecord
    {
        // The vehicle being sold.
        public Vehicle Vehicle { get; set; }

        // The price at which the vehicle was sold.
        public int SellPrice { get; set; }

        // The date when the vehicle was bought.
        public DateTime BuyDate { get; set; }

        // The date when the vehicle was sold, defaulting to the current date and time.
        public DateTime SellDate { get; set; } = DateTime.Now;

        // Constructor for initializing a sale record with a vehicle, sale price, and purchase date.
        public SaleRecord(Vehicle vehicle, int sellPrice, DateTime buyDate)
        {
            Vehicle = vehicle;
            SellPrice = sellPrice;
            BuyDate = buyDate;
        }
    }
}