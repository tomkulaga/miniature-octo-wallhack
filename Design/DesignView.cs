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

namespace PCB.GUI
{
    public class DesignView : Form
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

        private Button _button;

        // Required designer variable.
        private System.ComponentModel.IContainer components = null;

    
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.renderControl = new SharpDX.Windows.RenderControl();
            this._button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // renderControl
            // 
            this.renderControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.renderControl.Location = new System.Drawing.Point(113, 42);
            this.renderControl.Name = "renderControl";
            this.renderControl.Size = new System.Drawing.Size(475, 335);
            this.renderControl.TabIndex = 1;
            // 
            // button1
            // 
            this._button.Location = new System.Drawing.Point(264, 416);
            this._button.Name = "button1";
            this._button.Size = new System.Drawing.Size(75, 23);
            this._button.TabIndex = 2;
            this._button.Text = "button1";
            this._button.UseVisualStyleBackColor = true;
            // 
            // DesignView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 460);
            this.Controls.Add(this._button);
            this.Controls.Add(this.renderControl);
            this.Name = "DesignView";
            this.Text = "DesignView";
            this.ResumeLayout(false);

        }

        #endregion

        private SharpDX.Windows.RenderControl renderControl;
    }
}
