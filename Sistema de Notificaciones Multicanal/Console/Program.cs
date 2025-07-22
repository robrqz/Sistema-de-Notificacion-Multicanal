using Sistema_de_Notificaciones_Multicanal.HelpersUniversales.HelperMenu;
using Sistema_de_Notificaciones_Multicanal.HelpersUniversales.Validacion;
using Sistema_de_Notificaciones_Multicanal.Notification.Channels.Email;
using Sistema_de_Notificaciones_Multicanal.Notification.Channels.SMS;
using Sistema_de_Notificaciones_Multicanal.Notification.Channels.Whatsapp;
using Sistema_de_Notificaciones_Multicanal.Notification.Service;
using Sistema_de_Notificaciones_Multicanal.User.Entities;
using Sistema_de_Notificaciones_Multicanal.User.UserService;
using Sistema_de_Notificaciones_Multicanal.Notification.Types.Bienvenida;
using Sistema_de_Notificaciones_Multicanal.Notification.Types.Alerta;
using Sistema_de_Notificaciones_Multicanal.Notification.Types.Recordatorio;
using Sistema_de_Notificaciones_Multicanal.User.HelpersUser;
using Sistema_de_Notificaciones_Multicanal.Notification.HelperNotification;
using Sistema_de_Notificaciones_Multicanal.Notification.FlowService;
using Sistema_de_Notificaciones_Multicanal.Notification.Factory;

using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

using Sistema_de_Notificaciones_Multicanal.Notification.INotification;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    static void Main()
    {
        //resolucion dependencias
        var serverProvider = new ServiceCollection();

        serverProvider.AddSingleton<UserService>();
        serverProvider.AddSingleton<NotificationService>();
        serverProvider.AddSingleton<INotificationType>(sp => (INotificationType)sp.GetRequiredService<NotificationService>());
        serverProvider.AddSingleton<INotificationChannel>(sp => (INotificationChannel)sp.GetRequiredService<NotificationService>());
        serverProvider.AddSingleton<NotificationFlowService>();
        serverProvider.AddSingleton<NotificationFactory>();

        var provider = serverProvider.BuildServiceProvider();

        var UserService = provider.GetRequiredService<UserService>();
        var NotificationService = provider.GetRequiredService<NotificationService>();
        var NotificationFactory = provider.GetRequiredService<NotificationFactory>();

        int MenuOption;
        do
        {
            var MenuSwitch = HelperMenu.MenuHelper(out MenuOption);

            if (!MenuSwitch.esValido)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(MenuSwitch.mensajeError);
                Console.ResetColor();
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                continue;
            }

            switch (MenuOption)
            {
                case 1:
                    string UserName;
                    (bool isValidUsername, string ShowErrorMesaje) UserResult;

                    Console.WriteLine("Cree su nombre de usuario--");
                    UserName = Console.ReadLine();

                    UserResult = HelpersUniversales.ValidateTextWithoutNumbers(UserName);

                    //validar que hayan digitos ni este vacio
                    if (!UserResult.isValidUsername)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Error. ");
                        Console.ResetColor();
                        Console.WriteLine(UserResult.ShowErrorMesaje);
                        Console.WriteLine("Presione una tecla para volver al menú...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }

                    var nuevoUsuario = new UserEntity(UserName);

                    int id = UserService.GetIDByUser(UserName);
                    nuevoUsuario.SetId(id);

                    string resultado = UserService.NewUser(UserName, id);
                    Console.WriteLine(resultado);
                    serverProvider.AddSingleton<UserEntity>(sp => new UserEntity(UserName));

                    break;
                case 2:

                    var ShowUsersCase2 = UserService.GetUserList();
                    bool AreUsersCase2 = HelpersUser.UserCheker(ShowUsersCase2);

                    if (!AreUsersCase2)
                    {
                        break;
                    }

                    //si hay usuarios se muestra la lista
                    HelpersUser.ShowUsers(ShowUsersCase2);

                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();

                    break;
                case 3:

                    var ShowUsersCase3 = UserService.GetUserList();
                    bool AreUsers = HelpersUser.UserCheker(ShowUsersCase3);

                    if (!AreUsers)
                    {
                        break;
                    }

                    string ExistingUser;
                    (bool isValidUsername, string ShowErrorMensaje) ExistingUserResult;

                    Console.WriteLine("Ingrese el user al que se le enviaran las notificaciones");
                    ExistingUser = Console.ReadLine();

                    ExistingUserResult = HelpersUniversales.ValidateTextWithoutNumbers(ExistingUser);

                    //validar que ExistingUser no este vacio ni con numeros
                    if (!ExistingUserResult.isValidUsername)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Error. ");
                        Console.ResetColor();
                        Console.WriteLine(ExistingUserResult.ShowErrorMensaje);
                        Console.WriteLine("Presione una tecla para volver al menú...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }

                    //chequea que el usuario exista
                    bool existeUsuario = UserService.CheckUserExists(ExistingUser);
                    if (!existeUsuario)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("User no registrado.");
                        Console.ResetColor();
                        Console.WriteLine("Presione una tecla para volver al menú...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }

                    //Validate NotificationType
                    int NotificationType;
                    (bool IsValidNotificationType, string ShowErrorMessage) ValidateNotificationType;
                    do
                    {
                        ValidateNotificationType = HelperNotification.ValidateNotificationType(out NotificationType);

                        //validar NotificationType
                        if (!ValidateNotificationType.IsValidNotificationType)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Error. ");
                            Console.ResetColor();
                            Console.WriteLine(ValidateNotificationType.ShowErrorMessage);
                            Console.WriteLine("Presione una tecla para intentar de nuevo...");
                            Console.ReadKey();
                            Console.Clear();
                        }

                    } while (!ValidateNotificationType.IsValidNotificationType);

                    //Validate NotificationChannel
                    int NotificationChannel;
                    (bool IsValidNotificationChannel, string ShowErrorMessage) ValidateNotificationChannel;
                    do
                    {
                        ValidateNotificationChannel = HelperNotification.ValidateNotificationChannel(out NotificationChannel);

                        if (!ValidateNotificationChannel.IsValidNotificationChannel)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Error. ");
                            Console.ResetColor();
                            Console.WriteLine(ValidateNotificationChannel.ShowErrorMessage);
                            Console.WriteLine("Presione una tecla para intentar de nuevo...");
                            Console.ReadKey();
                            Console.Clear();
                        }

                    } while (!ValidateNotificationChannel.IsValidNotificationChannel);


                    var flujo = new NotificationFlowService(UserService, NotificationService, NotificationFactory);

                    


                    flujo.EnviarNotificacion(ExistingUser, NotificationChannel, NotificationType);

                    


                    Console.WriteLine("Presione una tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();

                    break;
                    
            }
        } while (MenuOption != 4);
    }
}