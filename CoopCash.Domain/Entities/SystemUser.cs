using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoopCash.Domain.Enums;

namespace CoopCash.Domain.Entities
{
    public class SystemUser: EntityBase
    {
        public SystemUser(Guid id, string name, string password, string role, string[] permissions, UserType type)
        {
            Id = id;
            Name = name;
            Password = password;
            Role = role;
            Permissions = permissions;
            Type = type;
        }

        public string Name { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Role { get; set; } = default!;
        public string[] Permissions { get; set; } = Array.Empty<string>();
        public UserType Type { get; set; }
    }
}
