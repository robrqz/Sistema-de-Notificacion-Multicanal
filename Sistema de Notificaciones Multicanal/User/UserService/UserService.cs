using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sistema_de_Notificaciones_Multicanal.User.Entities;


namespace Sistema_de_Notificaciones_Multicanal.User.UserService
{
    public class UserService
    {
        private List<UserEntity> _UserList = new List<UserEntity>();

        public string NewUser(string Name, int NewID)
        {
            if (_UserList.Exists(c => c.name.Equals(Name, StringComparison.OrdinalIgnoreCase)))
            {
                return "No pueden haber dos usuarios iguales";
            }

            NewID = _UserList.Any() ? _UserList.Max(u => u.id) + 1 : 1;

            var user = new UserEntity(Name);

            _UserList.Add(user);
            user.SetId(NewID);

            return $"User registrado correctamente con ID: {NewID}";
        }

        public int GetIDByUser(string name)
        {
            int resp = 1;
            var user = _UserList.Where(m => m.name.Equals(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (user != null)
            {
                resp = user.id;
            }
            else
            {
                resp = _UserList.Any() ? _UserList.Max(m => m.id) + 1 : 1;
            }
            return resp;
        }

        public List<UserEntity> GetUserList()
        {
            return _UserList;
        }

        public bool CheckUserExists(string nombreUsuario)
        {
            return _UserList.Any(u =>
                u.name.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase));
        }
    }
}
