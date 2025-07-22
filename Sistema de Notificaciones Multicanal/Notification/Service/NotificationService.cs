using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Notificaciones_Multicanal.User.Entities;
using Sistema_de_Notificaciones_Multicanal.Notification.INotification;
using Sistema_de_Notificaciones_Multicanal.Notification.Channels.Email;
using Sistema_de_Notificaciones_Multicanal.Notification.Channels.SMS;
using Sistema_de_Notificaciones_Multicanal.Notification.Channels.Whatsapp;
using Sistema_de_Notificaciones_Multicanal.Notification.Types.Alerta;
using Sistema_de_Notificaciones_Multicanal.Notification.Types.Bienvenida;
using Sistema_de_Notificaciones_Multicanal.Notification.Types.Recordatorio;
using Sistema_de_Notificaciones_Multicanal.User.UserService;
using System.Threading.Channels;


namespace Sistema_de_Notificaciones_Multicanal.Notification.Service
{
    public class NotificationService
    {
        private readonly List<NotificationEntity> _NotificationList = new();
        public void NotifyUser(UserEntity user, INotificationType type, INotificationChannel channel)
        {
            var message = type.GetMessage();
            channel.send(message);

            int newId = _NotificationList.Any()
                ? _NotificationList.Max(n => n.id) + 1
                : 1;

            var notificacion = new NotificationEntity(
                newId,
                user.name,
                type.GetType().Name,
                channel.GetType().Name,
                DateTime.Now
            );

            _NotificationList.Add(notificacion);

            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine($"Notificación id:{newId} registrada por {user.name}");
            Console.WriteLine($"{notificacion.notificationTime}");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

    }
}



