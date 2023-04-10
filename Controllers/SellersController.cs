using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectWebApiDotnet.Models.Entites;
using ProjectWebApiDotnet.Models.ViewModels;
using ProjectWebApiDotnet.Services;

namespace ProjectWebApiDotnet.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;


        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var listSellers = await _sellerService.FindAllSellers();
            return View(listSellers);
        }

        public async Task<IActionResult> Create()
        {
            var listDepartemnts = await _departmentService.FindAllDepartments();
            var viewModel = new SellerFromViewModel{ Departments = listDepartemnts};
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
