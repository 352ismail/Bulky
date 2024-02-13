using BulkyBook.Business.Contracts.IService;
using BulkyBook.Business.Repositories;
using BulkyBook.DataAccess.Data;
using BulkyBook.Models.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Business.Contracts.Service
{
    public class ProductService : Repository<Product>, IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        public async Task UpdateAsync(Product product)
        {
            if(product is null)
            {
                throw new ArgumentNullException("Product not found");
            }
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
