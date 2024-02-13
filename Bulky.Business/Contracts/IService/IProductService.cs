using BulkyBook.Business.Repositories;
using BulkyBook.Models.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Business.Contracts.IService
{
    public interface IProductService:IRepository<Product>
    {
        Task UpdateAsync(Product product);
    }
}
