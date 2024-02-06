using BulkyBook.Business.Generics;
using BulkyBook.Business.Repositories;
using BulkyBook.Models.Models;


namespace BulkyBook.Business.Contracts.IService
{
    public interface ICategoryService: IRepository<Category>
    {
        Task UpdateAsync(Category category);
        Task SaveChangesAsync();

    }
}
