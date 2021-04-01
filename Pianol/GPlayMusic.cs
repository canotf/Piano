using System.IO;
using System.Media;

namespace PinaoUI {
    public class GPlayMusic {

        //private static LinkedList<System.Threading.Thread> list = new LinkedList<System.Threading.Thread>();

        /// <summary>
        /// 路径
        /// </summary>
        public string path = "";
        /// <summary>
        /// 传入播放路径
        /// </summary>
        /// <param name="path"></param>
        public GPlayMusic(string path) {
            this.path = path;
        }
        /// <summary>
        /// 线程的运行方法,类似重写Ranable类
        /// </summary>
        public void run() {
            if (path != null) {
                try {
                    SoundPlayer sp = new SoundPlayer();
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
                    sp.SoundLocation = fs.Name;// 给一个路径，
                    fs.Close();
                    sp.Play();// 播放
                } catch {
                    /**
                     * to avoid errors
                     * I deleted the error log
                     * as the saying goes, out of sight, out of mind
                     * 
                     * 为了避免出现错误
                     * 我把错误日志删了
                     * 俗话说，眼不见心不烦
                     */
                }
            }
        }
    }
}
