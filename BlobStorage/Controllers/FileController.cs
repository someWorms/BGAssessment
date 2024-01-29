using BlobStorage.API.Models.Upload;
using BlobStorage.API.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlobStorage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;   
        }

        [HttpPost]
        public async Task<List<UploadResponseModel>> Upload(List<IFormFile> files)
        {
            var result = await _fileService.UploadAsync(files);

            return result;
        }
    }
}