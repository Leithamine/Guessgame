namespace Guessgame
{
    partial class Game
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            HasTipps = new ListBox();
            LabelForUserName = new Label();
            LabelForHasUserName = new Label();
            LabelForHighScore = new Label();
            LabelForHasUserHighScore = new Label();
            LabelForTippsOfNumber = new Label();
            LabelForGuessedNumber = new Label();
            InputGuessedNumber = new TextBox();
            LabelForGuessesLeft = new Label();
            LabelForPlayedRound = new Label();
            LabelForGetRoundsNumber = new Label();
            LabelForSettingRemainingTries = new Label();
            SubmitButton = new Button();
            EndButton = new Button();
            BTTipps = new Button();
            GameScore = new Label();
            LabelForHasGameScore = new Label();
            ProfilButton = new Button();
            BTStart = new Button();
            GBGame = new GroupBox();
            BTLearn = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            LabelForHasGeneratedRandomNumber = new Label();
            LabelForRandomNumber = new Label();
            GBGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // HasTipps
            // 
            HasTipps.BackColor = Color.LightSteelBlue;
            HasTipps.BorderStyle = BorderStyle.None;
            HasTipps.Font = new Font("Verdana", 7.20000029F, FontStyle.Bold, GraphicsUnit.Point);
            HasTipps.ForeColor = Color.Black;
            HasTipps.FormattingEnabled = true;
            HasTipps.ItemHeight = 14;
            HasTipps.Location = new Point(420, 38);
            HasTipps.Margin = new Padding(4);
            HasTipps.Name = "HasTipps";
            HasTipps.Size = new Size(557, 224);
            HasTipps.TabIndex = 1;
            // 
            // LabelForUserName
            // 
            LabelForUserName.AutoSize = true;
            LabelForUserName.BackColor = Color.Transparent;
            LabelForUserName.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LabelForUserName.Location = new Point(5, 9);
            LabelForUserName.Margin = new Padding(4, 0, 4, 0);
            LabelForUserName.Name = "LabelForUserName";
            LabelForUserName.Size = new Size(0, 18);
            LabelForUserName.TabIndex = 3;
            // 
            // LabelForHasUserName
            // 
            LabelForHasUserName.AutoSize = true;
            LabelForHasUserName.BackColor = Color.Transparent;
            LabelForHasUserName.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LabelForHasUserName.Location = new Point(162, 9);
            LabelForHasUserName.Margin = new Padding(4, 0, 4, 0);
            LabelForHasUserName.Name = "LabelForHasUserName";
            LabelForHasUserName.Size = new Size(57, 18);
            LabelForHasUserName.TabIndex = 4;
            LabelForHasUserName.Text = "label3";
            // 
            // LabelForHighScore
            // 
            LabelForHighScore.AutoSize = true;
            LabelForHighScore.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LabelForHighScore.Location = new Point(0, 73);
            LabelForHighScore.Margin = new Padding(4, 0, 4, 0);
            LabelForHighScore.Name = "LabelForHighScore";
            LabelForHighScore.Size = new Size(0, 18);
            LabelForHighScore.TabIndex = 5;
            // 
            // LabelForHasUserHighScore
            // 
            LabelForHasUserHighScore.AutoSize = true;
            LabelForHasUserHighScore.BackColor = Color.SteelBlue;
            LabelForHasUserHighScore.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LabelForHasUserHighScore.ForeColor = Color.Black;
            LabelForHasUserHighScore.Location = new Point(139, 73);
            LabelForHasUserHighScore.Margin = new Padding(4, 0, 4, 0);
            LabelForHasUserHighScore.Name = "LabelForHasUserHighScore";
            LabelForHasUserHighScore.Size = new Size(57, 18);
            LabelForHasUserHighScore.TabIndex = 6;
            LabelForHasUserHighScore.Text = "label5";
            // 
            // LabelForTippsOfNumber
            // 
            LabelForTippsOfNumber.AutoSize = true;
            LabelForTippsOfNumber.BackColor = Color.SteelBlue;
            LabelForTippsOfNumber.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LabelForTippsOfNumber.ForeColor = Color.Black;
            LabelForTippsOfNumber.Location = new Point(420, 16);
            LabelForTippsOfNumber.Margin = new Padding(4, 0, 4, 0);
            LabelForTippsOfNumber.Name = "LabelForTippsOfNumber";
            LabelForTippsOfNumber.Size = new Size(0, 18);
            LabelForTippsOfNumber.TabIndex = 7;
            // 
            // LabelForGuessedNumber
            // 
            LabelForGuessedNumber.AutoSize = true;
            LabelForGuessedNumber.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LabelForGuessedNumber.Location = new Point(0, 177);
            LabelForGuessedNumber.Margin = new Padding(4, 0, 4, 0);
            LabelForGuessedNumber.Name = "LabelForGuessedNumber";
            LabelForGuessedNumber.Size = new Size(0, 18);
            LabelForGuessedNumber.TabIndex = 9;
            // 
            // InputGuessedNumber
            // 
            InputGuessedNumber.BackColor = Color.LightSteelBlue;
            InputGuessedNumber.Location = new Point(168, 172);
            InputGuessedNumber.Margin = new Padding(4);
            InputGuessedNumber.Name = "InputGuessedNumber";
            InputGuessedNumber.Size = new Size(118, 28);
            InputGuessedNumber.TabIndex = 10;
            InputGuessedNumber.KeyPress += InputGuessedNumber_KeyPress;
            // 
            // LabelForGuessesLeft
            // 
            LabelForGuessesLeft.AutoSize = true;
            LabelForGuessesLeft.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LabelForGuessesLeft.Location = new Point(0, 155);
            LabelForGuessesLeft.Margin = new Padding(4, 0, 4, 0);
            LabelForGuessesLeft.Name = "LabelForGuessesLeft";
            LabelForGuessesLeft.Size = new Size(0, 18);
            LabelForGuessesLeft.TabIndex = 11;
            // 
            // LabelForPlayedRound
            // 
            LabelForPlayedRound.AutoSize = true;
            LabelForPlayedRound.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LabelForPlayedRound.Location = new Point(0, 97);
            LabelForPlayedRound.Margin = new Padding(4, 0, 4, 0);
            LabelForPlayedRound.Name = "LabelForPlayedRound";
            LabelForPlayedRound.Size = new Size(0, 18);
            LabelForPlayedRound.TabIndex = 12;
            // 
            // LabelForGetRoundsNumber
            // 
            LabelForGetRoundsNumber.AutoSize = true;
            LabelForGetRoundsNumber.BackColor = Color.SteelBlue;
            LabelForGetRoundsNumber.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LabelForGetRoundsNumber.ForeColor = Color.Black;
            LabelForGetRoundsNumber.Location = new Point(139, 97);
            LabelForGetRoundsNumber.Margin = new Padding(4, 0, 4, 0);
            LabelForGetRoundsNumber.Name = "LabelForGetRoundsNumber";
            LabelForGetRoundsNumber.Size = new Size(68, 18);
            LabelForGetRoundsNumber.TabIndex = 13;
            LabelForGetRoundsNumber.Text = "label11";
            // 
            // LabelForSettingRemainingTries
            // 
            LabelForSettingRemainingTries.AutoSize = true;
            LabelForSettingRemainingTries.BackColor = Color.SteelBlue;
            LabelForSettingRemainingTries.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LabelForSettingRemainingTries.ForeColor = Color.Black;
            LabelForSettingRemainingTries.Location = new Point(139, 150);
            LabelForSettingRemainingTries.Margin = new Padding(4, 0, 4, 0);
            LabelForSettingRemainingTries.Name = "LabelForSettingRemainingTries";
            LabelForSettingRemainingTries.Size = new Size(68, 18);
            LabelForSettingRemainingTries.TabIndex = 14;
            LabelForSettingRemainingTries.Text = "label12";
            // 
            // SubmitButton
            // 
            SubmitButton.BackColor = Color.SteelBlue;
            SubmitButton.FlatAppearance.BorderColor = Color.LightSteelBlue;
            SubmitButton.FlatAppearance.BorderSize = 0;
            SubmitButton.FlatAppearance.CheckedBackColor = Color.LightSteelBlue;
            SubmitButton.FlatAppearance.MouseDownBackColor = Color.LightSteelBlue;
            SubmitButton.FlatAppearance.MouseOverBackColor = Color.LightSteelBlue;
            SubmitButton.FlatStyle = FlatStyle.Flat;
            SubmitButton.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SubmitButton.ForeColor = Color.Black;
            SubmitButton.Location = new Point(168, 208);
            SubmitButton.Margin = new Padding(4);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(118, 29);
            SubmitButton.TabIndex = 15;
            SubmitButton.UseVisualStyleBackColor = false;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // EndButton
            // 
            EndButton.BackColor = Color.SteelBlue;
            EndButton.FlatAppearance.BorderColor = Color.LightSteelBlue;
            EndButton.FlatAppearance.BorderSize = 0;
            EndButton.FlatAppearance.CheckedBackColor = Color.LightSteelBlue;
            EndButton.FlatAppearance.MouseDownBackColor = Color.LightSteelBlue;
            EndButton.FlatAppearance.MouseOverBackColor = Color.LightSteelBlue;
            EndButton.FlatStyle = FlatStyle.Flat;
            EndButton.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            EndButton.ForeColor = Color.Black;
            EndButton.Location = new Point(294, 208);
            EndButton.Margin = new Padding(4);
            EndButton.Name = "EndButton";
            EndButton.Size = new Size(118, 29);
            EndButton.TabIndex = 16;
            EndButton.UseVisualStyleBackColor = false;
            EndButton.Click += EndButton_Click;
            // 
            // BTTipps
            // 
            BTTipps.BackColor = Color.SteelBlue;
            BTTipps.FlatAppearance.BorderColor = Color.LightSteelBlue;
            BTTipps.FlatAppearance.BorderSize = 0;
            BTTipps.FlatAppearance.CheckedBackColor = Color.LightSteelBlue;
            BTTipps.FlatAppearance.MouseDownBackColor = Color.LightSteelBlue;
            BTTipps.FlatAppearance.MouseOverBackColor = Color.LightSteelBlue;
            BTTipps.FlatStyle = FlatStyle.Flat;
            BTTipps.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            BTTipps.ForeColor = Color.Black;
            BTTipps.Location = new Point(294, 172);
            BTTipps.Margin = new Padding(4, 3, 4, 3);
            BTTipps.Name = "BTTipps";
            BTTipps.Size = new Size(118, 29);
            BTTipps.TabIndex = 17;
            BTTipps.UseVisualStyleBackColor = false;
            BTTipps.Click += Button1_Click;
            // 
            // GameScore
            // 
            GameScore.AutoSize = true;
            GameScore.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            GameScore.Location = new Point(0, 123);
            GameScore.Margin = new Padding(4, 0, 4, 0);
            GameScore.Name = "GameScore";
            GameScore.Size = new Size(0, 18);
            GameScore.TabIndex = 18;
            // 
            // LabelForHasGameScore
            // 
            LabelForHasGameScore.AutoSize = true;
            LabelForHasGameScore.BackColor = Color.SteelBlue;
            LabelForHasGameScore.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LabelForHasGameScore.ForeColor = Color.Black;
            LabelForHasGameScore.Location = new Point(139, 123);
            LabelForHasGameScore.Margin = new Padding(4, 0, 4, 0);
            LabelForHasGameScore.Name = "LabelForHasGameScore";
            LabelForHasGameScore.Size = new Size(57, 18);
            LabelForHasGameScore.TabIndex = 19;
            LabelForHasGameScore.Text = "label5";
            // 
            // ProfilButton
            // 
            ProfilButton.BackColor = Color.SteelBlue;
            ProfilButton.FlatAppearance.BorderColor = Color.LightSteelBlue;
            ProfilButton.FlatAppearance.BorderSize = 0;
            ProfilButton.FlatAppearance.CheckedBackColor = Color.LightSteelBlue;
            ProfilButton.FlatAppearance.MouseDownBackColor = Color.LightSteelBlue;
            ProfilButton.FlatAppearance.MouseOverBackColor = Color.LightSteelBlue;
            ProfilButton.FlatStyle = FlatStyle.Flat;
            ProfilButton.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ProfilButton.ForeColor = Color.Black;
            ProfilButton.Location = new Point(883, 4);
            ProfilButton.Margin = new Padding(4, 3, 4, 3);
            ProfilButton.Name = "ProfilButton";
            ProfilButton.Size = new Size(118, 29);
            ProfilButton.TabIndex = 20;
            ProfilButton.UseVisualStyleBackColor = false;
            ProfilButton.Click += PRofilButton_Click;
            // 
            // BTStart
            // 
            BTStart.BackColor = Color.PaleTurquoise;
            BTStart.FlatAppearance.BorderColor = Color.White;
            BTStart.FlatAppearance.BorderSize = 0;
            BTStart.FlatAppearance.CheckedBackColor = Color.LightSteelBlue;
            BTStart.FlatAppearance.MouseDownBackColor = Color.White;
            BTStart.FlatAppearance.MouseOverBackColor = Color.White;
            BTStart.FlatStyle = FlatStyle.Flat;
            BTStart.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            BTStart.ForeColor = Color.Black;
            BTStart.Location = new Point(321, 123);
            BTStart.Margin = new Padding(4, 3, 4, 3);
            BTStart.Name = "BTStart";
            BTStart.Size = new Size(144, 29);
            BTStart.TabIndex = 21;
            BTStart.UseVisualStyleBackColor = false;
            BTStart.Visible = false;
            BTStart.Click += button2_Click;
            // 
            // GBGame
            // 
            GBGame.BackColor = Color.Transparent;
            GBGame.Controls.Add(LabelForHighScore);
            GBGame.Controls.Add(LabelForHasGameScore);
            GBGame.Controls.Add(LabelForHasUserHighScore);
            GBGame.Controls.Add(GameScore);
            GBGame.Controls.Add(LabelForTippsOfNumber);
            GBGame.Controls.Add(BTTipps);
            GBGame.Controls.Add(EndButton);
            GBGame.Controls.Add(LabelForGuessedNumber);
            GBGame.Controls.Add(SubmitButton);
            GBGame.Controls.Add(InputGuessedNumber);
            GBGame.Controls.Add(LabelForSettingRemainingTries);
            GBGame.Controls.Add(LabelForGuessesLeft);
            GBGame.Controls.Add(LabelForGetRoundsNumber);
            GBGame.Controls.Add(LabelForPlayedRound);
            GBGame.Controls.Add(HasTipps);
            GBGame.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            GBGame.ForeColor = Color.FromArgb(0, 0, 64);
            GBGame.Location = new Point(5, 172);
            GBGame.Margin = new Padding(4, 3, 4, 3);
            GBGame.Name = "GBGame";
            GBGame.Padding = new Padding(4, 3, 4, 3);
            GBGame.Size = new Size(1012, 280);
            GBGame.TabIndex = 22;
            GBGame.TabStop = false;
            GBGame.Visible = false;
            // 
            // BTLearn
            // 
            BTLearn.BackColor = Color.SteelBlue;
            BTLearn.BackgroundImageLayout = ImageLayout.None;
            BTLearn.FlatAppearance.BorderColor = Color.LightSteelBlue;
            BTLearn.FlatAppearance.BorderSize = 0;
            BTLearn.FlatAppearance.CheckedBackColor = Color.LightSteelBlue;
            BTLearn.FlatAppearance.MouseDownBackColor = Color.LightSteelBlue;
            BTLearn.FlatAppearance.MouseOverBackColor = Color.LightSteelBlue;
            BTLearn.FlatStyle = FlatStyle.Flat;
            BTLearn.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            BTLearn.ForeColor = Color.Black;
            BTLearn.Location = new Point(1024, 4);
            BTLearn.Margin = new Padding(4, 3, 4, 3);
            BTLearn.Name = "BTLearn";
            BTLearn.Size = new Size(118, 29);
            BTLearn.TabIndex = 23;
            BTLearn.UseVisualStyleBackColor = false;
            BTLearn.Click += button3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = Properties.Resources.Speechbubble2;
            pictureBox1.Location = new Point(162, 62);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(499, 186);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources.Charackter;
            pictureBox2.Location = new Point(588, 26);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(366, 603);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 25;
            pictureBox2.TabStop = false;
            // 
            // timer1
            // 
            timer1.Interval = 4500;
            timer1.Tick += Timer1_Tick;
            // 
            // LabelForHasGeneratedRandomNumber
            // 
            LabelForHasGeneratedRandomNumber.AutoSize = true;
            LabelForHasGeneratedRandomNumber.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LabelForHasGeneratedRandomNumber.Location = new Point(173, 511);
            LabelForHasGeneratedRandomNumber.Margin = new Padding(4, 0, 4, 0);
            LabelForHasGeneratedRandomNumber.Name = "LabelForHasGeneratedRandomNumber";
            LabelForHasGeneratedRandomNumber.Size = new Size(57, 18);
            LabelForHasGeneratedRandomNumber.TabIndex = 8;
            LabelForHasGeneratedRandomNumber.Text = "label7";
            // 
            // LabelForRandomNumber
            // 
            LabelForRandomNumber.AutoSize = true;
            LabelForRandomNumber.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LabelForRandomNumber.Location = new Point(13, 511);
            LabelForRandomNumber.Margin = new Padding(4, 0, 4, 0);
            LabelForRandomNumber.Name = "LabelForRandomNumber";
            LabelForRandomNumber.Size = new Size(0, 18);
            LabelForRandomNumber.TabIndex = 0;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BackGroundGame;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1155, 636);
            Controls.Add(BTStart);
            Controls.Add(LabelForRandomNumber);
            Controls.Add(BTLearn);
            Controls.Add(ProfilButton);
            Controls.Add(LabelForHasUserName);
            Controls.Add(LabelForUserName);
            Controls.Add(LabelForHasGeneratedRandomNumber);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(GBGame);
            DoubleBuffered = true;
            Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Game";
            Text = "Game";
            FormClosing += Game_FormClosing;
            Load += Game_Load;
            GBGame.ResumeLayout(false);
            GBGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox HasTipps;
        private Label LabelForUserName;
        private Label LabelForHasUserName;
        private Label LabelForHighScore;
        private Label LabelForHasUserHighScore;
        private Label LabelForTippsOfNumber;
        private Label LabelForGuessedNumber;
        private TextBox InputGuessedNumber;
        private Label LabelForGuessesLeft;
        private Label LabelForPlayedRound;
        private Label LabelForGetRoundsNumber;
        private Label LabelForSettingRemainingTries;
        private Button SubmitButton;
        private Button EndButton;
        private Button BTTipps;
        private Label GameScore;
        private Label LabelForHasGameScore;
        private Button ProfilButton;
        private Button BTStart;
        private GroupBox GBGame;
        private Button BTLearn;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private Label LabelForRandomNumber;
        private Label LabelForHasGeneratedRandomNumber;
    }
}