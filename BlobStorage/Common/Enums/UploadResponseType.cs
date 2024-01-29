namespace BlobStorage.API.Common.Enums
{
    /// <summary>
    /// Error code for result.
    /// </summary>
    public enum UploadResponseType
    {
        /// <summary>
        /// If file succeded to upload, and store metadata at the database.
        /// </summary>
        Success,

        /// <summary>
        /// If blob storage already contains such file.
        /// </summary>
        FileAlreadyExists,
        
        /// <summary>
        /// If file has bad namin, format.
        /// </summary>
        BadName,

        /// <summary>
        /// Rest of errors.
        /// </summary>
        Error
    }
}
