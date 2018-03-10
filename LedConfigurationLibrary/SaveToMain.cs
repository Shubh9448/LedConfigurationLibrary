using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedConfigurationLibrary.TextHelpers;

namespace LedConfigurationLibrary
{
    public class SaveToMain : ITextProperties
    {
        public SettingsModel sendModel(SettingsModel model)
        {
            return model;
        }
    }
}
