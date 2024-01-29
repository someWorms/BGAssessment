using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANPR.Persistence.Models
{
    public class PlateModel
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string RegNumber { get; set; }
        public string ConfidenceLevel { get; set; }
        public string CameraName { get; set; }
        public int Date { get; set; }
        public int Time { get; set; }
        public string ImageFileName { get; set; }
    }
}
