using BulkyBook.Business.Contracts.IService;
using BulkyBook.Business.Repositories.UnitOfWork;
using BulkyBook.Models.Models.Products;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _unitOfWork.ProductService.GetAllAsync();
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _unitOfWork.ProductService.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            TempData["success"] = "Product Created successfully";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var product = await _unitOfWork.ProductService.GetAsync(x => x.Id == id);
            if(product is null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            await _unitOfWork.ProductService.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();
            TempData["success"] = "Product updated successfully";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(long? id)
        {
            var product = await _unitOfWork.ProductService.GetAsync(x => x.Id == id);
            if (product is null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(long id)
        {
            var product = await _unitOfWork.ProductService.GetAsync(x => x.Id == id);
            if(product is null)
            {
                return NotFound();
            }
             _unitOfWork.ProductService.Remove(product);
            await _unitOfWork.SaveChangesAsync();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
