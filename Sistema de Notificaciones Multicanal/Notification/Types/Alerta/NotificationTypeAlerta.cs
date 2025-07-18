using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Notificaciones_Multicanal.Notification.Interfaces.INotification;

namespace Sistema_de_Notificaciones_Multicanal.Notification.Types.Alerta
{
    
        public class AlertaNotification : INotificationType
        {
            public string GetMessage() => "Alerta enviada con éxito!";
        }
    
}
