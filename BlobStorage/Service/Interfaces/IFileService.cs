using BlobStorage.API.Models.Upload;
using Microsoft.AspNetCore.Mvc;

namespace BlobStorage.API.Service.Interfaces
{
    /// <summary>
    /// IFile Service interface.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Uploads file logic. 
        /// If file cannot be uploaded - it is ignored and adds appropriate code to <c>List</c> of results
        /// </summary>
        /// <param name="files"><c>List</c> of files to upload</param>
        /// <returns><c>List</c> of results for each file</returns>
        Task<List<UploadResponseModel>> UploadAsync(List<IFormFile> files);
    }
}
