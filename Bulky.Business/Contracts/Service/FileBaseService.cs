using BulkyBook.Business.Contracts.IService;
using BulkyBook.Business.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;


namespace BulkyBook.Business.Contracts.Service
{
    public class FileBaseService : IFileBaseService
    {
        private  readonly IHostingEnvironment _environment;
        private readonly IConfiguration _configuration;
        public FileBaseService(IHostingEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }
        public async Task<string> UploadFile(IFormFile file)
        {
            string rootpath = _environment.WebRootPath;
            string folder = _configuration["StaticFiles:ProductImages"];
            string fileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(file.FileName);
            string path = Path.Combine(rootpath, folder, fileName + extension);
            using FileStream fileStream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return $"{folder}\\{fileName}{extension}";
        }
        public int DeleteFullPathFile(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return 1;
            }
            return 0;
        }
        public int DeleteFile(string path)
        {
            string rootpath = _environment.WebRootPath;
            var oldImage = Path.Combine(rootpath, path.TrimStart('\\'));
            if (File.Exists(oldImage))
            {
                File.Delete(oldImage);
                return 1;
            }
            return 0;
        }
    }
}
