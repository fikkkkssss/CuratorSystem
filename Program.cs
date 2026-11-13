using System;
using System.Windows.Forms;

namespace CuratorReportSystem
{
    internal static class Program
    {
        public static string CurrentUserRole = "";
        public static int CurrentUserId = 0;
        public static string CurrentUserLogin = "";
        public static int CurrentUserGroupId = 0;

        // Ссылка на главное меню
        public static Form MainForm = null;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Бесконечный цикл: Логин -> Главное меню -> Выход -> Логин...
            while (true)
            {
                // Открываем окно логина
                using (Form1 loginForm = new Form1())
                {
                    // Если пользователь закрыл логин крестиком - выходим из программы
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        break;
                    }
                }

                // Если вход успешен (DialogResult.OK), открываем главное меню
                using (Form2 mainForm = new Form2())
                {
                    MainForm = mainForm;
                    Application.Run(mainForm);
                }

                // Когда Form2 закрывается, цикл идет на новый круг и снова открывает логин
            }
        }
    }
}