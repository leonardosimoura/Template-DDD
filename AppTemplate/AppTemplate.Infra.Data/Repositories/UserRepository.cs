using AppTemplate.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTemplate.Domain.Entities;

using System.Data.SqlClient;
using System.Data;
using LSM.Generic.Repository;
using AppTemplate.Domain.Transaction.Interface;

namespace AppTemplate.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.InitializeConnection(GetConnectionString(Connection.Padrao));            
        }

        public User Add(User obj)
        {
            try
            {
                using (var cmd = _unitOfWork.GetSqlCommand("AddUsuario"))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Name", obj.Name);
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("Password", obj.Password);
                    cmd.ExecuteNonQuery();
                }

                return obj;
            }
            catch (Exception ex)
            {
                _unitOfWork.AddNotification(new Domain.Notification.Notification() { Data = DateTime.Now, Message = ex.Message, IsError = true, WhoSend = "Repository" });
                return null;
            }            
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                //throw new Exception("Teste");
                var dt = new DataTable();
                using (var cmd = (SqlCommand)_unitOfWork.GetSqlCommand("GetAllUsuario"))
                {                  
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    dt.Load(cmd.ExecuteReader());
                }

                return DtMapper.DataTableToList<User>(dt);
            }
            catch (Exception ex)
            {
                _unitOfWork.AddNotification( new Domain.Notification.Notification() { Data = DateTime.Now, Message = ex.Message , IsError = true, WhoSend = "Repository" });
                return null;
            }            
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return new User("Leonardo", email, password);
        }

        public User GetById(object id)
        {

            if (id is int)
            {
                return new User("INT", "INT@INT.com.br", "pwd");
            }
            if (id is string)
            {
                return new User("string", "string@string.com.br", "pwd");
            }
            else
            {
                return new User("Leonardo", "leonardo@leonardo.com.br", "pwd");
            }
            
        }

        public void Remove(User obj)
        {
            
        }

        public void Update(User obj)
        {
            
        }
    }
}
