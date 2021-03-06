﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using D2D = SharpDX.Direct2D1;

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
            throw new NotImplementedException();
        }

        public void OnSelectCommand(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
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
        private List<D2D.Geometry> itemsToAddTo;

        public AddComponent(List<D2D.Geometry> items)
        {
            itemsToAddTo = items;
        }

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
}
