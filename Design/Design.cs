using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB.Designs
{
    public abstract class Design
    {
        private List<DesignItem> m_designItemList;
        //Constructor
        public Design()
        {
            m_designItemList = new List<DesignItem>();
        }
    };
    
}