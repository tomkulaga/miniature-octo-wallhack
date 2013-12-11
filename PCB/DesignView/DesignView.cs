using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
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
    public class DesignView : SharpDX.Windows.RenderControl, INotifyPropertyChanged
    {
        protected ContextMenuStrip contextMenuStrip1;
        protected ToolStripMenuItem toolToolStripMenuItem;
        protected ToolStripComboBox toolStripComboBox1;
        protected RenderControl m_controlToPaint;
        public readonly DesignViewRenderer renderer;
        PCB.Designs.Design designBehind;
        protected bool keyDown = false;

        protected Point mouseCoords;


        protected ICommand m_selectedCommand;

        protected readonly double[] zoomLevels = { 0.4, 0.6, 0.7, 0.8, 0.9, 1, 1.2, 1.3, 1.4, 1.5, 1.6 };
        protected StatusStrip statusStrip1;
        protected ToolStripStatusLabel _lblToolStripCommand;
        protected ToolStripDropDownButton toolStripDropDownButton1;
        protected ToolStripMenuItem toolStripMenuItem1;
        protected ToolStripProgressBar toolStripProgressBar1;
        protected MenuStrip menuStrip1;
        protected Button button1;
        protected int selectedZoom = 5;

        public DesignView()
        {
            InitializeComponent();
            renderer = new DesignViewRenderer { };
            renderer.InitRenderer(m_controlToPaint);
            //attach even handles to the currently selected tool
            //m_designRenderer.MouseClick += m_selectedCommand.OnMouseClick;

            m_controlToPaint.Paint += renderer.RenderControlPaint;
            m_controlToPaint.MouseWheel += m_controlToPaint_MouseWheel;

            m_selectedCommand = new NullCommand();

        }

        protected void UpdateSelectedCommand(ICommand newCommand)
        {
            m_controlToPaint.MouseDown -= m_selectedCommand.OnMouseDown;
            m_controlToPaint.MouseUp -= m_selectedCommand.OnMouseUp;
            m_controlToPaint.MouseMove -= m_selectedCommand.OnMouseMove;

            m_selectedCommand = newCommand;

            m_controlToPaint.MouseDown += m_selectedCommand.OnMouseDown;
            m_controlToPaint.MouseUp += m_selectedCommand.OnMouseUp;
            m_controlToPaint.MouseMove += m_selectedCommand.OnMouseMove;
        }

        private IContainer components;

        //private member Functions

        // Required designer variable.
        protected bool panning;
        protected int mouseDownX = 0;
        protected int mouseDownY = 0;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesignView));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.m_controlToPaint = new SharpDX.Windows.RenderControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._lblToolStripCommand = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.m_controlToPaint.Location = new System.Drawing.Point(0, 27);
            this.m_controlToPaint.Name = "m_controlToPaint";
            this.m_controlToPaint.Size = new System.Drawing.Size(1265, 664);
            this.m_controlToPaint.TabIndex = 1;


            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lblToolStripCommand,
            this.toolStripDropDownButton1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 741);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1289, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _lblToolStripCommand
            // 
            this._lblToolStripCommand.Name = "_lblToolStripCommand";
            this._lblToolStripCommand.Size = new System.Drawing.Size(130, 17);
            this._lblToolStripCommand.Text = "No Command Selected";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1289, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(396, 695);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DesignView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.m_controlToPaint);
            this.Name = "DesignView";
            this.Size = new System.Drawing.Size(1289, 763);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        /*
        protected void m_controlToPaint_MouseDown(object sender, MouseEventArgs e)
        {
            this.MouseDown
        }
        
        protected void m_controlToPaint_MouseUp(object sender, MouseEventArgs e)
        {
            panning = false;
            keyDown = false;
        }

        protected void m_controlToPaint_MouseMove(object sender, MouseEventArgs e)
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
        */
        protected void m_controlToPaint_MouseWheel(object sender, MouseEventArgs e)
        {

            selectedZoom += e.Delta / 120;

            if (selectedZoom >= zoomLevels.Length)
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

        protected void m_controlToPaint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.G)
            {
                keyDown = true;
            }
        }
        
        protected void UpdateControlSelectedLabel(string control)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                _lblToolStripCommand.Text = control;
            }));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                UpdateControlSelectedLabel("greckles");
            });
        }

        public void AddObject(Point location, Size2 size)
        {
            renderer.AddItem(location, size);
        }
    }
}
