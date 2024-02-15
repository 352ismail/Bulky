using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Business.Contracts.IService
{
    public interface IFileBaseService
    {
        Task<string> UploadFile(IFormFile file);
        public int DeleteFile(string path);
    }
}
