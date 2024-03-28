using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Chatify
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SoundPlayer my_soundplayer = new SoundPlayer();
            Task.Run(() => my_soundplayer.Play_Sound(my_soundplayer.start_sound));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
        static void filemover(string folder, string path)
        {
            try{Directory.Move(folder, path);}
            catch (IOException ex){Console.WriteLine($"Error moving directory: {ex.Message}");}
        }
    }
}