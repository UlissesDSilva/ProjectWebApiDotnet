using ProjectWebApiDotnet.Models.Entites;

namespace ProjectWebApiDotnet.Models.ViewModels
{
    public class SellerFromViewModel
    {
        public Seller Seller { get; set; }

        public IEnumerable<Department> Departments { get; set; }
    }
}
