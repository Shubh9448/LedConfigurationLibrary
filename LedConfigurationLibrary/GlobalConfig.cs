using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedConfigurationLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

        public static void InitializeConnections(bool textFiles)
        {
            if (textFiles)
            {
                // TODO - create text connection
                TextConnection text = new TextConnection();
                Connections.Add(text);
            }
        }


    }
}
