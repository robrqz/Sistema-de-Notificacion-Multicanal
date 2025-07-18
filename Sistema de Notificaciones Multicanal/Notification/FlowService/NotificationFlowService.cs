using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Notificaciones_Multicanal.Notification.Channels.Email;
using Sistema_de_Notificaciones_Multicanal.Notification.Channels.SMS;
using Sistema_de_Notificaciones_Multicanal.Notification.Channels.Whatsapp;
using Sistema_de_Notificaciones_Multicanal.Notification.Interfaces.INotification;
using Sistema_de_Notificaciones_Multicanal.Notification.Interfaces.INotificationChannel;
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

        public NotificationFlowService(UserService userService, NotificationService notificationService)
        {
            _userService = userService;
            _notificationService = notificationService;
        }

        public void EnviarNotificacion(string nombreUsuario, int tipoNotificacion, int canal)
        {
            if (!_userService.CheckUserExists(nombreUsuario))
            {
                Console.WriteLine("Usuario no registrado.");
                return;
            }

            var usuario = _userService.GetUserList()
                .First(u => u.name.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase));

            INotificationChannel canalSeleccionado = canal switch
            {
                1 => new SmsChannel(),
                2 => new EmailChannel(),
                3 => new WhatsappChannel(),
                _ => throw new ArgumentException("Canal inválido")
            };

            INotificationType notificacion = tipoNotificacion switch
            {
                1 => new BienvenidaNotification(),
                2 => new AlertaNotification(),
                3 => new RecordatorioNotification(),
                _ => throw new ArgumentException("Tipo inválido")
            };

            _notificationService.NotifyUser(usuario, notificacion, canalSeleccionado);
        }
    }



}

