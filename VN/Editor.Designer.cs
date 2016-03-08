namespace VN
{
    partial class EditorWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorWindow));
            this.BGs_Event = new System.Windows.Forms.PictureBox();
            this.Code = new System.Windows.Forms.RichTextBox();
            this.Say = new System.Windows.Forms.PictureBox();
            this.NameAlone = new System.Windows.Forms.Label();
            this.RenderText = new System.Windows.Forms.Label();
            this.volumeSlider = new System.Windows.Forms.TrackBar();
            this.AudioPlay = new System.Windows.Forms.Button();
            this.AudioStop = new System.Windows.Forms.Button();
            this.BUS110 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.BGs_Event)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Say)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // BGs_Event
            // 
            this.BGs_Event.BackColor = System.Drawing.Color.Transparent;
            this.BGs_Event.Location = new System.Drawing.Point(12, 12);
            this.BGs_Event.Name = "BGs_Event";
            this.BGs_Event.Size = new System.Drawing.Size(800, 600);
            this.BGs_Event.TabIndex = 5;
            this.BGs_Event.TabStop = false;
            // 
            // Code
            // 
            this.Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Code.Font = new System.Drawing.Font("Playtime Cyrillic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Code.Location = new System.Drawing.Point(12, 618);
            this.Code.Name = "Code";
            this.Code.Size = new System.Drawing.Size(800, 169);
            this.Code.TabIndex = 6;
            this.Code.Text = "";
            this.Code.WordWrap = false;
            this.Code.Click += new System.EventHandler(this.PicUpd);
            this.Code.TextChanged += new System.EventHandler(this.CodeUpd);
            // 
            // Say
            // 
            this.Say.BackColor = System.Drawing.Color.Transparent;
            this.Say.Cursor = System.Windows.Forms.Cursors.Default;
            this.Say.Location = new System.Drawing.Point(12, 440);
            this.Say.Name = "Say";
            this.Say.Size = new System.Drawing.Size(800, 160);
            this.Say.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Say.TabIndex = 8;
            this.Say.TabStop = false;
            // 
            // NameAlone
            // 
            this.NameAlone.BackColor = System.Drawing.Color.Transparent;
            this.NameAlone.Font = new System.Drawing.Font("Playtime Cyrillic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameAlone.ForeColor = System.Drawing.Color.White;
            this.NameAlone.Location = new System.Drawing.Point(28, 450);
            this.NameAlone.Name = "NameAlone";
            this.NameAlone.Size = new System.Drawing.Size(468, 33);
            this.NameAlone.TabIndex = 10;
            // 
            // RenderText
            // 
            this.RenderText.BackColor = System.Drawing.Color.Transparent;
            this.RenderText.Font = new System.Drawing.Font("Playtime Cyrillic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RenderText.ForeColor = System.Drawing.Color.White;
            this.RenderText.Location = new System.Drawing.Point(28, 492);
            this.RenderText.Name = "RenderText";
            this.RenderText.Size = new System.Drawing.Size(784, 102);
            this.RenderText.TabIndex = 11;
            // 
            // volumeSlider
            // 
            this.volumeSlider.AutoSize = false;
            this.volumeSlider.LargeChange = 1;
            this.volumeSlider.Location = new System.Drawing.Point(12, 793);
            this.volumeSlider.Maximum = 100;
            this.volumeSlider.Name = "volumeSlider";
            this.volumeSlider.Size = new System.Drawing.Size(708, 41);
            this.volumeSlider.TabIndex = 12;
            this.volumeSlider.TickFrequency = 100;
            this.volumeSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.volumeSlider.Value = 50;
            this.volumeSlider.Scroll += new System.EventHandler(this.volume_Scroll);
            // 
            // AudioPlay
            // 
            this.AudioPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AudioPlay.Image = ((System.Drawing.Image)(resources.GetObject("AudioPlay.Image")));
            this.AudioPlay.Location = new System.Drawing.Point(726, 794);
            this.AudioPlay.Name = "AudioPlay";
            this.AudioPlay.Size = new System.Drawing.Size(40, 40);
            this.AudioPlay.TabIndex = 13;
            this.AudioPlay.UseVisualStyleBackColor = true;
            this.AudioPlay.Click += new System.EventHandler(this.AudioPlay_Click);
            // 
            // AudioStop
            // 
            this.AudioStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AudioStop.Image = ((System.Drawing.Image)(resources.GetObject("AudioStop.Image")));
            this.AudioStop.Location = new System.Drawing.Point(772, 794);
            this.AudioStop.Name = "AudioStop";
            this.AudioStop.Size = new System.Drawing.Size(40, 40);
            this.AudioStop.TabIndex = 14;
            this.AudioStop.UseVisualStyleBackColor = true;
            this.AudioStop.Click += new System.EventHandler(this.AudioStop_Click);
            // 
            // BUS110
            // 
            this.BUS110.AutoSize = true;
            this.BUS110.Location = new System.Drawing.Point(713, 841);
            this.BUS110.Name = "BUS110";
            this.BUS110.Size = new System.Drawing.Size(89, 13);
            this.BUS110.TabIndex = 15;
            this.BUS110.TabStop = true;
            this.BUS110.Text = "© BUS110, 2016";
            this.BUS110.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BUS110_LinkClicked);
            // 
            // EditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(824, 863);
            this.Controls.Add(this.BUS110);
            this.Controls.Add(this.AudioStop);
            this.Controls.Add(this.AudioPlay);
            this.Controls.Add(this.volumeSlider);
            this.Controls.Add(this.RenderText);
            this.Controls.Add(this.NameAlone);
            this.Controls.Add(this.Say);
            this.Controls.Add(this.Code);
            this.Controls.Add(this.BGs_Event);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditorWindow";
            this.ShowIcon = false;
            this.Text = "Ren\'sB on C#";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BGs_Event)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Say)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox Code;
        private System.Windows.Forms.PictureBox Say;
        private System.Windows.Forms.Label NameAlone;
        private System.Windows.Forms.TrackBar volumeSlider;
        private System.Windows.Forms.Button AudioPlay;
        private System.Windows.Forms.Button AudioStop;
        public System.Windows.Forms.PictureBox BGs_Event;
        public System.Windows.Forms.Label RenderText;
        private System.Windows.Forms.LinkLabel BUS110;
    }
}

