using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Notificaciones_Multicanal.Notification.Interfaces.INotificationChannel;

namespace Sistema_de_Notificaciones_Multicanal.Notification.Channels.Whatsapp
{
    
        public class WhatsappChannel : INotificationChannel
        {
            public void send(string messaje) => Console.WriteLine($"[WHATSAPP] {messaje}");
        }
    
}
