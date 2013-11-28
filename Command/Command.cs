using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCB.Tools
{
    public abstract class Command
    {
        protected Command()
        {

        }
        public abstract void OnMouseDown(object o, MouseEventArgs e);
        public abstract void OnMouseMove(object o, MouseEventArgs e);
        public abstract void OnMouseClick(object o, MouseEventArgs e);
        public abstract void OnMouseUp(object sender, MouseEventArgs e);

        public virtual void OnSelectCommand(object sender, PropertyChangedEventArgs e)
        {
            
        }
    }

    public class NullCommand : Command
    {
        public override void OnMouseDown(object o, MouseEventArgs e)
        {
            Console.WriteLine("hey");
        }
        public override void OnMouseMove(object o, MouseEventArgs e)
        {

        }
        public override void OnMouseClick(object o, MouseEventArgs e)
        {

        }

        public override void OnMouseUp(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    public class PanCommand : Command
    {
        public override void OnMouseDown(object o, MouseEventArgs e)
        {
            Console.WriteLine("hey");
        }
        public override void OnMouseMove(object o, MouseEventArgs e)
        {

        }
        public override void OnMouseClick(object o, MouseEventArgs e)
        {

        }

        public override void OnMouseUp(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    public class Draw : Command
    {
        public override void OnMouseDown(object o, MouseEventArgs e)
        {
            Console.WriteLine("Crazy");
        }
        public override void OnMouseMove(object o, MouseEventArgs e)
        {

        }
        public override void OnMouseClick(object o, MouseEventArgs e)
        {

        }

        public override void OnMouseUp(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
