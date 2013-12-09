using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Library;

namespace PCB.Library.Library
{
    public abstract class LibraryBase
    {


        protected LibraryBase(string name)
        {
            LibraryName = name;
        }

        //Name of library
        public string LibraryName { get; set; }

        //whether the library is loaded into ram
        public Boolean Loaded { get; private set; }

        public LibraryItem GetItem(string itemName)
        {
            return _libraryItems[itemName];
        }

        public void AddItem(string itemName, LibraryItem item)
        {
            _libraryItems.Add(itemName,item);
        }

        public void RemoveItem(string itemName)
        {
            _libraryItems.Remove(itemName);
        }
        #region Private Fields

        //Items in Library
        private SortedDictionary<string, LibraryItem> _libraryItems;

        #endregion


    }
}
