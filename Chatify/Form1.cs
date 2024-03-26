using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Chatify
{
    public partial class Form1 : Form
    {
        TcpClient client;
        NetworkStream stream;

        public string message = "";
        public string username { get; set; }
        public string server_address { get; set; }
        public string filepath {  get; set; }
        public int server_port { get; set; }

        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            label5.Text = username;
            pictureBox1.Load(filepath);
        }
        private void InitializeConnection(string address, int port)
        {
            try
            {
                client = new TcpClient(address, port);
                stream = client.GetStream();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void send(string message)
        {
            try
            {
                int byteCount = Encoding.ASCII.GetByteCount(message);
                byte[] senddata = Encoding.ASCII.GetBytes(message);

                stream.Write(senddata, 0, senddata.Length);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void recieve()
        {
            try
            {
                StreamReader sr = new StreamReader(stream);
                char[] buffer = new char[1024];
                int bytesRead;

                while ((bytesRead = sr.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string response = new string(buffer, 0, bytesRead);
                    buffer = new char[1024];
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void Send_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
        }
        private void Disconnect_Click(object sender, EventArgs e)
        {

        }
    }
}