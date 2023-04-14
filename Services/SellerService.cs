using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectWebApiDotnet.Models.Entites;
using ProjectWebApiDotnet.Services.Exceptions;

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
            return await _context.Seller.Include(d => d.Department).ToListAsync();
        }

        public async Task<Seller> FindSellerById(int? id)
        {
            return await _context.Seller.Include(d => d.Department).FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public async void Delete(int id)
        {
            var seller = _context.Seller.Where(x => x.Id == id).FirstOrDefault();
            if (seller == null)
            {
                throw new NotFoundException("Seller not found");
            } else
            {
                _context.Seller.Remove(seller);
                _context.SaveChanges();
            }
        }

        public void Edit(Seller seller)
        {
            if (!_context.Seller.Any(x => x.Id == seller.Id))
            {
                throw new NotFoundException("Seller not found");
            }

            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                // Isso faz com que o controller se preocupe com "Exceptions" apenas da camada de serviço
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}
