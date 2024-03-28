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
            //playSimpleSound(starting_sound);
        }

        public string username = "";
        public string filepath = "";
        public string ip = "";
        public int port = 0;

        private void playSimpleSound(string path)
        {
            try
            {
                using (var audioFile = new AudioFileReader(path))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing sound: " + ex.Message);
            }
        }
        private void Connect_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            ip = textBox2.Text;

            try
            {
                port = Convert.ToInt32(textBox3.Text);
                Form1 form1 = Application.OpenForms["Form1"] as Form1;
                if (form1 == null) { form1 = new Form1(); }

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(ip) && !string.IsNullOrEmpty(filepath))
                {
                    try
                    {
                        form1.username = username;
                        form1.server_address = ip;
                        form1.server_port = port;
                        form1.filepath = filepath;

                        client = new TcpClient(ip, port);
                        stream = client.GetStream();

                        playSimpleSound(connect_sound);
                        form1.Show();
                        this.Hide();
                    }
                    catch (SocketException ex)
                    {
                        MessageBox.Show($"Failed to connect to server: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all fields before connecting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("The port must be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picture_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) { filepath = openFileDialog.FileName; picture_select.Text = filepath;}
        }
    }
}