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
        public string username { get; set;  }
        public string filepath { get; set; }
        public string ip { get; set; }
        public int port { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            ip = textBox2.Text;
            port = Convert.ToInt32(textBox3.Text);

            Form1 form1 = new Form1();
            form1.Show();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        private void picture_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            if(openFileDialog.ShowDialog() == DialogResult.OK){filepath = openFileDialog.FileName;MessageBox.Show(filepath);}
        }
    }
}
