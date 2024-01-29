namespace BlobStorage.API.Configuration
{
    public class AzureBlobConfig
    {
        public const string SectionName = "ConnectionStrings:AzureConnection";
        public string AzureConnection { get; set; } = null!;
        public string ContainerName { get; set; } = null!;
        /*        public int DefaultEndpointProtocol { get; set; }
                public int AccountName { get; set; }
                public int AccountKey { get; set; }*/
    }
}
