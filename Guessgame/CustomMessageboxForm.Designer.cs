namespace Guessgame
{
    partial class CustomMessageboxForm
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomMessageboxForm));
            BTForCMessageBox = new Button();
            LForCMessageBox = new Label();
            SuspendLayout();
            // 
            // BTForCMessageBox
            // 
            BTForCMessageBox.BackColor = Color.DodgerBlue;
            BTForCMessageBox.FlatAppearance.BorderColor = Color.SteelBlue;
            BTForCMessageBox.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
            BTForCMessageBox.FlatAppearance.MouseOverBackColor = Color.SteelBlue;
            resources.ApplyResources(BTForCMessageBox, "BTForCMessageBox");
            BTForCMessageBox.Name = "BTForCMessageBox";
            BTForCMessageBox.UseVisualStyleBackColor = false;
            BTForCMessageBox.Click += BTForCMessageBox_Click;
            // 
            // LForCMessageBox
            // 
            resources.ApplyResources(LForCMessageBox, "LForCMessageBox");
            LForCMessageBox.BackColor = Color.Transparent;
            LForCMessageBox.FlatStyle = FlatStyle.Flat;
            LForCMessageBox.Name = "LForCMessageBox";
            // 
            // CustomMessageboxForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.Messagebox;
            Controls.Add(LForCMessageBox);
            Controls.Add(BTForCMessageBox);
            Name = "CustomMessageboxForm";
            Load += CustomMessageboxForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BTForCMessageBox;
        private Label LForCMessageBox;
    }
}
