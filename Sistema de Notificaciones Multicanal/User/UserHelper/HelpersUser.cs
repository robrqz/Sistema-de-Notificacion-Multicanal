using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Notificaciones_Multicanal.User.Entities;

namespace Sistema_de_Notificaciones_Multicanal.User.HelpersUser
{
    public class HelpersUser
    {
        public static void ShowUsers(List<UserEntity> UserList)
        {
            Console.WriteLine("-------User List------");
            foreach(var user in UserList)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"UserName: {user.name}");
                Console.WriteLine($"id: {user.id}");
                Console.WriteLine("------------------------------------------");
            }
        }
        public static bool UserCheker(List<UserEntity> UserList)
        {
            if (!UserList.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error. ");
                Console.ResetColor();
                Console.WriteLine("No hay usuarios registrados. Agreguelos en el case 1.");
                Console.ResetColor();
                Console.WriteLine("Presione una tecla para volver al menú...");
                Console.ReadKey();
                Console.Clear();
                return false;
            }
            return true;
        }
    }
}
