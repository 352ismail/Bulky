using BulkyBook.Business.Contracts.IService;
using BulkyBook.DataAccess.Data;
using BulkyBook.Business.Generics;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using BulkyBook.Models.Models;
using BulkyBook.Business.Repositories;

namespace BulkyBook.Business.Contracts.Service
{
    public class CategoryService : Repository<Category> ,ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        public async Task UpdateAsync(Category category)
        {
            if (category is null)
            {
                throw new KeyNotFoundException("Category is null");
            }
            _context.Category.Update(category);
            await _context.SaveChangesAsync();
        }
        #region Old Repository Pattern
        //public async Task<Category> Create(Category category)
        //{
        //    if(category is null)
        //    {
        //        throw new KeyNotFoundException("Category is null");
        //    }
        //    _context.Category.Add(category);
        //    await _context.SaveChangesAsync();
        //    return category;
        //}

        //public async Task<ResponseMessage> Delete(long Id)
        //{
        //   if(Id == 0)
        //    {
        //        return new ResponseMessage(status:"Error",message:"Id is null");
        //    }
        //    var category = await GetById(Id);
        //    _context.Category.Remove(category);
        //    await _context.SaveChangesAsync();
        //    return new ResponseMessage(status: "Success", message: "Category Deleted");
        //}

        //public async Task<List<Category>> GetAll()
        //{
        //   return await _context.Category.ToListAsync();
        //}

        //public async Task<Category> GetById(long Id)
        //{
        //    var category =  await _context.Category.FirstOrDefaultAsync(x => x.Id == Id);
        //    if(category is null)
        //    {
        //        throw new KeyNotFoundException("Category not found");
        //    }
        //    return category;

        //}
        #endregion
    }
}
