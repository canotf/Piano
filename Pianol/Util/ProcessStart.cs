using System.Diagnostics;

namespace PinaoUI.Util {
    /// <summary>
    /// 进程开启和关闭
    /// </summary>
    public class ProcessStart {
        /// <summary>
        /// 通过url打开进程
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Process processStart(string url) {
            Process process = new Process();
            process = Process.Start(url);
            return process;
        }
        /// <summary>
        /// 关闭进程
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        public static bool processStop(Process process) {
            try {
                process.Kill();
                return true;
            } catch (System.Exception) {
                return false;
            }
        }
    }
}
