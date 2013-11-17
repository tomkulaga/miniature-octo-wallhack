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
using System.Xml.Serialization;
using PCB.SandBox;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PCB
{
    public partial class DesignView : Form
    {
        public DesignView()
        {
            InitializeComponent();

            var mp = new Employee();
            Stream stream;
            BinaryFormatter bformatter;
            mp.EmpId = 456;
            mp.EmpName = "sdfsdfsdf";

            var ss = new XmlSerializer(typeof(Employee));

            TextWriter tt = new StreamWriter(@"test.xml");
            ss.Serialize(tt, mp);

            tt.Close();
            /*
            stream = File.Open("EmployeeInfo.osl", FileMode.Create);
            bformatter = new BinaryFormatter();

            Console.WriteLine("Writing Employee Information");
            bformatter.Serialize(stream, mp);
            stream.Close();

            Console.ReadLine();

            mp = null;

            //Open the file written above and read values from it.
            stream = File.Open("EmployeeInfo.osl", FileMode.Open);
            bformatter = new BinaryFormatter();

            Console.WriteLine("Reading Employee Information");
            mp = (Employee)bformatter.Deserialize(stream);
            stream.Close();
            */
            mp = null;

            FileStream read = new FileStream(@"test.xml",FileMode.Open,FileAccess.Read,FileShare.Read);

            mp = (ss.Deserialize(read)) as Employee;

            Console.WriteLine("Employee Id: {0}", mp.EmpId.ToString());
            Console.WriteLine("Employee Name: {0}", mp.EmpName);

        }
    }
}
