using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageLibrary.Models;
using Microsoft.AspNetCore.Http;

namespace ImageLibrary.Services
{
    public interface IImageLibraryService
    {
        Task AddFile(IFormFile file);
        IEnumerable<ImageFile> GetAllFiles();
        void RemoveImage(Guid id);
    }
}
