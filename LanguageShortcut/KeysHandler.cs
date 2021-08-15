using System;
using System.Windows.Forms;

namespace LanguageShortcut
{
    public class KeysHandler
    {
        private static bool rCtrlPressed;
        private static bool lCtrlPressed;
        
        public static void HandleKeyUp(Keys key)
        {
            switch (key)
            {
                case Keys.RControlKey:
                    rCtrlPressed = false;
                    break;
                case Keys.LControlKey:
                    lCtrlPressed = false;
                    break;
            }
        }

        public static void HandleKeyDown(Keys key)
        {
            switch (key)
            {
                case Keys.RControlKey:
                    rCtrlPressed = true;
                    break;
                case Keys.LControlKey:
                    lCtrlPressed = true;
                    break;
                case Keys.LShiftKey:
                    if (lCtrlPressed)
                        LanguageChanger.ChangeLanguage(Language.English);
                    break;
                case Keys.RShiftKey:
                    if (rCtrlPressed)
                        LanguageChanger.ChangeLanguage(Language.Russian);
                    break;
            }
        }
    }
}