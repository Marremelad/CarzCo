﻿namespace CarzCo
{
    public class SaleRecord
    {
        public Vehicle Vehicle { get; set; }
        public int SellPrice { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime SellDate { get; set; } = DateTime.Now;
        public SaleRecord(Vehicle vehicle, int sellPrice, DateTime buyDate)
            {
            Vehicle = vehicle;
            SellPrice = sellPrice;
            BuyDate = buyDate;
            }
    }
}
