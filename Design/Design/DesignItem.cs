using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SharpDX;

using Point = SharpDX.Point;

namespace PCB.Designs
{
    public abstract class DesignItem
    {
        //PUBLIC Methods

        //Ctor default
        protected DesignItem()
        {

        }

        //Ctor
        protected DesignItem(Point location)
        {
            Location = location;
        }

        //Id of the item
        public int ItemId
        {
            get { return m_itemId; }
            set { m_itemId = value; }
        }

        //each design item will also provide its location relative to the parent that holds it
        public abstract Point GetLocationRelativeToContainer();

        //Set the location of the schemItem
        void SetLocation(Point location)
        {
            
        }

        //Every Design item will be able to print a string to describe itself
        public override abstract String ToString();

        #region Properties
        //Get the location of the schemItem
        public Point Location
        {
            get
            {
                return m_location;
            }
            set
            {
                m_location = value;
            }
        }

        //whether the item will be display on screen, different
        public bool Visible
        {
            get { return m_visible; }
            set { m_visible = value; }
        }

        //whether the item is displayable on screen
        public bool Printable
        {
            get { return m_printable; }
        }
        #endregion
        #region ProtectedMembers
        //identifier TODO: maybe allocate form global pool?
        protected int m_itemId;

        //location of the List relative to the Design that is in
        protected Point m_location;

        //the design that this item is in, all DesignItems need to be in a design!
        protected Design m_container = null;

        //whether the item will be display on screen, different
        private bool m_visible = true;

        //whether the item is displayable on screen
        //most are so default is true
        private bool m_printable = true;
        #endregion
    }
}
