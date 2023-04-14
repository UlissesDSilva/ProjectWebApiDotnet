using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjectWebApiDotnet.Models.Entites
{
    public class Seller
    {
        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }

        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

        public void AddSales(SalesRecord sale)
        {
            SalesRecords.Add(sale);
        }

        public void RemoveSale(SalesRecord sale)
        {
            SalesRecords.Remove(sale);
        }

        public double TotalSales(DateTime init, DateTime finish)
        {
            return SalesRecords.Where(s => s.Date >= init && s.Date <= finish).Sum(s => s.Amount);
        }
    }
}
