using AppTemplate.Domain.Entities;
using AppTemplate.Domain.Interfaces.Repository;
using AppTemplate.Domain.Transaction.Interface;

using LSM.Generic.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplate.Infra.Data.Repositories
{
    public class UserTesteRepository : RepositoryBase<User>, IUserTesteRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserTesteRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User Add(User obj)
        {
            try
            {
                var conn = (SqlConnection)_unitOfWork.GetConnection();

                _unitOfWork.InitializeTransaction();
                using (var cmd = (SqlCommand)_unitOfWork.GetSqlCommand("AddUserTeste"))
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
                throw ex;
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
                var conn = (SqlConnection)_unitOfWork.GetConnection();
                var dt = new DataTable();
                _unitOfWork.InitializeTransaction();
                using (var cmd = (SqlCommand)_unitOfWork.GetSqlCommand("GetAllUserTeste"))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    dt.Load(cmd.ExecuteReader());


                }
                return DtMapper.DataTableToList<User>(dt);
            }
            catch (Exception ex)
            {
                _unitOfWork.AddNotification(new Domain.Notification.Notification() { Data = DateTime.Now, Message = ex.Message, IsError = true, WhoSend = "Repository" });
                throw ex;
            }

        }

        public User GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Remove(User obj)
        {
            throw new NotImplementedException();
        }

        public void Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
