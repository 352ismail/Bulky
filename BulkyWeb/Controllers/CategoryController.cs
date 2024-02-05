using BulkyWeb.Contracts.IService;
using BulkyWeb.Data;
using BulkyWeb.Generics;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoryService _categoryService;
        public CategoryController(ApplicationDbContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAll();
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
                var result = await _categoryService.Create(category);
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
            var category = await _categoryService.GetById(id ?? 0);
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
                var result = await _categoryService.Update(category);
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
            var category = await _categoryService.GetById(id ?? 0);
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePOST(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var result = await _categoryService.Delete(id);
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
