using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatify
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        public string username = "";
        public string filepath = "";
        public string ip = "";
        public int port = 0;

        private void Connect_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            ip = textBox2.Text;
            port = Convert.ToInt32(textBox3.Text);

            Form1 form1 = Application.OpenForms["Form1"] as Form1;
            if (form1 == null){form1 = new Form1();}

            form1.username = username;
            form1.server_address = ip;
            form1.server_port = port;
            form1.filepath = filepath;

            form1.Show();
            this.Hide();
        }
        private void picture_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) { filepath = openFileDialog.FileName; picture_select.Text = filepath;}
        }
    }
}