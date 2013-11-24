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
using PCB.Designs;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;
using SharpDX.DXGI;

using AlphaMode = SharpDX.Direct2D1.AlphaMode;
using Color = SharpDX.Color;
using Factory = SharpDX.Direct2D1.Factory;
using FontStyle = SharpDX.DirectWrite.FontStyle;
using D2D = SharpDX.Direct2D1;
using Point = SharpDX.Point;

namespace PCB.GUI
{
    public class DesignView : Form
    {
        mouserrClick tom;

        List<String> teest = new List<string>();
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolToolStripMenuItem;
        private ToolStripComboBox toolStripComboBox1;
        private SharpDX.Windows.RenderControl m_designRenderer;
        private Button button1;
        Design designBehind;

        Point mouseCoords;
        
        public delegate void mouserrClick(object o, MouseEventArgs e);
        public DesignView()
        {
            InitializeComponent();
            selectedCommand = new NullCommand();
            //attach even handles to the currently selected tool
            //m_designRenderer.MouseClick += m_selectedCommand.OnMouseClick;
            m_designRenderer.MouseDown += selectedCommand.OnMouseDown;
            m_designRenderer.MouseMove += selectedCommand.OnMouseMove;
            tom = selectedCommand.OnMouseClick;
             m_designRenderer.MouseClick += new MouseEventHandler(tom);


             InitDirect2DAndDirectWrite();
             m_designRenderer.Paint += RenderControlPaint;
             m_designRenderer.MouseMove += selectedCommand.OnMouseMove;
     
        }

        //private member Functions
        private void refreshList()
        {

        }

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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.m_designRenderer = new SharpDX.Windows.RenderControl();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 26);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.toolToolStripMenuItem.Text = "Tool";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            // 
            // m_designRenderer
            // 
            this.m_designRenderer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_designRenderer.Location = new System.Drawing.Point(12, 12);
            this.m_designRenderer.Name = "m_designRenderer";
            this.m_designRenderer.Size = new System.Drawing.Size(475, 335);
            this.m_designRenderer.TabIndex = 1;
            this.m_designRenderer.Load += new System.EventHandler(this.m_designRenderer_Load);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 353);
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
            this.ClientSize = new System.Drawing.Size(506, 415);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.m_designRenderer);
            this.Name = "DesignView";
            this.Text = "DesignView";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        

        private void button1_Click(object sender, EventArgs e)
        {

            selectedCommand = new Draw();
            tom = new mouserrClick(selectedCommand.OnMouseClick);
        }

        private int m_renderer;

        internal PCB.Designs.DesignViewRenderer DesignViewRenderer
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

    }
}
