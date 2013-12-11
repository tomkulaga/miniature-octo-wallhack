using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCB.Designs;
using SharpDX;
using SharpDX.Direct2D1;

namespace Design.Schematic
{
    //Any Text displayed on the schematic derives from this
    class Text : DesignItem
    {

        //Ctor
        public Text()
        {

        }

        string ToStringVerbose()
        {
            throw new NotImplementedException();
        }

        string toString()
        {
            throw new NotImplementedException();
        }

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
