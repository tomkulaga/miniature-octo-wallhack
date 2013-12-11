using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCB.Designs;

namespace Design.Schematic
{
    //A page in each schematic
class SchematicPage{


    public SchematicPage()
    {
        
    }

	//add a component to the schematic
    void AddSchematicComponent(SchematicPart part)
    {
        
    }

	//returns a pointer a given part at an index
    SchematicPart GetPart(int index)
    {
        throw new NotImplementedException();
    }

	private DesignItem _items;
};


}
