using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Prototype
{
    public class User
    {
        public string Username { get; }
        public HashSet<string> Permissions { get; }
        public User(string username, IEnumerable<string> permissions)
        {
            Username = username;
            Permissions = new HashSet<string>(permissions);
        }
        public bool HasPermission(string permission)
        {
            return Permissions.Contains(permission);
        }
    }
}
