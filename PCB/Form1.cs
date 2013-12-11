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
using PCB.Tools;

namespace PCB
{
    public partial class Form1 : Form
    {
        private ICommand _selectedCommand = new NullCommand();

        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetCommand(new AddComponent());
        }

        private void SetCommand(ICommand newCommand)
        {
            if(newCommand == _selectedCommand)
                return;

            designView1.MouseDown -= _selectedCommand.OnMouseDown;
            designView1.MouseClick -= _selectedCommand.OnMouseClick;
            designView1.MouseUp -= _selectedCommand.OnMouseUp;

            _selectedCommand = newCommand;
            Console.WriteLine("Setting new command");

            designView1.MouseDown += _selectedCommand.OnMouseDown;
            designView1.MouseClick += _selectedCommand.OnMouseClick;
            designView1.MouseUp += _selectedCommand.OnMouseUp;
        }
    }
}
