using BulkyBook.Business.Contracts.IService;
using BulkyBook.DataAccess.Data;
using BulkyBook.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
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
                 await _categoryService.AddAsync(category);
                await _categoryService.SaveChangesAsync();

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
            var category = await _categoryService.GetAsync(x=>x.Id == id);
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
                await _categoryService.UpdateAsync(category);
                await _categoryService.SaveChangesAsync();
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
            var category = await _categoryService.GetAsync(x=>x.Id == id);
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePOST(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var category = await _categoryService.GetAsync(x => x.Id == id);
            if(category is null)
            {
                return NotFound();

            }
            _categoryService.Remove(category);
            await _categoryService.SaveChangesAsync();

            TempData["success"] = "Category deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
