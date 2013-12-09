using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCB.Designs;
using SharpDX;
using D2D =  SharpDX.Direct2D1;

namespace Design.Schematic
{
    class SchematicBody : DesignItem
    {

        //Allocate resources
        public SchematicBody()
        {

        }

        //Free all resources -> will need to free all of the Geometry
        ~SchematicBody()
        {

        }
        //Add a shape to the body
        void AddShape(D2D.Geometry shape)
        {

        }
        //Retrieve the shape pointer to modify it
        public SharpDX.Point GetShape(int index)
        {
            return new SharpDX.Point(0, 0);
        }

        //Standard D2D1 Shapes used for the body
        List<D2D.Geometry> shapes;

        public override Point GetLocationRelativeToContainer()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    };

}
