using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Notificaciones_Multicanal.Notification.INotification;
using System.Xml.Linq;

public class NotificationEntity
{
    protected int Id { get; set; }
    protected string User { get; set; }
    protected string Type { get; set; }
    protected string Channel { get; set; }
    protected DateTime NotificationTime { get; set; }

    
    public int id => Id;
    public string user => User;
    public string type => Type;
    public string channel => Channel;
    public DateTime notificationTime => NotificationTime;
    public NotificationEntity(int id, string user, string type, string channel, DateTime notificationTime)
    {
        Id = id;
        User = user;
        Type = type;
        Channel = channel;
        NotificationTime = notificationTime;
    }
}
