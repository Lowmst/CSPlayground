using NAudio;
using NAudio.CoreAudioApi;
using NAudio.MediaFoundation;
using NAudio.Wave;
using System.CommandLine;

namespace player
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                System.Console.WriteLine("Usage: player <filename>");
                return;
            }

            using (var wasapiOut = new WasapiOut(AudioClientShareMode.Exclusive, 100))
            using (var audioFile = new AudioFileReader(args[0]))
            {
                wasapiOut.Init(audioFile);
                wasapiOut.Play();

                while (wasapiOut.PlaybackState == PlaybackState.Playing)
                {
                    Task.Delay(100).Wait();
                }
            }
        }
    }
}