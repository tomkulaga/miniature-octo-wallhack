using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCB.Designs;
using PCB.Designs.Schematic;
using PCB.Designs.SchematicItems;
using SharpDX;

namespace Design.Schematic
{
    class SchematicPart : DesignItem
    {

        //Default Constructor
        public SchematicPart()
        {

        }

        //Constructor with string variables
        SchematicPart(string name, string desc)
        {

        }


        //Retrieve a list of All the pins
        public List<SchematicPin> pinList { get; private set; }

        //add a pin
        void AddPin(SchematicPin pinToAdd)
        {

        }

        //remove a pin
        void RemovePin(int index)
        {

        }

        //Get a pointer to the body of the part
        SchematicBody GetBody()
        {
            throw new NotImplementedException();
        }

        //delete the body of the component
        void DeleteBody()
        {

        }

        //create the body of the component
        void SetBody(SchematicBody body)
        {

        }

        public override Point GetLocationRelativeToContainer()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }


        //type of component - will be supplied by an enum, generic of specific
        private SchematicPartType _componentType;

        //origin of the component
        private SharpDX.Point _origin;

        //body of the component
        private SchematicBody _componentBody;

        //outline of the body
        private SchematicComponentOutline _componentOutline;

        //Component Name
        private string _name;

        //Description
        private string _description;

        //value
        private string _value;

        //library
        private string _library;

        //Supplier info, accessed by supplier
        Dictionary<string,SupplierInformation> _supplierInfo;


    };
}
