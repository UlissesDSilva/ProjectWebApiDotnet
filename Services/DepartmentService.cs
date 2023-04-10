using Microsoft.EntityFrameworkCore;
using ProjectWebApiDotnet.Models.Entites;

namespace ProjectWebApiDotnet.Services
{
    public class DepartmentService
    {
        private readonly Context _context;

        public DepartmentService(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> FindAllDepartments()
        {
            return await _context.Department.OrderBy(d => d.Name).ToListAsync();
        }
    }
}
