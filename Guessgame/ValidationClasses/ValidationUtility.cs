using Guessgame.Klassen_Game.Game.MessageBoxClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.ValidationClasses
{
    public class ValidationUtility
    {
        private string? MessageString;
        private readonly ResourceManager rm = new("Guessgame.ValidationClasses.Resources.Resources", Assembly.GetExecutingAssembly());
        private readonly Messages_Management MM = new();

        public bool CheckTextboxLength(TextBox textBox, Form parentform)
        {
            // Überprüft die Länge des Textes im TextBox
            if (textBox.Text.Length < 5)
            {
                // Anzeige einer Nachricht, wenn der Benutzername zu kurz ist
                MessageString = rm.GetString("UsernameTooShort");
                if(MessageString != null) { MM.ShowMessage(MessageString, parentform); }
                textBox.Focus();
                return false;
            }
            else if (textBox.Text.Length > 16)
            {
                // Anzeige einer Nachricht, wenn der Benutzername zu lang ist
                MessageString = rm.GetString("UsernameTooLong");
                if (MessageString != null) { MM.ShowMessage(MessageString, parentform); }
                textBox.Focus();
                return false;
            }
            return true;
        }

        public void CheckUsernameInput(TextBox textbox, KeyPressEventArgs e, Form parentform)
        {
            // Überprüfung, ob der erste Buchstabe ein Buchstabe ist
            if (textbox.Text.Length == 0 && !Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageString = rm.GetString("UsernameMustStartWithLetter");
                if (MessageString != null) { MM.ShowMessage(MessageString, parentform); }
            }
            // Überprüfung, ob der eingegebene Charakter gültig ist
            else if (!Char.IsLetterOrDigit(e.KeyChar) &&
                    e.KeyChar != 8 &&
                    e.KeyChar != 45 &&
                    e.KeyChar != 223 &&
                    e.KeyChar != 46 &&
                    e.KeyChar != 95)
            {
                e.Handled = true;
                MessageString = rm.GetString("UsernameInvalidCharacter");
                if (MessageString != null) { MM.ShowMessage(MessageString, parentform); }
            }
        }

        public bool PasswordCheck(string password, Form parentform)
        {
            // Minimale Passwortlänge
            const int MIN_PASSWORD_LENGTH = 8;
            bool hasDigit = false, hasLower = false, hasUpper = false, hasSymbol = false;
            string specialCharacters = "!@#$%^&*()-_=+[]{}|;:'\",.<>?/";

            // Überprüfung die Länge des Passworts
            if (password.Length >= MIN_PASSWORD_LENGTH)
            {
                // Überprüfung, ob das Passwort alle erforderlichen Zeichen enthält
                foreach (char c in password)
                {
                    if (char.IsDigit(c)) hasDigit = true;
                    if (char.IsLower(c)) hasLower = true;
                    if (char.IsUpper(c)) hasUpper = true;
                    if (specialCharacters.Contains(c)) hasSymbol = true;
                }

                if (!hasDigit || !hasLower || !hasUpper || !hasSymbol)
                {
                    MessageString = rm.GetString("PasswordMustContain");
                    if (MessageString != null) { MM.ShowMessage(MessageString, parentform); }
                    return false;
                }
            }
            else
            {
                MessageString = rm.GetString("PasswordMustBeAtLeast");
                if (MessageString != null) { MM.ShowMessage(MessageString, parentform); }
                return false;
            }
            return true;
        }

        public bool CheckNumberInput(KeyPressEventArgs e, Form parentform)
        {
            // Überprüfung, ob die Eingabe eine Zahl ist
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageString = rm.GetString("OnlyNumbersAllowed");
                if (MessageString != null) { MM.ShowMessage(MessageString, parentform); }
                return false;
            }
            return true;
        }

        public bool CheckEmptyText(TextBox textbox, Form parentform)
        {
            // Überprüfung, ob das Textfeld leer ist
            if (textbox.Text == string.Empty)
            {
                MessageString = rm.GetString("FieldMustNotBeEmpty");
                if (MessageString != null) { MM.ShowMessage(MessageString, parentform); }
                textbox.Focus();
                return false;
            }
            return true;
        }
    }
}
