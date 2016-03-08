using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using WMPLib;

namespace VN
{
    public static class MainClass
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EditorWindow());
        }
    }

    public class RenSB
    {
        public static WindowsMediaPlayer wmp = new WindowsMediaPlayer();

        public static Font Playtime;
        public static Font PlaytimeSmall;

        public const string ProjectPath = "C://Users/Никита/Dropbox/Приложения/smart BASIC/Katawa port/Katawa/Katawa Shoujo/";
        public const string Font = ProjectPath + "Font/playtime_cyr2.ttf";
        public const string Scenarios = ProjectPath + "Scenario/";
        public const string BGs = ProjectPath + "BGs/";
        public const string Events = ProjectPath + "Events/";
        public const string Sprites = ProjectPath + "Sprites/";
        public const string Music = ProjectPath + "Music/";
        public const string UI = ProjectPath + "UI/";
        public static string MusicURL;
        public static int[] Coordinates = new int[0];
        public static string[] SpriteTag = new string[0];
        public static string[] LoadedSpritesNames = new string[0];
        public static string[] LoadedSpritesPaths = new string[0];
        public static PictureBox Sprite = new PictureBox();

        public static string[] SCoords = new string[0];
        public static string[] SSprites = new string[0];

        public static int CurrentLine = 0;
        public static int LastLine = 0;
        public static int Index;

        public static string[] Loader(PictureBox BG, RichTextBox Code)
        {
            #region Сценарий
            string[] Scenario = File.ReadAllLines(Scenarios + Game.Scenario + ".txt");
            Code.Lines = Scenario;
            #endregion

            #region Шрифт
            PrivateFontCollection font = new PrivateFontCollection();
            font.AddFontFile(Font);

            Playtime = new Font(font.Families[0], 20);
            PlaytimeSmall = new Font(font.Families[0], 12);

            Code.Font = PlaytimeSmall;
            #endregion

            string[] Load = Directory.GetDirectories(Sprites);
            int LoadLength = Load.Length;
            int c = 0;
            for (int f = 0; f < LoadLength; f++)
            {
                string[] Additional = Directory.GetDirectories(Load[f]);
                if (Additional.Length > 0)
                {
                    foreach (string Add in Additional)
                    {
                        Array.Resize(ref Load, Load.Length + 1);
                        Load[LoadLength + c] = Add;
                        c++;
                    }
                }
            }

            c = 0;
            foreach (string path in Load)
            {
                String[] Files = Directory.GetFiles(path);
                foreach (string Pathy in Files)
                {
                    Array.Resize(ref LoadedSpritesPaths, LoadedSpritesPaths.Length + 1);
                    Array.Resize(ref LoadedSpritesNames, LoadedSpritesNames.Length + 1);
                    LoadedSpritesPaths[c] = Pathy;
                    LoadedSpritesNames[c] = Pathy.Remove(0, path.Length + 1);
                    c++;
                }
            }
            return Scenario;
        }

        public static string[] ScenarioParser(string String)
        {
            return String.Split('|');
        }

        public static void CodeHighlight(RichTextBox Code, bool onestring = true)
        {
            if (!onestring)
            {
                int LineIndex = 0;
                foreach (string Line in Code.Lines)
                {
                    int Index = Code.GetFirstCharIndexFromLine(LineIndex);

                    string[] Value = Code.Lines[LineIndex].Split('|');
                    int Length = Value.Length;

                    int startIndex = 0;
                    int x = 0;
                    do
                    {
                        int DefIndex = Line.IndexOf('|', startIndex);
                        Code.Select(Index + DefIndex, 1);
                        Code.SelectionColor = Color.Red;
                        startIndex = DefIndex + 1;
                        x++;
                    } while (x < Length - 1);

                    Code.SelectionStart = 0;
                    Code.DeselectAll();
                    LineIndex++;
                }
            }
            else
            {
                int Index = Code.GetFirstCharIndexOfCurrentLine();
                int LineIndex = Code.GetLineFromCharIndex(Index);
                string Line = Code.Lines[LineIndex];
                string[] Value = Code.Lines[LineIndex].Split('|');
                int Length = Value.Length;
                int Pos = Code.SelectionStart;
                Code.SelectionLength = 0;
                int startIndex = 0;
                int x = 0;
                do
                {
                    int DefIndex = Line.IndexOf('|', startIndex);
                    Code.Select(Index + DefIndex, 1);
                    Code.SelectionColor = Color.Red;
                    startIndex = DefIndex + 1;
                    x++;
                } while (x < Length - 1);

                Code.SelectionStart = Pos;
                Code.SelectionLength = 0;
                Code.SelectionColor = Color.Black;
                Code.DeselectAll();
            }
        }

        public static void Preview(int LineIndex, RichTextBox Code, PictureBox BG, PictureBox Say, Label NameAlone, Label Render)
        {
            string Line = Code.Lines[LineIndex];
            string[] Value = Line.Split('|');
            string Method = Value[0];

            if (Method == "BG")
            {
                Scripts.BG(Value, BG);
            }

            if (Method == "1")
            {
                Scripts.Alone(Value, Say, NameAlone, Render);
            }

            if (Method == "2")
            {
                Scripts.Together(Value, Say);
            }

            if (Method == "Music")
            {
                try
                {
                    RenSB.MusicURL = RenSB.Music + Value[1] + ".mp3";
                }
                catch { }
            }

            if (Method == "Sprite")
            {
                Scripts.Sprite(Value, BG, Say);
            }
        }

        public class Scripts
        {
            public static bool BG(string[] Value, PictureBox BG)
            {
                string BGName;
                try
                {
                    //Фон существует?
                    BGName = Value[1];
                    BG.Image = new Bitmap(BGs + Value[1] + ".jpg");
                }
                catch
                {
                    //Нет -> Ставим фон "фон не найден"
                    BGName = null;
                    BG.Image = new Bitmap(BGs + "_bg_missing.png");
                }
                return true;
            }

            public static bool Alone(string[] Value, PictureBox Say, Label Name, Label Text)
            {
                try
                {
                    Name.Text = Value[1];
                    Text.Text = Value[2];
                    Say.Image = new Bitmap(UI + "bg-say.png");
                }
                catch
                {

                }
                return true;
            }

            public static bool Together(string[] Value, PictureBox Say, Label[] Name = null, Label[] Text = null)
            {
                try
                {
                    Say.Image = new Bitmap(UI + "bg-doublespeak.png");
                }
                catch
                {

                }
                return true;
            }

            public static bool Sprite(string[] Value, PictureBox BG, PictureBox Say)
            {
                Image tmp;
                if (Value[3] == "show")
                {
                    string[] Sprites = Value[1].Split('&');
                    string[] Coords = Value[4].Split('&');
                    int LastLength = SpriteTag.Length;
                    //Парсим строчку до конца
                    for (int c = 0; c < Coords.Length; c++)
                    {
                        if (Array.IndexOf(SpriteTag, Sprites[c]) == -1) //Поиск спрайта
                        {
                            //Если он не показан, показываем его
                            Array.Resize(ref SpriteTag, SpriteTag.Length + 1); Array.Resize(ref SCoords, SCoords.Length + 1); Array.Resize(ref SSprites, SSprites.Length + 1);
                            SpriteTag[LastLength + c] = Sprites[c];
                            SSprites[LastLength + c] = Sprites[c];
                            SCoords[LastLength + c] = Coords[c];
                        }
                    }
                }

                if (Value[3] == "swap")
                {
                    string[] After = Value[1].Split('&');
                    string[] Before = Value[2].Split('&');
                    string[] Coords = Value[4].Split('&');
                    //Парсим...
                    for (int c = 0; c < Coords.Length; c++)
                    {
                        if (Array.IndexOf(SpriteTag, Before[c]) > -1) //Поиск спрайта
                        {
                            int Index = Array.IndexOf(SpriteTag, Before[c]);
                            //Если он показан, меняем его
                            SpriteTag[Index] = After[c];
                            SSprites[Index] = After[c];
                            SCoords[Index] = Coords[c];
                        }
                    }
                }

                if (Value[3] == "hide")
                {
                    string[] Sprites = Value[1].Split('&');
                    int LastLength = SpriteTag.Length;
                    //Парсим...
                    for (int c = 0; c < Sprites.Length; c++)
                    {
                        if (Array.IndexOf(SpriteTag, Sprites[c]) > -1) //Поиск спрайта
                        {
                            int Index = Array.IndexOf(SpriteTag, Sprites[c]);
                            //Если он показан, удаляем его

                            for (int z = Index; z < SpriteTag.Length - 1; z++)
                            {
                                SpriteTag[z] = SpriteTag[z + 1];
                                SSprites[z] = SSprites[z + 1];
                                SCoords[z] = SCoords[z + 1];
                            }
                            Array.Resize(ref SpriteTag, SpriteTag.Length - 1); Array.Resize(ref SSprites, SSprites.Length - 1); Array.Resize(ref SCoords, SCoords.Length - 1);
                        }
                    }
                }


                RenSB.Sprite.Image = new Bitmap(RenSB.Sprite.Width, RenSB.Sprite.Height);
                //Совмещаем спрацты в битмап
                Graphics g = Graphics.FromImage(RenSB.Sprite.Image);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
                for (int c = 0; c < SpriteTag.Length; c++)
                {
                    if (Array.IndexOf(RenSB.LoadedSpritesNames, SSprites[c] + ".png") > -1)
                    {
                        int SpriteIndex = Array.IndexOf(RenSB.LoadedSpritesNames, SSprites[c] + ".png");
                        tmp = Image.FromFile(RenSB.LoadedSpritesPaths[SpriteIndex]);
                    }
                    else
                    {
                        tmp = Image.FromFile(RenSB.Sprites + "_missing/_sprite_missing.png");
                    }
                    g.DrawImageUnscaled(tmp, Convert.ToInt32(Int32.Parse(SCoords[c]) / 1.28), 130);
                }
                RenSB.Sprite.Invalidate();
                return true;
            }

            public static void Reset(PictureBox say, Label RenderText, Label NameAlone)
            {
                Array.Resize(ref SpriteTag, 0); Array.Resize(ref SSprites, 0); Array.Resize(ref SCoords, 0);
                RenSB.Sprite.Image = new Bitmap(RenSB.Sprite.Width, RenSB.Sprite.Height);
                say.Image = new Bitmap(say.Width, say.Height);
                RenderText.Text = "";
                NameAlone.Text = "";
            }
        }
    }

    public static class Game
    {
        public static string Scenario = "Test1";
    }
}
