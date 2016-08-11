using LSM.Generic.Repository.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplate.Domain.Entities
{
    public class User
    {
        public User()
        {

        }
        public User(string name, string email, string password)
        {
            Id = 0;
            Name = name;
            Email = email;
            Password = password;
        }

        public User(int id,string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        [DtMap("IdUsuario")]
        public int Id { get; set; }
        [DtMap("Nome")]
        public string Name { get;  set; }

        public string  Email { get;  set; }
        [DtMap("Senha")]
        public string Password { get;  set; }
    }
}
