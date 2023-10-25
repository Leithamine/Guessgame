namespace Guessgame
{
    partial class Languages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Languages));
            ComboSprache = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // ComboSprache
            // 
            ComboSprache.BackColor = Color.LightSteelBlue;
            ComboSprache.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ComboSprache.FormattingEnabled = true;
            ComboSprache.Location = new Point(67, 78);
            ComboSprache.Name = "ComboSprache";
            ComboSprache.Size = new Size(277, 26);
            ComboSprache.TabIndex = 1;
            ComboSprache.SelectedIndexChanged += ComboSprache_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderColor = Color.LightSteelBlue;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.LightSteelBlue;
            button1.FlatAppearance.MouseOverBackColor = Color.LightSteelBlue;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.FromArgb(0, 0, 64);
            button1.Location = new Point(146, 180);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Languages
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BackGroundGame;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(409, 212);
            Controls.Add(button1);
            Controls.Add(ComboSprache);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Languages";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Languages";
            Load += Languages_Load;
            ResumeLayout(false);
        }

        #endregion
        private ComboBox ComboSprache;
        private Button button1;
    }
}