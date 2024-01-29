namespace BlobStorage.Database.Settings
{
    /// <summary>
    /// DbConfig for appsettings.
    /// </summary>
    public class DatabaseConfig
    {
        /// <summary>
        /// Connection string section in appsettings
        /// </summary>
        public const string SectionName = "ConnectionStrings";
        
        /// <summary>
        /// Contains connection string.
        /// </summary>
        public string DbConnectionString { get; set; } = null!;
    }
}
