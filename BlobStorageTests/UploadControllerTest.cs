using BlobStorage.API.Configuration;
using BlobStorage.API.Controllers;
using BlobStorage.API.Models.Upload;
using BlobStorage.API.Service;
using BlobStorage.API.Service.Interfaces;
using BlobStorage.Database;
using BlobStorage.Database.Interfaces;
using BlobStorage.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;

namespace BlobStorageTests
{
    /// <summary>
    /// Integration.
    /// </summary>
    [TestClass]
    public class UploadControllerTest
    {

        [TestMethod]
        public async Task PostFileAsync()
        {
            //Arrange
            var fileMock = new Mock<IFormFile>();

#region Setup mock file using a memory stream
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);
#endregion

            List<IFormFile> files = [fileMock.Object];

            var mockService = new Mock<IFileService>();
            mockService.Setup(s => s.UploadAsync(files)).ReturnsAsync(GetResponseModels());
            var controller = new FileController(mockService.Object);

            var result = await controller.Upload(files);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }


        private List<UploadResponseModel> GetResponseModels()
        {
            List<UploadResponseModel> uploadResponseModels =
            [
                new UploadResponseModel
                (
                    "Test",
                     0
                ),
            ];

            return uploadResponseModels;
        }
    }
}