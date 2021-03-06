﻿using AppTemplate.Domain.Interfaces.Repository;
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
        private readonly IUnitOfWorkTS _unitOfWork;
        
        public UserRepository(IUnitOfWorkTS unitOfWork):base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.Begin();
        }

        public User Add(User obj)
        {
            try
            {
                //Opcional fazer vai da regra do projeto
                if (_unitOfWork.HasError())
                {
                    return null;
                }

                using (var conn = new SqlConnection(GetConnectionString(Connection.Padrao)))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("AddUsuario", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Name", obj.Name);
                        cmd.Parameters.AddWithValue("Email", obj.Email);
                        cmd.Parameters.AddWithValue("Password", obj.Password);
                        cmd.Parameters.AddWithValue("RegisterDate", obj.RegisterDate);
                        cmd.ExecuteNonQuery();
                    }
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
                //Opcional fazer vai da regra do projeto
                if (_unitOfWork.HasError())
                {
                    return null;
                }

                var dt = new DataTable();
                
                using (var conn = new SqlConnection(GetConnectionString(Connection.Padrao)))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("GetAllUsuario", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        dt.Load(cmd.ExecuteReader());
                    }
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
