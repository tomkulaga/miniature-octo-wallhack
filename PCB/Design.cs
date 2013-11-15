using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace PCB_App
{
    class Design
    {
        //Constructor
        public Design()
        {

        }
    };

    class DesignItem {

	//Ctor 
    public DesignItem()
    {

    }
	
    //Ctor
	public DesignItem(Point _location, int id = -1)
    {
    }

    //Get the location of the schemItem
	public Point Location{get;set;}
	
	//each design item will also provide its location relative to the parent
	//that holds it
	public Point getLocationRelativeToContainer()
    {
        return Location;
    }

    //Set the location of the schemItem
	void setLocation(D2D1_POINT_2F location);
	
	//Every Design item will be able to print a string to describe itself
	virtual String toString()
    {
        return "heya";
    }
	
    //Every Design item will be able to print a string to describe itself
    //Provides info on location as well
	virtual String toStringVerbose();

protected:

    //identifier TODO: maybe allocate form global pool?
	int m_itemId;
	
	//location of the DesignItem relative to the Design that is in
	D2D1_POINT_2F m_location;
	
	//the design that this item is in, all DesignItems need to be in a design!
	std::unique_ptr<Design> m_container = nullptr;
	
	//whether the item will be display on screen, differne t
	bool m_visible = true;
	
	//whether the item is displayable on screen
	//most are so default is true
	bool m_printableItem = true;
};
}*/