using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Notificaciones_Multicanal.Notification.INotification;


namespace Sistema_de_Notificaciones_Multicanal.Notification.Types.Bienvenida
{
    
    
        public class BienvenidaNotification : INotificationType
        {
            public string GetMessage() => "Bienvenida enviada con éxito!";
        }
    
}
