using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Library
{
    public abstract class LibraryItem
    {
        protected LibraryItem(string itemName)
        {
            Name = itemName;
        }

        public String Name { get; set; }
    }
}
