using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LanguageShortcut
{
    public class LanguageChanger
    {
        [DllImport("user32.dll")]
        private static extern bool PostMessage(int hhwnd, uint msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32.dll")]
        private static extern IntPtr LoadKeyboardLayout(string pwszKLID, uint Flags);

        private static uint WM_INPUTLANGCHANGEREQUEST = 0x0050;
        private static int HWND_BROADCAST = 0xffff;
        private static uint KLF_ACTIVATE = 1;
        private static Dictionary<Language, string> supportedLanguages = new Dictionary<Language, string>
        {
            [Language.Russian] = "00000419",
            [Language.English] = "00000409"
        };

        public static void ChangeLanguage(Language language)
        {
            PostMessage(HWND_BROADCAST, WM_INPUTLANGCHANGEREQUEST, IntPtr.Zero,
                LoadKeyboardLayout(supportedLanguages[language], KLF_ACTIVATE));
        }
    }
}