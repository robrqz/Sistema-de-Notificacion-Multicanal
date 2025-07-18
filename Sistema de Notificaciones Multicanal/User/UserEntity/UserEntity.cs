using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Notificaciones_Multicanal.Notification.Interfaces.INotificationChannel;


namespace Sistema_de_Notificaciones_Multicanal.User.Entities
{
    public class UserEntity
    {
        protected string Name { get; set; }
        protected int Id { get; set; }
        protected List<INotificationChannel> PreferredChannels { get; set; } = new();


        public string name => Name;
        public int id => Id;
        public List<INotificationChannel> notificationChannels => PreferredChannels;
        public UserEntity(string name, int id)
        {
            Name = name;
            Id = id;
        }


    }
}
