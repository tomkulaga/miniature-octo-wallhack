using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Subjects;
using System.Reactive;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PCB.GUI;
using PCB.Settings.Interfaces;
using System.Xml.Serialization;

namespace PCB
{
    public partial class Form1 : DesignView
    {

        //[DllImport("AMP", CallingConvention = CallingConvention.StdCall)]
        //extern unsafe static void square_array(float* array, int length);

        public Form1()
        {
            /*InitializeComponent();
            // Allocate an array
            var arr = new[] { 1.0f, 2.0f, 3.0f, 4.0f };

            // Square the array elements using C++ AMP
            fixed (float* arrPt = &arr[0])
            {
                square_array(arrPt, arr.Length);
            }

            // Enumerate the results
            foreach (var x in arr)
            {
                Console.WriteLine(x);
            }*/

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
