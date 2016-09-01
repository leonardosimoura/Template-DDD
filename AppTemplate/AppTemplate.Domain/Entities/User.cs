using LSM.Generic.Repository.Attribute;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplate.Domain.Entities
{
    [DebuggerDisplay("Id = {Id}; Name = {Name}; Email = {Email}")] 
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

        public User(string name, string email, string password,DateTime registerDate)
        {
            Id = 0;
            Name = name;
            Email = email;
            Password = password;
            RegisterDate = registerDate;
        }

        [DtMap("IdUsuario")]
        public int Id { get; set; }
        [DtMap("Nome")]
        public string Name { get;  set; }

        public string  Email { get;  set; }
        [DtMap("Senha")]
        public string Password { get;  set; }

        [DtMap("DataRegistro")]
        public DateTime? RegisterDate { get; set; }


        public void Register()
        {
            RegisterDate = DateTime.Now;
        }
    }
}
