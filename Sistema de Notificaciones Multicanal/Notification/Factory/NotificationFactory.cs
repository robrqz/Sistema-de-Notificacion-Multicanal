using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Notificaciones_Multicanal.Notification.Channels.Email;
using Sistema_de_Notificaciones_Multicanal.Notification.Channels.SMS;
using Sistema_de_Notificaciones_Multicanal.Notification.Channels.Whatsapp;
using Sistema_de_Notificaciones_Multicanal.Notification.INotification;
using Sistema_de_Notificaciones_Multicanal.Notification.Interfaces.INotificationFactory;
using Sistema_de_Notificaciones_Multicanal.Notification.Types.Alerta;
using Sistema_de_Notificaciones_Multicanal.Notification.Types.Bienvenida;
using Sistema_de_Notificaciones_Multicanal.Notification.Types.Recordatorio;

namespace Sistema_de_Notificaciones_Multicanal.Notification.Factory
{
    public class NotificationFactory : INotificationFactory
    {
        public INotificationChannel GetChannel(int canalId)
        {
            return canalId switch
            {
                1 => new SmsChannel(),
                2 => new EmailChannel(),
                3 => new WhatsappChannel(),
                _ => throw new ArgumentException("Channel inválido")
            };
        }

        public INotificationType GetType(int tipoId)
        {
            return tipoId switch
            {
                1 => new BienvenidaNotification(),
                2 => new AlertaNotification(),
                3 => new RecordatorioNotification(),
                _ => throw new ArgumentException("Type inválido")
            };
        }
    }
}
