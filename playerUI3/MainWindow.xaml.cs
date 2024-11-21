using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

using NAudio;
using NAudio.CoreAudioApi;
using NAudio.MediaFoundation;
using NAudio.Wave;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace playerUI3
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        string audioFileName = "";
        

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            //myButton.Content = "Clicked";

            var filepicker = new FilePicker(this);

            audioFileName = filepicker.GetFile(new string[] { ".mp3", ".wav", ".flac", ".m4a" });
            FileName.Text = audioFileName;

            await Task.Run(() =>
            {
                using (var wasapiOut = new WasapiOut())
                using (var audioFile = new AudioFileReader(audioFileName))
                {
                    wasapiOut.Init(audioFile);
                    wasapiOut.Play();

                    while (wasapiOut.PlaybackState == PlaybackState.Playing)
                    {
                        Task.Delay(100).Wait();
                    }
                }
            });
        }
    }
}
