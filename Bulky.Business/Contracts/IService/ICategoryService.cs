using Bulky.Business.Generics;
using Bulky.Business.Repositories;
using Bulky.Models.Models;


namespace Bulky.Business.Contracts.IService
{
    public interface ICategoryService: IRepository<Category>
    {
        Task UpdateAsync(Category category);
        Task SaveChangesAsync();

    }
}
