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

        //Ctor 
        public DesignItem()
        {

        }

        //Ctor
        public DesignItem(Point _location, int id = -1)
        {
        }

        //Get the location of the schemItem
        public Point Location { get; set; }

        //each design item will also provide its location relative to the parent
        //that holds it
        public Point getLocationRelativeToContainer()
        {
            return Location;
        }

        //Set the location of the schemItem
        void setLocation(Point location) { }

        //Every Design item will be able to print a string to describe itself
        public abstract String toString();

        //Every Design item will be able to print a string to describe itself
        //Provides info on location as well
        public abstract String toStringVerbose();


        //identifier TODO: maybe allocate form global pool?
        private int m_itemId;

        //location of the List relative to the Design that is in
        Point m_location;

        //the design that this item is in, all DesignItems need to be in a design!
        Design m_container = null;

        //whether the item will be display on screen, differnet
        bool m_visible = true;

        //whether the item is displayable on screen
        //most are so default is true
        bool m_printableItem = true;
    }
}
