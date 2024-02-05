using BulkyWeb.Generics;
using BulkyWeb.Models;

namespace BulkyWeb.Contracts.IService
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
