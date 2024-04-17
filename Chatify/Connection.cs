﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace Chatify
{
    internal class Connection
    {  
        //forms
        private Label label6;
        private ListBox listBox1;

        //network
        public string ip;
        public int port;

        public bool is_connected;

        TcpClient client;
        NetworkStream stream;

        public Connection(string address, int server_port,Label label, ListBox listBox) 
        {
            ip = address;
            port = server_port;

            this.label6 = label;
            this.listBox1 = listBox;
        }

        public void Connect()
        {
            try
            {
                client = new TcpClient(ip, port);
                stream = client.GetStream();
                is_connected = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); is_connected = false; }
            
        }
        public void Disconnect()
        {
            try
            {
                Send_message("!disc");

                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose(); 
                }

                if (client != null)
                {
                    client.Close();
                }
                Form2 form2 = Application.OpenForms["Form2"] as Form2;
                if (form2 == null) { form2 = new Form2(); }
                form2.Show();
                is_connected = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disconnecting: " + ex.Message);
            }
        }
        public void Send_message(string message)
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
        public void Send_message()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("error sending image" + ex.Message);
            }
        }
        public void Listen()
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
    }
}