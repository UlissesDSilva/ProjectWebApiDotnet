using System.Linq;

namespace ProjectWebApiDotnet.Models.Entites
{
    public class Department
    {
        public Department()
        {
        }

        public Department(int id, string? name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string? Name { get; set; } = string.Empty;

        public ICollection<Seller> Selletrs { get; set; } = new List<Seller>();

        public void AddSeller(Seller seller)
        {
            Selletrs.Add(seller);
        }

        public double TotalSales(DateTime init, DateTime finish)
        {
            return Selletrs.Sum(s => s.TotalSales(init, finish));
        }
    }
}