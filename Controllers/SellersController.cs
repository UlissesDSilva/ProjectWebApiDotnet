using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectWebApiDotnet.Models.Entites;
using ProjectWebApiDotnet.Models.ViewModels;
using ProjectWebApiDotnet.Services;
using ProjectWebApiDotnet.Services.Exceptions;
using System.Diagnostics;

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

        public async Task<IActionResult> Delete(int id)
        {
            var seller = await _sellerService.FindSellerById(id);
            return seller != null ? View(seller) : RedirectToAction(nameof(Error), new { message = "Seller not found" });
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Remove(int id)
        {
            _sellerService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var seller = await _sellerService.FindSellerById(id);
            if(seller == null)
            {
                return RedirectToAction(nameof(Error),  new { message = "Seller not found" });
            }
            return View(seller);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id is null" });
            }

            var listDepartments = await _departmentService.FindAllDepartments();
            var seller = await _sellerService.FindSellerById(id);
            
            if (seller == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Seller not found" });
            }

            var viewModelSeller = new SellerFromViewModel { Seller = seller, Departments = listDepartments };
            return View(viewModelSeller);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                _sellerService.Edit(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { mensage = e });
            }
            
        }

        public IActionResult Error(string msn = "Problem in request")
        {
            var viewModelError = new ErrorViewModel
            {
                Message = msn,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModelError);
        }
    }
}
