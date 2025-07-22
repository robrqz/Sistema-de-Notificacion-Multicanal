using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Notificaciones_Multicanal.Notification.INotification;


namespace Sistema_de_Notificaciones_Multicanal.Notification.Interfaces.INotificationFactory
{
    public interface INotificationFactory
    {
        INotificationChannel GetChannel(int canalId);
        INotificationType GetType(int tipoId);
    }



}
