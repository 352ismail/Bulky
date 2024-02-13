using BulkyBook.Business.Contracts.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Business.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICategoryService CategoryService { get; }
        IProductService ProductService { get; }
        Task SaveChangesAsync();
    }
}
