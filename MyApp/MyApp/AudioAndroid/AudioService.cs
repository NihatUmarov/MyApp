using System;
using Xamarin.Forms;
using Android.Media;
using Android.Content.Res;
using MyApp.Audio;
using System.Threading.Tasks;

[assembly: Dependency(typeof(AudioService))]
namespace MyApp.Audio
{
    public class AudioService : IAudio
    {
        public AudioService()
        {
        }

        public async void PlayAudioFile(string fileName)
        {

            var player = new MediaPlayer();
            var fd = Android.App.Application.Context.Assets.OpenFd(fileName);
            player.Prepared += (s, e) =>
            {
                player.Start();

            };
            player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
            player.Prepare();
            await Task.Delay(1000);
            player.Reset();
        }
    }
}