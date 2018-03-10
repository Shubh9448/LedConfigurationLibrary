using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedConfigurationLibrary.TextHelpers;
using LedConfigurationLibrary;


namespace LedConfigurationLibrary
{ 

    class TextConnection : IDataConnection
    {
        private const string ConfigFile = "config.txt";

        // TODO - 
        public SettingsModel CreateSettings(SettingsModel model , List<string> pre_text)
        {
            List<SettingsModel> settings = new List<SettingsModel>();

            List<List<string>> TextStatic = new List<List<string>>();
            List<string> TripCode = new List<string>();
            List<string> DestinationPlace = new List<string>();

            TextStatic.Add(TripCode);
            
            settings.Add(model);

            settings.SaveToFile(ConfigFile, pre_text);

            return model;

        }
    }
}
