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
using SharpDX.Windows;
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
        private RenderControl m_controlToPaint;
        private Button button1;
        private DesignViewRenderer renderer;
        Design designBehind;
        private bool keyDown = false;

        Point mouseCoords;

        private double[] zoomLevels = { 0.4, 0.6, 0.7, 0.8, 0.9, 1, 1.2, 1.3, 1.4, 1.5, 1.6 };
        private int selectedZoom = 5;
        public delegate void mouserrClick(object o, MouseEventArgs e);

        public DesignView()
        {
            InitializeComponent();
            renderer = new DesignViewRenderer { selectedCommand = new PanCommand() };
            renderer.InitRenderer(m_controlToPaint);
            //attach even handles to the currently selected tool
            //m_designRenderer.MouseClick += m_selectedCommand.OnMouseClick;
            /*
            m_controlToPaint.MouseDown += renderer.selectedCommand.OnMouseDown;
            m_controlToPaint.MouseMove += renderer.selectedCommand.OnMouseMove;

             m_controlToPaint.MouseUp += renderer.selectedCommand.OnMouseUp;
            */
            m_controlToPaint.Paint += renderer.RenderControlPaint;
            m_controlToPaint.MouseWheel += m_controlToPaint_MouseWheel;

        }

        //private member Functions

        // Required designer variable.
        private System.ComponentModel.IContainer components = null;
        private bool panning;
        private int mouseDownX = 0;
        private int mouseDownY = 0;


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
            this.m_controlToPaint = new SharpDX.Windows.RenderControl();
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
            // m_controlToPaint
            // 
            this.m_controlToPaint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_controlToPaint.Location = new System.Drawing.Point(12, 12);
            this.m_controlToPaint.Name = "m_controlToPaint";
            this.m_controlToPaint.Size = new System.Drawing.Size(1265, 664);
            this.m_controlToPaint.TabIndex = 1;
            this.m_controlToPaint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_controlToPaint_KeyDown);
            this.m_controlToPaint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_controlToPaint_MouseDown);
            this.m_controlToPaint.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_controlToPaint_MouseMove);
            this.m_controlToPaint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_controlToPaint_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 682);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DesignView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 717);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.m_controlToPaint);
            this.Name = "DesignView";
            this.Text = "DesignView";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private void m_controlToPaint_MouseDown(object sender, MouseEventArgs e)
        {
            if (!keyDown)
            {
                panning = true;
            }

            mouseDownX = e.X;
            mouseDownY = e.Y;
        }

        private void m_controlToPaint_MouseUp(object sender, MouseEventArgs e)
        {
            panning = false;
            keyDown = false;
        }

        private void m_controlToPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (keyDown)
            {
                renderer.singleItemX = e.X - mouseDownX;
                renderer.singleItemY = e.Y - mouseDownY;

            }
            else if(panning)
            {

                renderer.itemOffsetX = e.X - mouseDownX;
                renderer.itemOffsetY = e.Y - mouseDownY;
            }

            m_controlToPaint.Refresh();

        }

        private void m_controlToPaint_MouseWheel(object sender, MouseEventArgs e)
        {

            selectedZoom += e.Delta / 120;

            if (selectedZoom == zoomLevels.Length)
            {
                selectedZoom = zoomLevels.Length - 1;
            }
            else if (selectedZoom < 0)
            {
                selectedZoom = 0;
            }
            renderer.zoomLevel = (float)zoomLevels[selectedZoom];
            m_controlToPaint.Refresh();
        }

        private void m_controlToPaint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.G)
            {
                keyDown = true;
            }
        }


    }
}
