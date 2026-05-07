using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObuV
{
    public static class CurrentUser
    {
        public static int UserID { get; set; }
        public static string Login { get; set; }
        public static string RoleName { get; set; }
        public static string FullName { get; set; }

        public static bool IsAdmin => RoleName == "Администратор";
        public static bool IsManager => RoleName == "Менеджер";
        public static bool IsClient => RoleName == "Авторизированный клиент";
        public static bool IsGuest => RoleName == "Гость";

        public static void Clear()
        {
            UserID = 0; Login = null; RoleName = null; FullName = null;
        }
    }
}
