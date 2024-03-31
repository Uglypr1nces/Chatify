using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatify
{
    internal class SoundPlayer
    {
        public string start_sound = Path.Combine(Application.StartupPath, "content", "sounds", "start.mp3");
        public string connect_sound = Path.Combine(Application.StartupPath, "content", "sounds", "ding.mp3");
        public string send_sound = Path.Combine(Application.StartupPath, "content", "sounds", "send.wav");
        public string over_sound = Path.Combine(Application.StartupPath, "content", "sounds", "over.wav");
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
