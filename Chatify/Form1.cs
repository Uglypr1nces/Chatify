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
    public partial class Chatify : Form
    {
        TcpClient client;
        NetworkStream stream;
        SoundPlayer my_soundplayer = new SoundPlayer();

        public string message = "";
        public string username { get; set; }
        public string server_address { get; set; }
        public string filepath {  get; set; }
        public int server_port { get; set; }

        public bool is_connected = false;

        public Chatify()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            label5.Text = server_address;
            label7.Text = username;
            try
            {
                pictureBox1.Load(filepath);
                InitializeConnection(server_address, server_port);
                send($"{username} joined");
                is_connected = true;
                Task.Run(() => recieve());
            }
            catch (Exception ex)
             {
                MessageBox.Show(Convert.ToString(ex));
                Form2 form2 = Application.OpenForms["Form2"] as Form2;
                if (form2 == null) { form2 = new Form2(); }
                form2.Show();
                this.Close();
            }
        }
        public void InitializeConnection(string address, int port)
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
            if (is_connected)
            {
                try
                {
                    int byteCount = Encoding.ASCII.GetByteCount(message);
                    byte[] senddata = Encoding.ASCII.GetBytes(message);

                    stream.Write(senddata, 0, senddata.Length);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
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

                    if (response.Contains("afXMZhjvchs88vjls.g87satv0q,.7fg"))
                    {
                        label6.Invoke((MethodInvoker)delegate {
                            label6.Text = Convert.ToString(response[response.Length - 1]);
                            int number = Convert.ToInt32(label6.Text);
                            number = number / 2;
                            label6.Text = number.ToString();
                        });
                    }
                    else
                    {
                        listBox1.Invoke((MethodInvoker)delegate {
                            listBox1.Items.Add(response);
                        });
                    }
                    buffer = new char[1024];
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void Send_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                send($"{username}: {textBox1.Text}");
                textBox1.Text = "";
                Task.Run(() => my_soundplayer.Play_Sound(my_soundplayer.send_sound));
            }
        }
        private void Disconnect_Click(object sender, EventArgs e)
        {
            send("!disc");
            Form2 form2 = Application.OpenForms["Form2"] as Form2;
            if (form2 == null) { form2 = new Form2(); }
            Task.Run(() => my_soundplayer.Play_Sound(my_soundplayer.over_sound));
            form2.Show();
            this.Close();
        }
    }
}