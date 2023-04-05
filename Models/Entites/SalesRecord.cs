using ProjectWebApiDotnet.Models.Enum;

namespace ProjectWebApiDotnet.Models.Entites
{
    public class SalesRecord
    {
        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus salesStatus, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            SalesStatus = salesStatus;
            Seller = seller;
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double Amount { get; set; }

        public SaleStatus SalesStatus { get; set; }

        public Seller Seller { get; set; }
    }
}
