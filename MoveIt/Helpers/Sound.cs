using System;
using System.Windows;
using System.Windows.Resources;
using System.Windows.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace MoveIt.Helpers
{
    public class Sound
    {
        static Sound _singletonInstance;

        public static Sound Default { get { return _singletonInstance ?? (_singletonInstance = new Sound()); } }

        Sound()
        {
            // This code is needed to play SoundEffects (taken from Windows Phone code samples)
            DispatcherTimer XnaDispatchTimer = new DispatcherTimer();
            XnaDispatchTimer.Interval = TimeSpan.FromMilliseconds(50);
            XnaDispatchTimer.Tick += delegate { try { FrameworkDispatcher.Update(); } catch { } };
            XnaDispatchTimer.Start();
        }

        // Method taken from Windows Phone Code Samples
        public void Load(String SoundFilePath, out SoundEffect Sound)
        {
            Sound = null;

            try
            {
                StreamResourceInfo SoundFileInfo = App.GetResourceStream(new Uri(SoundFilePath, UriKind.Relative));
                Sound = SoundEffect.FromStream(SoundFileInfo.Stream);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Couldn't load sound " + SoundFilePath);
            }
        }
    }
}
