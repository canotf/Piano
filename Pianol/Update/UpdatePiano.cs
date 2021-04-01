using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Pinaol.Update {
    public partial class UpdatePiano : Form {
        FileStream file = null;
        bool aa = false;
        Download down = new Download();
        public UpdatePiano() {
            InitializeComponent();
            try {
                if (File.Exists("../Piano.exe")) {
                    File.Delete("../Piano.exe");
                } else {
                    File.Create("../Piano.exe");
                }
                file = new FileStream("../Piano.exe", FileMode.Open);
            } catch (Exception e) {

            }
            new Thread(a).Start();
            progressBar1.Maximum = 123886133;
        }
        private void a() {
            aa = down.getFileFromHttpWebServer("http://www.adminznh.ren/File/Piano.exe", null, null, "../Piano.exe");
        }

        private void timer1_Tick(object sender, EventArgs e) {
            progressBar1.Value = Convert.ToInt32(file.Length);
            if (aa) {
                this.Close();
            }
        }
    }
}
