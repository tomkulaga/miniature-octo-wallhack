using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PCB.Settings.Interfaces;
using System.Xml.Serialization;

namespace PCB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<ISettings> test = new List<ISettings>();
            test.Add(new PCB.Settings.PcbSettings());
            test.Add(new PCB.Settings.FileSettings());
            test.Add(new PCB.Settings.GeneralSettings());
          //  try
           // {
                var tx = new StreamWriter(@"texts.xml");
                var xm = new XmlSerializer(test.GetType());

                xm.Serialize(tx, test);
          //  }
           // catch (Exception e)
           // {

               // System.Console.WriteLine(e);

            //}


        }
    }
}
