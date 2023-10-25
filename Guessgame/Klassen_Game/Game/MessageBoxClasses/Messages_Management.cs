using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Game.MessageBoxClasses
{
    internal class Messages_Management
    {
        public void ShowMessage(string message, Form parentform)
        {
            CustomMessageboxForm customMessageboxForm = new()
            {
                Message = message
            };
            customMessageboxForm.OnOkClicked = () => parentform.Controls.Remove(customMessageboxForm);
            parentform.Controls.Add(customMessageboxForm);
            customMessageboxForm.CenterToParent(parentform);
            customMessageboxForm.BringToFront();
        }
    }
}
