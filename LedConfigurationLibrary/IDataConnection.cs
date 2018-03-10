using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedConfigurationLibrary
{
    public interface IDataConnection
    {
        SettingsModel CreateSettings(SettingsModel model, List<string> text);
        
    }
}
