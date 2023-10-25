using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_GameLanguages
{
    internal class GameRessources
    {
        public static string? ResourcesLink { get; set; }
        public string SetResourcesLink(Form form)
        {
            switch (form)
            {
                case HomeGame:
                    ResourcesLink = "Guessgame.Klassen_GameLanguages.Languages.HomeGameLanguages.Resources.Resources";
                    break;
                case Game:
                    ResourcesLink = "Guessgame.Klassen_GameLanguages.Languages.GameFormLanguages.Resources.Resources";
                    break;
                case UserProfil:
                    ResourcesLink = "Guessgame.Klassen_GameLanguages.Languages.ProfilFormLanguages.Resources.Resources";
                    break;
                case Learn:
                    ResourcesLink = "Guessgame.Klassen_GameLanguages.Languages.LearnFormLanguages.Resources.Resources";
                    break;
                
                default:
                    ResourcesLink = "";
                    break;
            }
            return ResourcesLink;
        }
        public string THResourcesLink(string HT)
        {
            switch (HT)
            {
                case "Tipps":
                    ResourcesLink = "Guessgame.Klassen_GameLanguages.Languages.HintsAndTippsLanguages.TippsLanguages.Resources.Resources";
                    break;
                case "Hints":
                    ResourcesLink = "Guessgame.Klassen_GameLanguages.Languages.HintsAndTippsLanguages.HintsLanguages.Resources.Resources";
                    break;
                case "Dialog":
                    ResourcesLink = "Guessgame.Klassen_GameLanguages.Languages.Dialog.Resources.Resources";
                    break;
                default:
                    ResourcesLink = "";
                    break;
            }
            return ResourcesLink;
        }
    }
}
