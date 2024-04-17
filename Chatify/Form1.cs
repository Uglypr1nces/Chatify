using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Chatify
{
    public partial class Chatify : Form
    {
        SoundPlayer my_soundplayer = new SoundPlayer();

        public string message = "";
        public string username;
        public string server_address;
        public string filepath;
        public int server_port;

        public string[] usernames = {};

        private Connection connection;
        public Chatify(string user, string address, string path, int port)
        {
            InitializeComponent();

            this.FormClosing += Chatify_FormClosing;
            this.username = user;
            this.server_address = address;
            this.filepath = path;
            this.server_port = port;

            connection = new Connection(server_address, server_port, label6, listBox1);
            connection.Connect();
        }
        private void Chatify_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Send_message(username + "Disconnected");
            connection.Disconnect();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                pictureBox1.Load(filepath);
                connection.Send_message($"{username} joined");
                Task.Run(() => connection.Listen());
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

        private void Send_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                connection.Send_message($"{username}: {textBox1.Text}");
                textBox1.Text = "";
                Task.Run(() => my_soundplayer.Play_Sound(my_soundplayer.send_sound));
            }
        }
        private void Disconnect_Click(object sender, EventArgs e)
        {
            Task.Run(() => my_soundplayer.Play_Sound(my_soundplayer.over_sound));
            connection.Disconnect();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}