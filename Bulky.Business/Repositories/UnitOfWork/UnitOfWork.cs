using BulkyBook.Business.Contracts.IService;
using BulkyBook.Business.Contracts.Service;
using BulkyBook.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Business.Repositories.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICategoryService CategoryService { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            CategoryService = new CategoryService(_context);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
