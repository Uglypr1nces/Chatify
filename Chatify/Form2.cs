using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using NAudio.Wave;

namespace Chatify
{
    public partial class Form2 : Form
    {
        TcpClient client;
        NetworkStream stream;

        //audio files
        public string starting_sound = Path.Combine(Application.StartupPath, "content/sounds/start.mp3");
        public string connect_sound = Path.Combine(Application.StartupPath, "content/sounds/ding.mp3");

        public Form2()
        {
            InitializeComponent();
            try
            {
                Image myimage = new Bitmap(Path.Combine(Application.StartupPath, "content/pictures/bg4k.jpg"));
                this.BackgroundImage = myimage;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.SetStyle(
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.DoubleBuffer,
                    true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"couldnt change background: {ex.Message}");
            }
        }

        public string username = "";
        public string filepath = "";
        public string ip = "";
        public int port = 0;
        SoundPlayer my_soundplayer = new SoundPlayer();

        private void Connect_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 15 && textBox2.Text.Length != 16)
            {
                username = textBox1.Text;
                ip = textBox2.Text;

                try
                {
                    port = Convert.ToInt32(textBox3.Text);

                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(ip) && !string.IsNullOrEmpty(filepath))
                    {
                        try
                        {
                            Chatify form1 = Application.OpenForms["Form1"] as Chatify;
                            if (form1 == null) { form1 = new Chatify(username,ip,filepath,port); }

                            Task.Run(() => my_soundplayer.Play_Sound(my_soundplayer.connect_sound));
                            form1.Show();
                            this.Hide();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to open form: {ex.Message}");
                        }
                    }
                    else{MessageBox.Show("Please fill in all fields before connecting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);}
                }
                catch (FormatException){MessageBox.Show("The port must be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);}
            }
            else{MessageBox.Show("Username Lenght needs to be below 10 and server address lenght must be 17");}
        }
        private void picture_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) { filepath = openFileDialog.FileName; picture_select.Text = filepath;}
        }
    }
}