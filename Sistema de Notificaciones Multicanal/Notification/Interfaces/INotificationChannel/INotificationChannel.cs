using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Notificaciones_Multicanal.Notification.eenum;

namespace Sistema_de_Notificaciones_Multicanal.Notification.Interfaces.INotificationChannel
{
    public interface INotificationChannel
    {
        void send(string message);
    }  
}
