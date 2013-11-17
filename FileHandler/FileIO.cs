using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using PCB.FileHandlers.Interfaces;

namespace PCB.FileHandlers.FileIO
{
    public static class FileIO
    {
        //This class uses XMLSerialization to save and load files.

        //Fileinfo contains then file name and any more information
        //IConverter specifies and interface for converting the loaded.saved file
        public static void SaveToFile(ISerializable fileToSave, FileInfo info, IConverter dataConverter)
        {
        }

        public static void LoadFromFile(ISerializable fileToLoad, FileInfo info, IConverter dataConverter)
        {
        }
    }
}
