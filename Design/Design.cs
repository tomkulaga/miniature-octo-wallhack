using System;
using System.Drawing;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB.Designs
{
    public abstract class Design
    {
        //
        protected ObservableCollection<DesignItem> m_designItemList;
        //name of the design
        protected string m_designName;
        //Constructor
        public Design()
        {
            m_designItemList = new ObservableCollection<DesignItem>();
        }
    };
    
}