using Azure.Storage.Blobs;
using BlobStorage.API.Common.Enums;
using BlobStorage.API.Configuration;
using BlobStorage.API.Models.Upload;
using BlobStorage.API.Service.Interfaces;
using BlobStorage.Database.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Cryptography.Xml;

namespace BlobStorage.API.Service
{
    public class FileService : IFileService
    {

        private readonly BlobContainerClient _container;
        private readonly IDatabaseContext _db;

        public FileService(IDatabaseContext databaseContext, IOptions<AzureBlobConfig> options)
        {
            var settings = options.Value;
            _container = new BlobContainerClient(settings.AzureConnection, settings.ContainerName);
            _db = databaseContext;
        }

        public async Task<List<UploadResponseModel>> UploadAsync(List<IFormFile> files)
        {
            await _container.CreateIfNotExistsAsync();
            List<UploadResponseModel> result = new List<UploadResponseModel>();

            foreach (IFormFile file in files)
            {
                string filePath = Path.GetExtension(file.FileName) + "/" + file.FileName;

                try
                {
                    await _container.UploadBlobAsync(filePath, file.OpenReadStream());

                    var data = new Database.Models.BlobFileModel()
                    {
                        Name = Path.GetFileName(file.FileName),
                        ContentType = file.ContentType,
                        Extension = Path.GetExtension(file.FileName),
                        ProcessedStamp = DateTime.Now,
                        FilePath = filePath
                    };

                    _db.BlobFiles.Add(data);
                    _db.SaveChanges();

                    result.Add(new UploadResponseModel(file.Name, UploadResponseType.Success));
                }
                catch (Exception)
                {
                    result.Add(new UploadResponseModel
                    (
                        file.FileName,
                        UploadResponseType.FileAlreadyExists
                    ));
                }
            }

            return result;
        }
    }
}
