using BulkyBook.Business.Contracts.IService;
using BulkyBook.Business.Repositories.UnitOfWork;
using BulkyBook.Business.ViewModel;
using BulkyBook.Models.Models;
using BulkyBook.Models.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }
        public async Task<IActionResult> Index()
        {
            var products = await _unitOfWork.ProductService.GetAllAsync(IncludeProperties: nameof(Category));
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(long? id)
        {
            var productViewModel = new ProductViewModel
            {
                CategoryList = _unitOfWork.CategoryService.GetAllAsync(IncludeProperties: nameof(Category)).Result
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                Product = new Product()
            };
            if (id is null || id == 0)
            {
                //Create
                return View(productViewModel);
            }
            //For Update
            productViewModel.Product = await _unitOfWork.ProductService.GetAsync(x => x.Id == id, IncludeProperties: nameof(Category));
            if (productViewModel.Product is null)
            {
                return NotFound();
            }
            return View(productViewModel);

        }

        //[HttpGet]
        //public async Task<IActionResult> Create()
        //{
        //    //I Am using View Model so I dont need to use View
        //    //Using ViewBag and View Data for dropdown
        //    //ViewBag.CategoryList = categories;
        //    //ViewData["CategoryList"] = categories;// Casting needed for ViewData

        //    var productViewModel = new ProductViewModel
        //    {
        //        CategoryList = _unitOfWork.CategoryService.GetAllAsync().Result
        //        .Select(x => new SelectListItem
        //        {
        //            Text = x.Name,
        //            Value = x.Id.ToString()
        //        }),
        //        Product = new Product()
        //    };
        //    return View(productViewModel);
        //}
        [HttpPost]
        public async Task<IActionResult> Upsert(ProductViewModel productViewModel, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string rootpath = _webHostEnvironment.WebRootPath;
                if (file is not null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(file.FileName);
                    string path = Path.Combine(rootpath, @"images\product", fileName + extension);
                    if (!string.IsNullOrEmpty(productViewModel.Product.ImageUrl))
                    {
                        //Delete OldImage
                        var oldImage = Path.Combine(rootpath, productViewModel.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImage))
                        {
                            System.IO.File.Delete(oldImage);
                        }
                    }
                    using FileStream fileStream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(fileStream);
                    productViewModel.Product.ImageUrl = @"\images\product\" + fileName + extension;
                }
                if (productViewModel.Product.Id == 0)
                {
                    await _unitOfWork.ProductService.AddAsync(productViewModel.Product);
                    await _unitOfWork.SaveChangesAsync();
                    TempData["success"] = "Product Created successfully";
                    return RedirectToAction(nameof(Index));
                }
                await _unitOfWork.ProductService.UpdateAsync(productViewModel.Product);
                await _unitOfWork.SaveChangesAsync();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction(nameof(Index));
            }
            productViewModel.CategoryList = _unitOfWork.CategoryService.GetAllAsync(IncludeProperties: nameof(Category)).Result
           .Select(x => new SelectListItem
           {
               Text = x.Name,
               Value = x.Id.ToString()
           });
            return View(productViewModel);

        }
        [HttpGet]
        public async Task<IActionResult> Delete(long? id)
        {
            var product = await _unitOfWork.ProductService.GetAsync(x => x.Id == id, IncludeProperties: nameof(Category));
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
            var product = await _unitOfWork.ProductService.GetAsync(x => x.Id == id, IncludeProperties: nameof(Category));
            if (product is null)
            {
                return NotFound();
            }
            _unitOfWork.ProductService.Remove(product);
            await _unitOfWork.SaveChangesAsync();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        //Return Json data for Data Table
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _unitOfWork.ProductService.GetAllAsync(IncludeProperties: nameof(Category));
            return Json(new { data = products });
        }
    }
}
