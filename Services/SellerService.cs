using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectWebApiDotnet.Models.Entites;

namespace ProjectWebApiDotnet.Services
{
    public class SellerService
    {
        private readonly Context _context;

        public SellerService(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Seller>> FindAllSellers() 
        { 
            return await _context.Seller.ToListAsync();
        }

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }
    }
}
