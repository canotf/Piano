using CCWin;
using System;

namespace PinaoUI.As {
    public partial class CACodeAbout : Skin_DevExpress {
        public CACodeAbout() {
            InitializeComponent();
        }
        /// <summary>
        /// 加载窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AsForm_Load(object sender, EventArgs e) {
            EXEName.Text = "Piano T-1.0.0";
        }
        /// <summary>
        /// 添加好友
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void emailLB_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("iexplore.exe", "tencent://message/?Menu=yes&uin=2075383131&Service=300&sigT=45a1e5847943b64c6ff3990f8a9e644d2b31356cb0b4ac6b24663a3c8dd0f8aa12a595b1714f9d45");

        }
        /// <summary>
        /// 开源链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void source_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/cctvadmin/");
        }

        private void label1_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://cacode.ren/");
        }
    }
}
