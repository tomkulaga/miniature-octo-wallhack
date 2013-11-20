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
using PCB.Tools;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PCB.GUI
{
    public class DesignView : Form
    {
        Command selectedCommand;

        public DesignView()
        {
            InitializeComponent();
            selectedCommand = new NullCommand();
            //attach even handles to the currently selected tool
            m_designRenderer.MouseClick += selectedCommand.OnMouseClick;
            m_designRenderer.MouseDown += selectedCommand.OnMouseDown;
            m_designRenderer.MouseMove += selectedCommand.OnMouseMove;
        }

        private Button button1;

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
            this.m_designRenderer = new SharpDX.Windows.RenderControl();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_designRenderer
            // 
            this.m_designRenderer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_designRenderer.Location = new System.Drawing.Point(113, 42);
            this.m_designRenderer.Name = "m_designRenderer";
            this.m_designRenderer.Size = new System.Drawing.Size(475, 335);
            this.m_designRenderer.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(441, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DesignView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 460);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.m_designRenderer);
            this.Name = "DesignView";
            this.Text = "DesignView";
            this.ResumeLayout(false);

        }

        #endregion

        private SharpDX.Windows.RenderControl m_designRenderer;

        private void button1_Click(object sender, EventArgs e)
        {
            m_designRenderer.MouseClick -= selectedCommand.OnMouseClick;
            m_designRenderer.MouseDown -= selectedCommand.OnMouseDown;
            m_designRenderer.MouseMove -= selectedCommand.OnMouseMove;
            selectedCommand = new Draw();
            m_designRenderer.MouseClick += selectedCommand.OnMouseClick;
            m_designRenderer.MouseDown += selectedCommand.OnMouseDown;
            m_designRenderer.MouseMove += selectedCommand.OnMouseMove;
        }
    }
}
