using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using PCB.Settings.Interfaces;

namespace PCB.Settings
{
    public class Settings
    {

        //protect Ctor to make this a singleton
        protected Settings()
        {
            //Initialises all the sub settings
        }

        public Settings InitialiseSettings()
        {
            return new Settings();
        }

        //Properties
        public bool FileOpen { get; set; }

        //Protected Members - Make most protected as this class is abstract
        public string FilePath { get; set; }
    };

    //Each of the subclasses will recursively add its settings to the main dictionary
    internal class PcbSettings : ISettings
    {
        
    }

    internal class FileSettings : ISettings
    {
        
    }

    internal class SchematicSettings : ISettings
    {
        
    }

    internal class GeneralSettings : ISettings
    {
        
    }
}
