using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.IO;
using WMPLib;
using VN.Properties;

namespace VN
{
    public partial class EditorWindow : Form
    {
        static string[] scenario;
        static int length;
        public static IWin32Window win;

        public EditorWindow()
        {
            InitializeComponent();
            this.Say.Parent = RenSB.Sprite;
            this.Say.Location = new System.Drawing.Point(0, 440);
            this.NameAlone.Parent = this.Say;
            this.NameAlone.Location = new System.Drawing.Point(8, 10);
            this.RenderText.Parent = this.Say;
            this.RenderText.Location = new System.Drawing.Point(16, 46);

            //Настройка экрана спрайтов
            RenSB.Sprite.Parent = this.BGs_Event;
            RenSB.Sprite.Location = new Point(0, 0);
            RenSB.Sprite.Size = new Size(800, 600);
            RenSB.Sprite.Show();
            win = this;

            /* Шрифт
            RenSB.LoadFont();
            this.Code.Font = RenSB.Playtime;
             */

            scenario = RenSB.Loader(this.BGs_Event, this.Code, this.BUS110);
            length = scenario.Length;


            //Подсветка
            RenSB.CodeHighlight(this.Code, false);

            //Предпросмотр
            //RenSB.Preview(0, this.Code, this.BGs_Event, this.Say, this.NameAlone, this.RenderText);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RenSB.wmp.settings.volume = 50;
            RenSB.wmp.URL = null;
        }

        #region Переадресация...
        public void CodeUpd(object sender, EventArgs e)
        {
            RenSB.CodeHighlight(this.Code);
        }

        public void PicUpd(object sender, EventArgs e)
        {
            RenSB.LastLine = RenSB.CurrentLine;
            RenSB.CurrentLine = this.Code.GetLineFromCharIndex(this.Code.GetFirstCharIndexOfCurrentLine());

            if (RenSB.CurrentLine > RenSB.LastLine)
            {
                for (int c = RenSB.LastLine; c <= RenSB.CurrentLine; c++)
                {
                    RenSB.Preview(this.Code.GetLineFromCharIndex(this.Code.GetFirstCharIndexFromLine(c)), this.Code, this.BGs_Event, this.Say, this.NameAlone, this.RenderText);
                }
            }
            else
            {
                RenSB.Scripts.Reset(this.Say, this.RenderText, this.NameAlone);
                for (int c = 0; c <= RenSB.CurrentLine; c++)
                {
                    RenSB.Preview(this.Code.GetLineFromCharIndex(this.Code.GetFirstCharIndexFromLine(c)), this.Code, this.BGs_Event, this.Say, this.NameAlone, this.RenderText);
                }
            }
        }
        #endregion

        #region Плеер
        //Все просто, No Comments
        private void AudioPlay_Click(object sender, EventArgs e)
        {
                RenSB.wmp.URL = RenSB.MusicURL;
                RenSB.wmp.controls.play();
        }

        private void AudioStop_Click(object sender, EventArgs e)
        {
            RenSB.wmp.URL = null;
            RenSB.wmp.controls.stop();
        }

        private void volume_Scroll(object sender, EventArgs e)
        {
            RenSB.wmp.settings.volume = this.volumeSlider.Value;
        }
        #endregion

        private void BUS110_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/bus110");
        }
    }
}