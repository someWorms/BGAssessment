using AgeCalculator.Common;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace AgeCalculator.Models
{
    /// <summary>
    /// Contains necessary to receive input and to send response.
    /// Input is <c>Birthday</c>, other fields are reults.
    /// Contains attribute validation.
    /// </summary>
    public class AgeViewModel
    {
        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date, ErrorMessage = "Must be a date")]
        [Display(Name = "Birthday")]
        [DateTimeFuture(ErrorMessage = "Date cannot be in the future")]
        public DateTime Birthday { get; set; }
        public DateTime CurrDate { get; set; }
        public int Years { get; set; }
        public int Months { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }


        public AgeViewModel()
        {
            CurrDate = DateTime.Now;
        }
    }
}
