using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB.Helper
{
    public class Factory<T>
    {
        //Ctor
        public Factory(Action<T> creatorFunction)
        {
            _itemsList = new Dictionary<string, T>();
        }

        //retrieve an item
        public T GetItem(string itemName)
        {
            return _itemsList[itemName];
        }

        //create a new item
        public void NewItem(string itemName)
        {

        }

        //Remove an item
        public void RemoveItem(string itemName)
        {
            try
            {
                _itemsList.Remove(itemName);
            }
            catch (ArgumentNullException)
            {

                throw;
            }

        }

        #region Private Fields
        
        //the back dictionary behind the factory
        private Dictionary<string, T> _itemsList;

        //this will be called each time the new item is created
        private delegate T Creator(string itemName);

        #endregion
    }
}
