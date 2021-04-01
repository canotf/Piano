using CCWin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace PinaoUI.Theme {
    public partial class CustomTheme : Skin_DevExpress {
        private static OpenFileDialog open = new OpenFileDialog();
        private static List<PictureBox> whiteList = new List<PictureBox>();
        private static List<PictureBox> blackList = new List<PictureBox>();
        private static string topWhitePatterm = "^[b]";//上边白色正则表达式
        private static string topBlackPatterm = "^[a]";//上边黑色正则表达式
        private Color color_white = Color.White;
        private Color color_black = Color.Black;
        private string whitePic = "$";
        private string blackPic = "$";
        private Color color_keys = Color.DarkSlateGray;
        /// <summary>
        /// 初始化白色
        /// </summary>
        private void iniWhite() {
            whiteList.Add(w1);
            whiteList.Add(w2);
            whiteList.Add(w3);
            whiteList.Add(w4);
            whiteList.Add(w5);
            whiteList.Add(w6);
            whiteList.Add(w7);
        }
        /// <summary>
        /// 初始化黑色
        /// </summary>
        private void iniBlack() {
            blackList.Add(bc1);
            blackList.Add(bc2);
            blackList.Add(bc3);
            blackList.Add(bc4);
            blackList.Add(bc5);
        }

        /// <summary>
        /// 构造
        /// </summary>
        public CustomTheme() {
            InitializeComponent();
            iniWhite();
            iniBlack();
            open.Filter = "png图片|*.png|jpg|*.jpg";
            open.Title = "请选择背景";
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomTheme_Load(object sender, EventArgs e) {
            loadTheme();
        }
        /// <summary>
        /// 修改白色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWhite_Click(object sender, EventArgs e) {
            string showText = wbcStyle(open, true, ref whitePic, ref color_white);
            try {
                showText = ColorTranslator.ToHtml(
                    Color.FromArgb(
                        (ColorTranslator.FromHtml(showText)
                        ).ToArgb())
                    );
            } catch {

            }
            tbWhite.Text = showText;
            if (Regex.IsMatch(showText.Substring(0, 1), "[A-Z]{1,}")) {
                //符合上图片
                foreach (var item in whiteList) {
                    item.BackgroundImage = Image.FromFile(whitePic);
                }
                panalControls(topPanal, topWhitePatterm, whitePic);
            } else {
                //不符合上底色
                foreach (var item in whiteList) {
                    item.BackColor = color_white;
                }
                panalControls(topPanal, topWhitePatterm, color_white);
            }
        }
        /// <summary>
        /// 修改黑色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBlack_Click(object sender, EventArgs e) {
            string showText = wbcStyle(open, true, ref blackPic, ref color_black);
            try {
                showText = ColorTranslator.ToHtml(
                    Color.FromArgb(
                        (ColorTranslator.FromHtml(showText)
                        ).ToArgb())
                    );
            } catch {

            }
            tbBlack.Text = showText;
            if (Regex.IsMatch(showText.Substring(0, 1), "[A-Z]{1,}")) {
                //符合上图片
                foreach (var item in blackList) {
                    item.BackgroundImage = Image.FromFile(blackPic);
                }
                panalControls(topPanal, topBlackPatterm, blackPic);
            } else {
                //不符合上底色
                foreach (var item in blackList) {
                    item.BackColor = color_black;
                }
                panalControls(topPanal, topBlackPatterm, color_black);
            }
        }
        /// <summary>
        /// 返回底图路径或底图颜色
        /// </summary>
        /// <param name="open">打开文件对话框</param>
        /// <param name="rbCheck">单选框是否选中某一个</param>
        /// <param name="copyPath">复制文件到目录</param>
        /// <param name="c">颜色</param>
        public string wbcStyle(OpenFileDialog open, bool rbCheck, ref string copyPath, ref Color c) {
            ColorDialog color = new ColorDialog();
            string text = "";
            if (rbCheck) {
                DialogResult dialogResult = color.ShowDialog();
                if (dialogResult == DialogResult.OK) {
                    c = color.Color;
                    text = ColorTranslator.ToHtml(c);
                }
            } else {
                DialogResult dialogResult = open.ShowDialog();
                string clickFile = open.FileName;
                string fileName = Path.GetFileName(clickFile);
                if (dialogResult == DialogResult.OK && clickFile != null && clickFile != "") {
                    copyPath = clickFile;
                    text = copyPath;
                }
            }
            return text;
        }
        /// <summary>
        /// 换颜色
        /// </summary>
        /// <param name="panel">控件</param>
        /// <param name="patterm">正则表达式</param>
        /// <param name="color">换成的颜色</param>
        public void panalControls(Panel panel, string patterm, Color color) {
            foreach (Control item in panel.Controls) {
                if (Regex.IsMatch(item.Name, patterm)) {
                    item.BackColor = color;
                }
            }
        }

        /// <summary>
        /// 换图片
        /// </summary>
        /// <param name="panel">控件</param>
        /// <param name="patterm">正则表达式</param>
        /// <param name="color">图片路径</param>
        public void panalControls(Panel panel, string patterm, string color) {
            foreach (Control item in panel.Controls) {
                if (Regex.IsMatch(item.Name, patterm)) {
                    item.BackgroundImage = Image.FromFile(color);
                }
            }
        }
        /// <summary>
        /// 按键换底色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKeysColor_Click(object sender, EventArgs e) {
            string a = "";
            string showText = wbcStyle(open, true, ref a, ref color_keys);
            try {
                showText = ColorTranslator.ToHtml(
                    Color.FromArgb(
                        (ColorTranslator.FromHtml(showText)
                        ).ToArgb())
                    );
            } catch {
            }
            panalControls(pn_Keys, "", ColorTranslator.FromHtml(showText));
        }
        /// <summary>
        /// 应用样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUseStyle_Click(object sender, EventArgs e) {
            try {
                XmlDocument doc = new XmlDocument();
                doc.Load("CustomTheme\\ThemeXML.xml");
                XmlNode root = doc.SelectSingleNode("/CACode");
                XmlNode lastChild = doc.SelectSingleNode("CACode").LastChild;
                int index = Convert.ToInt32(lastChild.Attributes["index"].Value);
                index++;
                XmlElement theme = doc.CreateElement("theme");
                theme.SetAttribute("index", (index).ToString());

                XmlElement data = doc.CreateElement("date");
                data.SetAttribute("time", DateTime.Now.ToString());
                theme.AppendChild(data);

                XmlElement whiteColor = doc.CreateElement("whiteColor");
                XmlElement whtieBackground = doc.CreateElement("whtieBackground");
                XmlElement blackColor = doc.CreateElement("blackColor");
                XmlElement blackBackground = doc.CreateElement("blackBackground");
                XmlElement keysColor = doc.CreateElement("keysColor");

                whiteColor.InnerText = ColorTranslator.ToHtml(color_white);
                whtieBackground.InnerText = whitePic;
                blackColor.InnerText = ColorTranslator.ToHtml(color_black);
                blackBackground.InnerText = blackPic;
                keysColor.InnerText = ColorTranslator.ToHtml(color_keys);

                data.AppendChild(whiteColor);
                data.AppendChild(whtieBackground);
                data.AppendChild(blackColor);
                data.AppendChild(blackBackground);
                data.AppendChild(keysColor);

                root.AppendChild(theme);

                doc.Save(Directory.GetCurrentDirectory() + "\\CustomTheme\\ThemeXML.xml");
                MessageBox.Show("成功");
            } catch {
                MessageBox.Show("请使用管理员身份运行Piano");
            }
        }
        /// <summary>
        /// 加载最后修改的主题
        /// </summary>
        private void loadTheme() {
            XmlDocument xml = new XmlDocument();
            try {
                xml.Load("CustomTheme\\ThemeXML.xml");
                implementTheme(xml.SelectSingleNode("CACode").LastChild);
            } catch {
                try {
                    xml.Load("CustomTheme\\ThemeXML.xml");
                    implementTheme(xml.SelectSingleNode("CACode").FirstChild);
                } catch {
                    MessageBox.Show("文件受损！！！！！");
                }
            }
        }
        /// <summary>
        /// 默认主题
        /// </summary>
        private void defaultTheme() {
            XmlDocument xml = new XmlDocument();
            try {
                xml.Load("CustomTheme\\ThemeXML.xml");
                implementTheme(xml.SelectSingleNode("CACode").FirstChild);
            } catch {
                MessageBox.Show("文件受损！！！！！");
            }
        }

        private void implementTheme(XmlNode node) {
            try {
                XmlNode xmlNode = node.SelectSingleNode("date");
                string color_white = xmlNode.SelectSingleNode("whiteColor").InnerText;
                string pic_white = xmlNode.SelectSingleNode("whtieBackground").InnerText;
                string color_black = xmlNode.SelectSingleNode("blackColor").InnerText;
                string pic_black = xmlNode.SelectSingleNode("blackBackground").InnerText;
                string color_keys = xmlNode.SelectSingleNode("keysColor").InnerText;
                panalControls(topPanal, topWhitePatterm, ColorTranslator.FromHtml(color_white));
                foreach (var item in whiteList) {
                    item.BackColor = ColorTranslator.FromHtml(color_white);
                }
                if (pic_white != "$" && pic_white != "" && pic_white != null)
                    panalControls(topPanal, topWhitePatterm, pic_white);
                panalControls(topPanal, topBlackPatterm, ColorTranslator.FromHtml(color_black));
                foreach (var item in blackList) {
                    item.BackColor = ColorTranslator.FromHtml(color_black);
                }
                if (pic_black != "$" && pic_black != "" && pic_black != null)
                    panalControls(topPanal, topBlackPatterm, pic_black);
                panalControls(pn_Keys, "", ColorTranslator.FromHtml(color_keys));
            } catch {
                MessageBox.Show("请使用管理员身份运行Piano");
            }
        }
        /// <summary>
        /// 恢复默认单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefaultTheme_Click(object sender, EventArgs e) {
            defaultTheme();
        }
    }
}
