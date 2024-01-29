using BlobStorage.API.Common.Enums;

namespace BlobStorage.API.Models.Upload
{
    public record class UploadResponseModel(string FileName, UploadResponseType Type);
}
