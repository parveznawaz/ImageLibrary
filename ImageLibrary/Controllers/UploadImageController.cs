using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImageLibrary.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ImageLibrary.Controllers
{
    public class UploadImageController : Controller
    {
        private readonly IImageLibraryService _imageLibraryService;

        public UploadImageController(IImageLibraryService imageLibraryService)
        {
            _imageLibraryService = imageLibraryService;
        }


        [BindProperty]
        public IFormFile Upload { get; set; }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            if (Upload == null)
            {
                return View("Index");
            }
            //var file = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);
            //await using var fileStream = new FileStream(file, FileMode.Create);
            //await Upload.CopyToAsync(fileStream);
            await _imageLibraryService.AddFile(Upload);
            return RedirectToAction("Index", "Home");
        }
    }
}
