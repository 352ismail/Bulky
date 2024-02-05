using Bulky.Business.Generics;
using Bulky.Models.Models;

namespace Bulky.Business.Contracts.IService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category> GetById(long Id);
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<ResponseMessage> Delete(long Id);
    }
}
