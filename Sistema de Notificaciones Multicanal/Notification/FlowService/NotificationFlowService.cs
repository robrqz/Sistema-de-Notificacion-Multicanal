using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Notificaciones_Multicanal.Notification.Channels.Email;
using Sistema_de_Notificaciones_Multicanal.Notification.Channels.SMS;
using Sistema_de_Notificaciones_Multicanal.Notification.Channels.Whatsapp;

using Sistema_de_Notificaciones_Multicanal.Notification.Interfaces.INotificationFactory;
using Sistema_de_Notificaciones_Multicanal.Notification.Service;
using Sistema_de_Notificaciones_Multicanal.Notification.Types.Alerta;
using Sistema_de_Notificaciones_Multicanal.Notification.Types.Bienvenida;
using Sistema_de_Notificaciones_Multicanal.Notification.Types.Recordatorio;
using Sistema_de_Notificaciones_Multicanal.User.UserService;

namespace Sistema_de_Notificaciones_Multicanal.Notification.FlowService
{
    public class NotificationFlowService
    {
        private readonly UserService _userService;
        private readonly NotificationService _notificationService;
        private readonly INotificationFactory _factory;

        public NotificationFlowService(UserService userService, NotificationService notificationService, INotificationFactory factory)
        {
            _userService = userService;
            _notificationService = notificationService;
            _factory = factory;
        }

        public void EnviarNotificacion(string nombreUsuario, int tipoId, int canalId)
        {
            if (!_userService.CheckUserExists(nombreUsuario))
            {
                Console.WriteLine("User no registrado.");
                return;
            }

            var usuario = _userService.GetUserList()
                .First(u => u.name.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase));

            var canal = _factory.GetChannel(canalId);
            var tipo = _factory.GetType(tipoId);

            _notificationService.NotifyUser(usuario, tipo, canal);
        }
    }
}

