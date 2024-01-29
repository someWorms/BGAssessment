using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobStorage.Database.Models
{
    /// <summary>
    /// Database model that stores date related uploaded file
    /// </summary>
    public class BlobFileModel
    {
        /// <summary>
        /// Id - Key
        /// </summary>
        [Key]
        public ulong Id { get; set; }

        /// <summary>
        /// File Name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Type of content
        /// </summary>
        public string? ContentType { get; set; }

        /// <summary>
        /// File extension
        /// </summary>
        public string? Extension { get; set; }

        /// <summary>
        /// Processed time, if processed successfully
        /// </summary>
        public DateTime ProcessedStamp { get; set; }

        /// <summary>
        /// File path on the AZ Blob Storage
        /// </summary>
        public string? FilePath { get; set; }
    }
}
