using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Notificaciones_Multicanal.Notification.Interfaces.INotificationChannel;
using Sistema_de_Notificaciones_Multicanal.User.Entities;
using Sistema_de_Notificaciones_Multicanal.Notification.Interfaces.INotification;
using Sistema_de_Notificaciones_Multicanal.Notification.Channels.Email;
using Sistema_de_Notificaciones_Multicanal.Notification.Channels.SMS;
using Sistema_de_Notificaciones_Multicanal.Notification.Channels.Whatsapp;
using Sistema_de_Notificaciones_Multicanal.Notification.Types.Alerta;
using Sistema_de_Notificaciones_Multicanal.Notification.Types.Bienvenida;
using Sistema_de_Notificaciones_Multicanal.Notification.Types.Recordatorio;
using Sistema_de_Notificaciones_Multicanal.User.UserService;
using static Sistema_de_Notificaciones_Multicanal.Notification.eenum.NotificationEnum;

namespace Sistema_de_Notificaciones_Multicanal.Notification.Service
{
    public class NotificationService
    {
        public void NotifyUser(UserEntity user, INotificationType type, INotificationChannel channel)
        {
            var message = type.GetMessage();
            channel.send(message);
        }
    }
}



