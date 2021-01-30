using ImageLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ImageLibrary.Services;

namespace ImageLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IImageLibraryService _imageLibraryService;

        public HomeController(ILogger<HomeController> logger, IImageLibraryService imageLibraryService)
        {
            _logger = logger;
            _imageLibraryService = imageLibraryService;
        }

        public IActionResult Index()
        {
            var files = _imageLibraryService.GetAllFiles();
            return View(files);
        }

        public IActionResult RemoveImage(Guid Id)
        {
            _imageLibraryService.RemoveImage(Id);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
