using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ImageLibrary.Services;
using Microsoft.Extensions.Hosting;
using Moq;
using Xunit;

namespace ImageLibrary.Test
{
    public class ImageLibraryServiceTest
    {
        [Fact]
        public void Test()
        {
            //var hostEnvironment = new Mock<IHostEnvironment>();
            //hostEnvironment.Setup(x => x.ContentRootPath).Returns(Path.Combine(".\\"));
            //var imageLibraryService = new ImageLibraryService(hostEnvironment.Object);
            //var list = imageLibraryService.GetAllFiles();
            //Assert.NotEmpty(list);

        }
    }
}
