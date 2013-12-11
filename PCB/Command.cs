using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCB.GUI;
using SharpDX;
using D2D = SharpDX.Direct2D1;
using SharpDX;

namespace PCB.Tools
{
    public interface ICommand
    {
      
        void OnMouseDown(object o, MouseEventArgs e);
        void OnMouseMove(object o, MouseEventArgs e);
        void OnMouseClick(object o, MouseEventArgs e);
        void OnMouseUp(object sender, MouseEventArgs e);
        void OnSelectCommand(object sender, PropertyChangedEventArgs e);

    }

    public class NullCommand : ICommand
    {
        public void OnMouseDown(object o, MouseEventArgs e)
        {
            Console.WriteLine("hey");
        }
        public void OnMouseMove(object o, MouseEventArgs e)
        {

        }
        public void OnMouseClick(object o, MouseEventArgs e)
        {

        }
        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnSelectCommand(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    public class PanCommand : ICommand
    {
        public void OnMouseDown(object o, MouseEventArgs e)
        {
            Console.WriteLine("hey");
        }
        public void OnMouseMove(object o, MouseEventArgs e)
        {

        }
        public void OnMouseClick(object o, MouseEventArgs e)
        {

        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void OnSelectCommand(object sender, PropertyChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
    public class Draw : ICommand
    {
        public void OnMouseDown(object o, MouseEventArgs e)
        {
            Console.WriteLine("Crazy");
        }
        public void OnMouseMove(object o, MouseEventArgs e)
        {

        }
        public void OnMouseClick(object o, MouseEventArgs e)
        {

        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnSelectCommand(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    public class AddComponent : ICommand
    {


        public void OnMouseDown(object o, MouseEventArgs e)
        {
            //var list = (o as Form1).renderer.itemsToDraw;
            var rc = (DesignView) o;
            rc.AddObject(new SharpDX.Point(e.X,e.Y), new SharpDX.Size2(100,100) );
        }
        public void OnMouseMove(object o, MouseEventArgs e)
        {

        }
        public void OnMouseClick(object o, MouseEventArgs e)
        {

        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
        }

        public void OnSelectCommand(object sender, PropertyChangedEventArgs e)
        {
        }
    }
}
