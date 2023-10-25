namespace Guessgame
{
    partial class HomeGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeGame));
            GBAnmeldung = new GroupBox();
            ACSPasswort = new CheckBox();
            ABAbbrechen = new Button();
            ALPasswort = new Label();
            ALBenutzername = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            ABAnmeldung = new Button();
            GBRegistrierung = new GroupBox();
            checkBox3 = new CheckBox();
            RLPasswort2 = new Label();
            RLPasswort = new Label();
            RLBenutzername = new Label();
            RBAbbrechen = new Button();
            RBRegistrierung = new Button();
            RLLBed = new LinkLabel();
            checkBox2 = new CheckBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            HGBAnmeldung = new Button();
            HGBRegistrierung = new Button();
            GBAnmeldung.SuspendLayout();
            GBRegistrierung.SuspendLayout();
            SuspendLayout();
            // 
            // GBAnmeldung
            // 
            GBAnmeldung.BackColor = Color.Transparent;
            GBAnmeldung.Controls.Add(ACSPasswort);
            GBAnmeldung.Controls.Add(ABAbbrechen);
            GBAnmeldung.Controls.Add(ALPasswort);
            GBAnmeldung.Controls.Add(ALBenutzername);
            GBAnmeldung.Controls.Add(textBox2);
            GBAnmeldung.Controls.Add(textBox1);
            GBAnmeldung.Controls.Add(ABAnmeldung);
            GBAnmeldung.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            GBAnmeldung.ForeColor = Color.Black;
            GBAnmeldung.Location = new Point(12, 142);
            GBAnmeldung.Name = "GBAnmeldung";
            GBAnmeldung.Size = new Size(428, 215);
            GBAnmeldung.TabIndex = 0;
            GBAnmeldung.TabStop = false;
            GBAnmeldung.Visible = false;
            // 
            // ACSPasswort
            // 
            ACSPasswort.AutoSize = true;
            ACSPasswort.BackColor = Color.Transparent;
            ACSPasswort.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ACSPasswort.ForeColor = Color.Black;
            ACSPasswort.Location = new Point(162, 138);
            ACSPasswort.Name = "ACSPasswort";
            ACSPasswort.Size = new Size(18, 17);
            ACSPasswort.TabIndex = 6;
            ACSPasswort.UseVisualStyleBackColor = false;
            ACSPasswort.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // ABAbbrechen
            // 
            ABAbbrechen.BackColor = Color.Transparent;
            ABAbbrechen.BackgroundImageLayout = ImageLayout.None;
            ABAbbrechen.FlatAppearance.BorderColor = Color.LightSteelBlue;
            ABAbbrechen.FlatAppearance.BorderSize = 0;
            ABAbbrechen.FlatAppearance.CheckedBackColor = Color.LightSteelBlue;
            ABAbbrechen.FlatAppearance.MouseDownBackColor = Color.LightSteelBlue;
            ABAbbrechen.FlatAppearance.MouseOverBackColor = Color.LightSteelBlue;
            ABAbbrechen.FlatStyle = FlatStyle.Popup;
            ABAbbrechen.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ABAbbrechen.ForeColor = Color.Black;
            ABAbbrechen.Location = new Point(286, 172);
            ABAbbrechen.Name = "ABAbbrechen";
            ABAbbrechen.Size = new Size(118, 29);
            ABAbbrechen.TabIndex = 5;
            ABAbbrechen.UseVisualStyleBackColor = false;
            ABAbbrechen.Click += button2_Click;
            // 
            // ALPasswort
            // 
            ALPasswort.AutoSize = true;
            ALPasswort.BackColor = Color.Transparent;
            ALPasswort.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ALPasswort.ForeColor = Color.Black;
            ALPasswort.Location = new Point(6, 90);
            ALPasswort.Name = "ALPasswort";
            ALPasswort.Size = new Size(0, 18);
            ALPasswort.TabIndex = 4;
            // 
            // ALBenutzername
            // 
            ALBenutzername.AutoSize = true;
            ALBenutzername.BackColor = Color.Transparent;
            ALBenutzername.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ALBenutzername.ForeColor = Color.Black;
            ALBenutzername.Location = new Point(6, 61);
            ALBenutzername.Name = "ALBenutzername";
            ALBenutzername.Size = new Size(0, 18);
            ALBenutzername.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.LightSteelBlue;
            textBox2.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            textBox2.Location = new Point(162, 87);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(242, 26);
            textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.LightSteelBlue;
            textBox1.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(162, 58);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(242, 26);
            textBox1.TabIndex = 1;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // ABAnmeldung
            // 
            ABAnmeldung.BackColor = Color.Transparent;
            ABAnmeldung.BackgroundImageLayout = ImageLayout.None;
            ABAnmeldung.FlatAppearance.BorderColor = Color.LightSteelBlue;
            ABAnmeldung.FlatAppearance.BorderSize = 0;
            ABAnmeldung.FlatAppearance.CheckedBackColor = Color.LightSteelBlue;
            ABAnmeldung.FlatAppearance.MouseDownBackColor = Color.LightSteelBlue;
            ABAnmeldung.FlatAppearance.MouseOverBackColor = Color.LightSteelBlue;
            ABAnmeldung.FlatStyle = FlatStyle.Popup;
            ABAnmeldung.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ABAnmeldung.ForeColor = Color.Black;
            ABAnmeldung.Location = new Point(162, 172);
            ABAnmeldung.Name = "ABAnmeldung";
            ABAnmeldung.Size = new Size(118, 29);
            ABAnmeldung.TabIndex = 0;
            ABAnmeldung.UseVisualStyleBackColor = false;
            ABAnmeldung.Click += Button1_Click;
            // 
            // GBRegistrierung
            // 
            GBRegistrierung.BackColor = Color.Transparent;
            GBRegistrierung.Controls.Add(checkBox3);
            GBRegistrierung.Controls.Add(RLPasswort2);
            GBRegistrierung.Controls.Add(RLPasswort);
            GBRegistrierung.Controls.Add(RLBenutzername);
            GBRegistrierung.Controls.Add(RBAbbrechen);
            GBRegistrierung.Controls.Add(RBRegistrierung);
            GBRegistrierung.Controls.Add(RLLBed);
            GBRegistrierung.Controls.Add(checkBox2);
            GBRegistrierung.Controls.Add(textBox5);
            GBRegistrierung.Controls.Add(textBox4);
            GBRegistrierung.Controls.Add(textBox3);
            GBRegistrierung.FlatStyle = FlatStyle.Flat;
            GBRegistrierung.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            GBRegistrierung.ForeColor = Color.Black;
            GBRegistrierung.Location = new Point(12, 142);
            GBRegistrierung.Name = "GBRegistrierung";
            GBRegistrierung.Size = new Size(530, 232);
            GBRegistrierung.TabIndex = 1;
            GBRegistrierung.TabStop = false;
            GBRegistrierung.Visible = false;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.BackColor = Color.Transparent;
            checkBox3.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox3.ForeColor = Color.Black;
            checkBox3.Location = new Point(205, 148);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(18, 17);
            checkBox3.TabIndex = 10;
            checkBox3.UseVisualStyleBackColor = false;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // RLPasswort2
            // 
            RLPasswort2.AutoSize = true;
            RLPasswort2.BackColor = Color.Transparent;
            RLPasswort2.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            RLPasswort2.ForeColor = Color.Black;
            RLPasswort2.Location = new Point(12, 119);
            RLPasswort2.Name = "RLPasswort2";
            RLPasswort2.Size = new Size(0, 18);
            RLPasswort2.TabIndex = 9;
            // 
            // RLPasswort
            // 
            RLPasswort.AutoSize = true;
            RLPasswort.BackColor = Color.Transparent;
            RLPasswort.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            RLPasswort.ForeColor = Color.Black;
            RLPasswort.Location = new Point(12, 85);
            RLPasswort.Name = "RLPasswort";
            RLPasswort.Size = new Size(0, 18);
            RLPasswort.TabIndex = 8;
            // 
            // RLBenutzername
            // 
            RLBenutzername.AutoSize = true;
            RLBenutzername.BackColor = Color.Transparent;
            RLBenutzername.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            RLBenutzername.ForeColor = Color.Black;
            RLBenutzername.Location = new Point(12, 56);
            RLBenutzername.Name = "RLBenutzername";
            RLBenutzername.Size = new Size(0, 18);
            RLBenutzername.TabIndex = 7;
            // 
            // RBAbbrechen
            // 
            RBAbbrechen.BackColor = Color.Transparent;
            RBAbbrechen.BackgroundImageLayout = ImageLayout.None;
            RBAbbrechen.FlatAppearance.BorderColor = Color.LightSteelBlue;
            RBAbbrechen.FlatAppearance.BorderSize = 0;
            RBAbbrechen.FlatAppearance.CheckedBackColor = Color.LightSteelBlue;
            RBAbbrechen.FlatAppearance.MouseDownBackColor = Color.LightSteelBlue;
            RBAbbrechen.FlatAppearance.MouseOverBackColor = Color.LightSteelBlue;
            RBAbbrechen.FlatStyle = FlatStyle.Popup;
            RBAbbrechen.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            RBAbbrechen.ForeColor = Color.Black;
            RBAbbrechen.Location = new Point(328, 197);
            RBAbbrechen.Name = "RBAbbrechen";
            RBAbbrechen.Size = new Size(118, 29);
            RBAbbrechen.TabIndex = 6;
            RBAbbrechen.UseVisualStyleBackColor = false;
            RBAbbrechen.Click += button4_Click;
            // 
            // RBRegistrierung
            // 
            RBRegistrierung.BackColor = Color.Transparent;
            RBRegistrierung.BackgroundImageLayout = ImageLayout.None;
            RBRegistrierung.FlatAppearance.BorderColor = Color.LightSteelBlue;
            RBRegistrierung.FlatAppearance.BorderSize = 0;
            RBRegistrierung.FlatAppearance.CheckedBackColor = Color.LightSteelBlue;
            RBRegistrierung.FlatAppearance.MouseDownBackColor = Color.LightSteelBlue;
            RBRegistrierung.FlatAppearance.MouseOverBackColor = Color.LightSteelBlue;
            RBRegistrierung.FlatStyle = FlatStyle.Popup;
            RBRegistrierung.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            RBRegistrierung.ForeColor = Color.Black;
            RBRegistrierung.Location = new Point(205, 197);
            RBRegistrierung.Name = "RBRegistrierung";
            RBRegistrierung.Size = new Size(118, 29);
            RBRegistrierung.TabIndex = 5;
            RBRegistrierung.UseVisualStyleBackColor = false;
            RBRegistrierung.Click += Button3_Click;
            // 
            // RLLBed
            // 
            RLLBed.AutoSize = true;
            RLLBed.BackColor = Color.Transparent;
            RLLBed.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            RLLBed.ForeColor = Color.Black;
            RLLBed.Location = new Point(229, 176);
            RLLBed.Name = "RLLBed";
            RLLBed.Size = new Size(0, 18);
            RLLBed.TabIndex = 4;
            RLLBed.LinkClicked += linkLabel1_LinkClicked_1;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.BackColor = Color.Transparent;
            checkBox2.Enabled = false;
            checkBox2.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox2.ForeColor = Color.Black;
            checkBox2.Location = new Point(205, 174);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(18, 17);
            checkBox2.TabIndex = 3;
            checkBox2.UseVisualStyleBackColor = false;
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.LightSteelBlue;
            textBox5.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            textBox5.Location = new Point(204, 119);
            textBox5.Name = "textBox5";
            textBox5.PasswordChar = '*';
            textBox5.Size = new Size(242, 26);
            textBox5.TabIndex = 2;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.LightSteelBlue;
            textBox4.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            textBox4.Location = new Point(204, 87);
            textBox4.Name = "textBox4";
            textBox4.PasswordChar = '*';
            textBox4.Size = new Size(242, 26);
            textBox4.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.LightSteelBlue;
            textBox3.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            textBox3.ForeColor = Color.Black;
            textBox3.Location = new Point(204, 55);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(242, 26);
            textBox3.TabIndex = 0;
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // HGBAnmeldung
            // 
            HGBAnmeldung.BackColor = Color.Transparent;
            HGBAnmeldung.BackgroundImageLayout = ImageLayout.None;
            HGBAnmeldung.FlatAppearance.BorderColor = Color.LightSteelBlue;
            HGBAnmeldung.FlatAppearance.BorderSize = 0;
            HGBAnmeldung.FlatAppearance.CheckedBackColor = Color.LightSteelBlue;
            HGBAnmeldung.FlatAppearance.MouseDownBackColor = Color.LightSteelBlue;
            HGBAnmeldung.FlatAppearance.MouseOverBackColor = Color.LightSteelBlue;
            HGBAnmeldung.FlatStyle = FlatStyle.Popup;
            HGBAnmeldung.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            HGBAnmeldung.ForeColor = Color.Black;
            HGBAnmeldung.Location = new Point(82, 12);
            HGBAnmeldung.Name = "HGBAnmeldung";
            HGBAnmeldung.Size = new Size(129, 37);
            HGBAnmeldung.TabIndex = 2;
            HGBAnmeldung.UseVisualStyleBackColor = false;
            HGBAnmeldung.Click += Conection_Click;
            // 
            // HGBRegistrierung
            // 
            HGBRegistrierung.BackColor = Color.Transparent;
            HGBRegistrierung.BackgroundImageLayout = ImageLayout.None;
            HGBRegistrierung.FlatAppearance.BorderColor = Color.LightSteelBlue;
            HGBRegistrierung.FlatAppearance.BorderSize = 0;
            HGBRegistrierung.FlatAppearance.CheckedBackColor = Color.LightSteelBlue;
            HGBRegistrierung.FlatAppearance.MouseDownBackColor = Color.LightSteelBlue;
            HGBRegistrierung.FlatAppearance.MouseOverBackColor = Color.LightSteelBlue;
            HGBRegistrierung.FlatStyle = FlatStyle.Popup;
            HGBRegistrierung.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            HGBRegistrierung.ForeColor = Color.Black;
            HGBRegistrierung.Location = new Point(329, 12);
            HGBRegistrierung.Name = "HGBRegistrierung";
            HGBRegistrierung.Size = new Size(129, 37);
            HGBRegistrierung.TabIndex = 3;
            HGBRegistrierung.UseVisualStyleBackColor = false;
            HGBRegistrierung.Click += Register_Click;
            // 
            // HomeGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = Properties.Resources.BackGroundGame;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(560, 466);
            Controls.Add(HGBRegistrierung);
            Controls.Add(HGBAnmeldung);
            Controls.Add(GBRegistrierung);
            Controls.Add(GBAnmeldung);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "HomeGame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HomeGame";
            Load += HomeGame_Load;
            GBAnmeldung.ResumeLayout(false);
            GBAnmeldung.PerformLayout();
            GBRegistrierung.ResumeLayout(false);
            GBRegistrierung.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox GBAnmeldung;
        private GroupBox GBRegistrierung;
        private Button HGBAnmeldung;
        private Button HGBRegistrierung;
        private CheckBox ACSPasswort;
        private Button ABAbbrechen;
        private Label ALPasswort;
        private Label ALBenutzername;
        private TextBox textBox2;
        private TextBox textBox1;
        //private Button ABANmeldung;
        private TextBox textBox4;
        private TextBox textBox3;
        private CheckBox checkBox3;
        private Label RLPasswort2;
        private Label RLPasswort;
        private Label RLBenutzername;
        private Button RBAbbrechen;
        //private Button RLRegistrierung;
        private LinkLabel RLLBed;
        private CheckBox checkBox2;
        private TextBox textBox5;
        private Button RBRegistrierung;
        private Button ABAnmeldung;
    }
}