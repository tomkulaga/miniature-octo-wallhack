using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Direct2D1;

namespace PCB.Designs.SchematicItems
{
    class SchematicPin : DesignItem
    {

        //Ctor default
        public SchematicPin()
        {

        }

        // Ctor
        public SchematicPin(string pinReference)
        {

        }

        // References this instance.
        public string Reference()
        {
            return "default";
        }

        //Set Reference to the specified value.
        void Reference(string val)
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


        //Most numerical but can be of the form Ax Bx for any Grid or dual row based packages
        string reference;

        int pinNumber = -1;

        int row = -1;

        int position = -1;

    };

}
