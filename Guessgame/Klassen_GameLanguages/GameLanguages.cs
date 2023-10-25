using Guessgame.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Guessgame.Klassen_GameLanguages
{
    internal class GameLanguages
    {
        private static readonly GameRessources Gr = new();
        ResourceManager? rm;
        public string? Message { get; set; }

        public void UpdateFormControls(Form form, string culture)
        {
            string ResourcesLink = Gr.SetResourcesLink(form);
            rm = new(ResourcesLink, Assembly.GetExecutingAssembly());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            foreach (Control control in form.Controls)
            {
                UpdateControlText(control);
            }
        }

        private void UpdateControlText(Control control)
        {
            if (control is Label label)
            {
                string resourceName = label.Name;
                label.Text = rm?.GetString(resourceName, Thread.CurrentThread.CurrentUICulture);
            }
            else if (control is Button button)
            {
                string resourceName = button.Name;
                button.Text = rm?.GetString(resourceName, Thread.CurrentThread.CurrentUICulture) ?? button.Text;
            }
            else if (control is GroupBox groupBox)
            {
                string resourceName = groupBox.Name;
                groupBox.Text = rm?.GetString(resourceName, Thread.CurrentThread.CurrentUICulture) ?? groupBox.Text;
            }
            else if (control is CheckBox checkBox)
            {
                string resourceName = $"{checkBox.Name}";
                checkBox.Text = rm?.GetString(resourceName, Thread.CurrentThread.CurrentUICulture) ?? checkBox.Text;
            }
            else if (control is LinkLabel linklabel)
            {
                string resourceName = $"{linklabel.Name}";
                linklabel.Text = rm?.GetString(resourceName, Thread.CurrentThread.CurrentUICulture) ?? linklabel.Text;
            }
            foreach (Control childControl in control.Controls)
            {
                UpdateControlText(childControl);
            }
            
        }
        public string SetMessageStrings(string resName)
        {
            Message = rm?.GetString(resName, Thread.CurrentThread.CurrentUICulture);
            if (Message != null)
            {
                return Message;
            }
            else
            {
                return "Error";
            }
        }

        public string SetTHMessageStrings(string resName, string HT)
        {
            string ResourcesLink = Gr.THResourcesLink(HT);
            rm = new(ResourcesLink, Assembly.GetExecutingAssembly());
            Message = rm?.GetString(resName, Thread.CurrentThread.CurrentUICulture);
            if (Message != null)
            {
                return Message;
            }
            else
            {
                return "Error";
            }
        }
    }
}
