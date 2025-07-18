using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Notificaciones_Multicanal.Notification.HelperNotification
{
    public class HelperNotification
    {
        public static (bool isValid, string MessageError) ValidateNotificationType(out int nombreCampo)
        {
            Console.WriteLine("Seleccione InputNotificationType de notificación:");
            Console.WriteLine("1. Bienvenida");
            Console.WriteLine("2. Alerta");
            Console.WriteLine("3. Recordatorio");
            string InputNotificationType = Console.ReadLine();

            if (!int.TryParse(InputNotificationType, out nombreCampo) || nombreCampo < 1 || nombreCampo > 3)
            {
                return (false, "Debes ingresar un número entre 1 y 3.");
            }
            return (true, string.Empty);
        }

        public static (bool isValid, string MessageError) ValidateNotificationChannel(out int nombreCampo)
        {
            Console.WriteLine("Seleccione canal:");
            Console.WriteLine("1. Email");
            Console.WriteLine("2. SMS");
            Console.WriteLine("3. WhatsApp");
            string InputNotificationChannel = Console.ReadLine();

            if (!int.TryParse(InputNotificationChannel, out nombreCampo) || nombreCampo < 1 || nombreCampo > 3)
            {
                return (false, "Debes ingresar un número entre 1 y 3.");
            }
            return (true, string.Empty);

        }
    }
}
