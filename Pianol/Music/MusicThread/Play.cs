using System;
using System.IO;
using System.Media;

namespace Pinaol.Music.MusicThread {

    class Play {
        private static string path;
        public Play() {

        }
        public Play(string pathRef) {
            path = pathRef;
        }
        public void run() {
            if (path != null) {
                lock (this) {
                    try {
                        SoundPlayer sp = new SoundPlayer();
                        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
                        sp.SoundLocation = fs.Name;// 给一个路径，
                        fs.Close();
                        sp.Play();// 播放
                        sp.Dispose();//释放资源
                    } catch (Exception) {

                    }
                }
            }
        }
    }
}
