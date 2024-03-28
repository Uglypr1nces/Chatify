using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatify
{
    internal class SoundPlayer
    {
        public string start_sound = "C:\\Users\\aqua\\source\\repos\\Chatify\\content\\sounds\\start.mp3";
        public string connect_sound = "C:\\Users\\aqua\\source\\repos\\Chatify\\content\\sounds\\dingt.mp3";
        public SoundPlayer() 
        {

        }
        public void Play_Sound(string path)
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
    }
}
