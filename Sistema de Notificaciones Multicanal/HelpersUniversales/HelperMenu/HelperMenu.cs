using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Notificaciones_Multicanal.HelpersUniversales.HelperMenu
{
    public static class HelperMenu
    {
        public static (bool esValido, string mensajeError) MenuHelper(out int nombreCampo)
        {
            Console.WriteLine("=== Sistema de Notificaciones ===");
            Console.WriteLine(" 1.Crear usuario");
            Console.WriteLine(" 2.Listar usuarios");
            Console.WriteLine(" 3.Enviar notificación a usuario");
            Console.WriteLine(" 4.Salir");

            string MenuEntrada = Console.ReadLine();

            if (!int.TryParse(MenuEntrada, out nombreCampo) || nombreCampo < 1 || nombreCampo > 4)
            {
                return (false, "Debes ingresar un número entre 1 y 4.");
            }

            return (true, string.Empty);
        }
    }
}
