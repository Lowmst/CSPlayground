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
        string audioFileName;
        AudioFileReader audioFile;
        WasapiOut wasapiOut;



        public MainWindow()
        {
            this.InitializeComponent();          
        }

        //private async void myButton_Click(object sender, RoutedEventArgs e)
        //{
        //    //myButton.Content = "Clicked";

        //    var filepicker = new FilePicker(this);

        //    audioFileName = filepicker.GetFile(new string[] { "*" });
        //    FileName.Text = audioFileName;

        //    await Task.Run(() =>
        //    {
        //        using (var wasapiOut = new WasapiOut())
        //        using (var audioFile = new AudioFileReader(audioFileName))
        //        {
        //            wasapiOut.Init(audioFile);
        //            wasapiOut.Play();

        //            while (wasapiOut.PlaybackState == PlaybackState.Playing)
        //            {
        //                Task.Delay(100).Wait();
        //            }
        //        }
        //    });
        //}

        private void FilePick_Click(object sender, RoutedEventArgs e)
        {
            var filepicker = new FilePicker(this);

            audioFileName = filepicker.GetFile(new string[] { "*" });

            if (audioFileName != null)
            {
                FileNameText.Text = audioFileName;
                this.audioFile = new AudioFileReader(audioFileName);
                if (wasapiOut != null)
                {
                    wasapiOut.Dispose();
                }
                wasapiOut = new WasapiOut();
                wasapiOut.PlaybackStopped += (sender, e) =>
                {
                    audioFile.Position = 0;
                };
                wasapiOut.Init(audioFile);
            }
            else
            {
                MsgBox("未打开文件");
            }
        }

        private async void Play_Click(object sender, RoutedEventArgs e)
        {
            
            wasapiOut.Play();
            await Task.Run(
                () =>
                {
                    while (wasapiOut.PlaybackState == PlaybackState.Playing)
                    {
                        Task.Delay(100).Wait();
                    }
                }
            );
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            wasapiOut.Pause();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            wasapiOut.Stop();
            //audioFile.Position = 0;
        }

        private async void MsgBox(String content)
        {
            ContentDialog dialog = new ContentDialog();
            dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
            dialog.XamlRoot = Root.XamlRoot;
            dialog.Content = content;
            dialog.CloseButtonText = "OK";
            var result = await dialog.ShowAsync();
        }
    }
}
