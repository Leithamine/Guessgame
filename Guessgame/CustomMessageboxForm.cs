using Guessgame.Klassen_Game.Game.Animation;
using Guessgame.Klassen_Game.Game.MessageBoxClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guessgame
{
    public partial class CustomMessageboxForm : UserControl
    {
        public Action? OnOkClicked { get; set; }
        public CustomMessageboxForm()
        {
            InitializeComponent();
            LForCMessageBox.MaximumSize = new Size(300, 0);
            LForCMessageBox.Text = "";
        }
        public string Message
        {
            get { return LForCMessageBox.Text; }
            set { LForCMessageBox.Text = value; }
        }

        private void BTForCMessageBox_Click(object sender, EventArgs e)
        {
            OnOkClicked?.Invoke();
            this.Visible = false;
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void CustomMessageboxForm_Load(object sender, EventArgs e)
        {
        }
        public void CenterToParent(Form parentForm)
        {
            this.Left = (parentForm.ClientSize.Width - this.Width) / 2;
            this.Top = (parentForm.ClientSize.Height - this.Height) / 2;
        }

    }
}
