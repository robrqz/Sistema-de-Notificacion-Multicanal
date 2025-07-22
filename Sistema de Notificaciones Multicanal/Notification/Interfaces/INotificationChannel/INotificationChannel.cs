using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sistema_de_Notificaciones_Multicanal.Notification.INotification
{
    public interface INotificationChannel
    {
        void send(string message);
    }  
}
