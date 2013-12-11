using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
#include "pch.h"
#include "Design.h"
#include <deque>
#include "Library.h"

//Class for supplier information for part
class SupplierInformation{

public:
	//Default constructor
	SupplierInformation() = default;
	//Default destructor
	~SupplierInformation() = default;

private:
	//supplier part number
	std::wstring m_manufacturerNameString;

	//manufacturer part number
	std::wstring m_manufacturerPartString;

	//supplier part number
	std::wstring m_supplierPartString;

	//supplier part number
	std::wstring m_packageString;


};

class ManufacturerInfo{

public:
	//dont use default ctor
	ManufacturerInfo() = delete;

	//Ctor
	ManufacturerInfo(std::wstring partNumber, std::wstring manufacturer);

	//Dtor
	~ManufacturerInfo() = default;

private:

	//part number
	std::wstring m_partNumber;

	//manufacturer
	std::wstring m_manufacturer;

};

//the fundamental item of connectivity class 
class Pin : DesignItem{

public:

	//Ctor default
	Pin() = default;

	// Ctor
	Pin(std::wstring pinReference);

	//Dtor
	virtual ~Pin() = default;

	// References this instance.
	const std::wstring Reference() const;

	//Set Reference to the specified value.
	void Reference(std::wstring val);

	std::wstring toStringVerbose();

	std::wstring toString();

	D2D1_POINT_2F getLocationRelativeToContainer();

private:
	//Most numerical but can be of the form Ax Bx for any Grid or dual row based packages
	std::wstring reference;

	int pinNumber = -1;
	int row = -1;
	int position = -1;

	//keep track of any rows/columns that are missed in BGA matrices
	std::wstring rowsSkipped;
	int* positionsSkipped;
};

//Component outline used for collision detection
class Outline : virtual DesignItem{

public:
	//Ctor
	Outline() = default;

	//Dtor
	~Outline();

	// Adds the shape.
	void addShape(ID2D1Geometry* shape);

	// Gets the shape.
	ID2D1Geometry* getShape(int index);

	virtual std::wstring toStringVerbose();
	virtual std::wstring toString();
	virtual D2D1_POINT_2F getLocationRelativeToContainer();

public:
	//Standard D2D1 Shapes used for the body
	std::deque<ID2D1Geometry*> shapes;
	//Drawing functions
	virtual void Draw(Microsoft::WRL::ComPtr<ID2D1DeviceContext> context);

};

//class define for the body
class Body : DesignItem{


public:
	//Allocate resources
	Body() = default;
	//Free all resources -> will need to free all of the ID2D1Geometry*
	~Body() = default;
	//Add a shape to the body
	void addShape(ID2D1Geometry* shape);
	//Retrieve the shape pointer to modify it
	ID2D1Geometry* getShape(int index);

	virtual std::wstring toStringVerbose();
	virtual std::wstring toString();
	virtual D2D1_POINT_2F getLocationRelativeToContainer();
private:
	//Standard D2D1 Shapes used for the body
	std::deque<ID2D1Geometry*> shapes;

};

//Any Text displayed on the schematic derives from this
class Text : DesignItem{
public:
	//Ctor
	Text() = default;

	//Dtor
	~Text() = default;

	virtual std::wstring toStringVerbose();
	virtual std::wstring toString();
	virtual D2D1_POINT_2F getLocationRelativeToContainer();
};

class SchematicPart : LibraryPart, DesignItem
{
public:
	//Default Constructor
	SchematicPart();

	//Constructor with string variables
	SchematicPart(std::wstring name, std::wstring desc);

	//virtual destructor as this can be inherited form
	virtual ~SchematicPart() = default;

	//Retrieve a list of All the pins
	const std::deque<std::unique_ptr<Pin>>& pinList() const;

	//add a pin
	void addPin(Pin pinToAdd);

	//remove a pin
	void removePin(int index);

	//Get a pointer to the body of the part
	const std::unique_ptr<Body>& getBody() const;

	//delete the body of the component
	void deleteBody();

	//create the body of the component
	void setBody();

	virtual std::wstring toStringVerbose();
	virtual std::wstring toString();
	virtual D2D1_POINT_2F getLocationRelativeToContainer();

private:

	//type of component - will be supplied by an enum
	int m_componentType;

	//origin of the component
	D2D1_POINT_2F m_origin;

	//Pin list
	std::deque<std::unique_ptr<Pin>> m_pins;

	//body of the component
	std::unique_ptr<Body> m_componentBody;

	//outline of the body
	std::unique_ptr<Outline> m_componentOutline;

	//Component Name
	std::wstring m_name;

	//Description
	std::wstring m_description;

	//value
	std::wstring m_value;

	//library
	std::wstring m_library;

	//Supplier info
	std::map < std::wstring, std::unique_ptr<SupplierInformation>> m_supplierInfo;

};

//A specific schematic part
class SpecificSchematicPart : SchematicPart{

public:

	//Default Constructor
	SpecificSchematicPart();

	//Constructor with string variables
	SpecificSchematicPart(std::wstring name, std::wstring desc);

	//Dtor
	~SpecificSchematicPart() = default;
private:

	//Info about the manufacturer of the part
	ManufacturerInfo m_manufacturerInfo;
};

//A generic schematic part -> Resistor/Capacitor/Inductor etc
class GenericSchematicPart : SchematicPart{

public:

	//Default Constructor
	GenericSchematicPart();

	//Constructor with string variables
	GenericSchematicPart(std::wstring name, std::wstring desc);

	//Dtor
	~GenericSchematicPart() = default;
private:

	//a link between manufacturer and SupplierInformation
};

//A page in each schematic
class SchematicPage{

public:
	SchematicPage() = default;

	~SchematicPage() = default;

	//add a component to the schematic
	void addSchematicComponent(SchematicPart part);

	//returns a pointer a given part at an index
	SchematicPart* getPart(int index);

	void Draw(Microsoft::WRL::ComPtr<ID2D1DeviceContext> context);

private:

	std::deque<SchematicPart*> parts;
};

//the amalgam of all items
class Schematic : Design {

public:
	//Default Constructor
	Schematic();

	//Destructor
	~Schematic() = default; 

	//add a component to the schematic
	void addSchematicPage(SchematicPage page);

	//returns a pointer a given part at an index
	SchematicPage* getPage(int index);

	void Draw(Microsoft::WRL::ComPtr<ID2D1DeviceContext> context);

private:

	std::deque<SchematicPart*> pages;
};*/
