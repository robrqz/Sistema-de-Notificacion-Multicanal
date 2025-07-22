using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Notificaciones_Multicanal.Notification.INotification;

namespace Sistema_de_Notificaciones_Multicanal.Notification.Channels.SMS
{
    public class SmsChannel : INotificationChannel
    {
        public void send(string messaje) => Console.WriteLine($"[SMS] {messaje}");
    }
    
}
