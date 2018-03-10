using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedConfigurationLibrary
{
    public class FieldsModel
    {
        public List<SettingsModel> settings { get; set; } = new List<SettingsModel>();

        public string AgencyName { get; set; }

        public string ExtraInformation { get; set; }

        public string BusTime { get; set; }

        public string TripCode { get; set; }

        public string SourcePlace { get; set; }

        public string DestinationPlace { get; set; }

        public string RtoNumber { get; set; }       
        
    }
}
