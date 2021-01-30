using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImageLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ImageLibrary.Services
{
    public class ImageLibraryService: IImageLibraryService
    {
        private readonly IHostEnvironment _environment;

        public ImageLibraryService(IHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task AddFile(IFormFile Upload)
        {
            var guid = Guid.NewGuid();
            var dir = Path.Combine(_environment.ContentRootPath,"wwwroot", "Uploads", guid.ToString());
            Directory.CreateDirectory(dir);
            var file = Path.Combine(dir, Upload.FileName);
            await using var fileStream = new FileStream(file, FileMode.Create);
            await Upload.CopyToAsync(fileStream);
        }
        

        public IEnumerable<ImageFile> GetAllFiles()
        {
            var imageList = new List<ImageFile>();
            var dir = Path.Combine(_environment.ContentRootPath,"wwwroot", "Uploads");
            foreach (var subDirPath in Directory.GetDirectories(dir))
            {
                foreach (var filePath in Directory.GetFiles(subDirPath))
                {
                    var guid = new Guid(Path.GetFileName(Path.GetDirectoryName(filePath)));
                    var fileName = Path.GetFileName(filePath);
                    imageList.Add(new ImageFile()
                    {
                        Id = guid,
                        FilePath = filePath,
                        FileName = $"~/Uploads/{guid.ToString()}/{fileName}"
                    });
                }
            }
            return imageList;
        }

        public void RemoveImage(Guid id)
        {
            var dir = Path.Combine(_environment.ContentRootPath, "wwwroot", "Uploads",id.ToString());
            Directory.Delete(dir,true);
        }
    }
}
