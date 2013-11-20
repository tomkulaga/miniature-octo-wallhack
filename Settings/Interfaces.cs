using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB.Settings.Interfaces
{
    [Serializable()]
    [System.Xml.Serialization.XmlInclude(typeof(PcbSettings))]
    [System.Xml.Serialization.XmlInclude(typeof(FileSettings))]
    [System.Xml.Serialization.XmlInclude(typeof(GeneralSettings))]
    [System.Xml.Serialization.XmlInclude(typeof(SchematicSettings))]
    public abstract class ISettings
    {
        public abstract string ToString();
    }
}
