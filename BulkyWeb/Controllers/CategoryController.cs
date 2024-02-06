using BulkyBook.Business.Contracts.IService;
using BulkyBook.Business.Repositories.UnitOfWork;
using BulkyBook.DataAccess.Data;
using BulkyBook.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _unitOfWork.CategoryService.GetAllAsync();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("", "Name and Category not be same");
            }
            if (ModelState.IsValid)
            {
                 await _unitOfWork.CategoryService.AddAsync(category);
                await _unitOfWork.SaveChangesAsync();

            }
            TempData["success"] = "Category created successfully";
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(long? id)
        {
            if(id is null || id == 0)
            {
                return NotFound();
            }
            var category = await _unitOfWork.CategoryService.GetAsync(x=>x.Id == id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if(category is null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _unitOfWork.CategoryService.UpdateAsync(category);
                await _unitOfWork.SaveChangesAsync();
            }
            TempData["success"] = "Category Updated successfully";

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            var category = await _unitOfWork.CategoryService.GetAsync(x=>x.Id == id);
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePOST(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var category = await _unitOfWork.CategoryService.GetAsync(x => x.Id == id);
            if(category is null)
            {
                return NotFound();

            }
            _unitOfWork.CategoryService.Remove(category);
            await _unitOfWork.SaveChangesAsync();

            TempData["success"] = "Category deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
