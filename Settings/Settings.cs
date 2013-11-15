using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings
{
    public abstract class SettingsBase
    {

        //Ctor
        public SettingsBase()
        {

        }

        // Opens the settings file. Must be overriden
        public virtual void openSettingsFile() 
        {
            FileOpen = true;
        }

        // Closes the settings file. Maybe done in dtor
        public virtual void closeSettingsFile()
        {
            FileOpen = false;
        }

        // Saves the settings file.
        public virtual void saveSettingsFile()
        {

        }

        // Deletes the settings file.
        public virtual void deleteSettingsFile()
        {

        }

        //Properties
        public bool FileOpen { get; set; }

        //Protected Members - Make most protected as this class is abstract
        protected readonly string m_filePath;
    };

    public class SchematicSettings : SettingsBase
    {
        public SchematicSettings()
        {
            base.openSettingsFile();
        }
    }

}
