using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB.Settings
{
    public abstract class SettingsBase
    {

        //protect Ctor to make this a singleton
        protected SettingsBase()
        {

        }

        //Properties
        public bool FileOpen { get; set; }

        //Protected Members - Make most protected as this class is abstract
        public string FilePath { get; set; }
    }; 

    public class SchematicSettings : SettingsBase
    {
        public SchematicSettings()
        {

        }
    }

}
