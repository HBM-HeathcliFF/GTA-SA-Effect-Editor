using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GTA_SA_Effect_Editor
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }

        public static List<string> Code { get; set; } = new List<string>();
        public static bool IsEdited { get; set; } = false;
        public static string EffectName { get; set; } = "";
    }
}