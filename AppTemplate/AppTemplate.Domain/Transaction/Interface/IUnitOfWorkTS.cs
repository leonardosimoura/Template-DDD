using AppTemplate.Domain.Notification.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplate.Domain.Transaction.Interface
{
    /// <summary>
    /// Responsável por gerenciar o Transaction Scope
    /// </summary>
    public interface IUnitOfWorkTS : IDomainNotification, IDisposable
    {
        /// <summary>
        /// Inicia a transação (Transaction Scope)
        /// </summary>
        void Begin();

        /// <summary>
        /// Realiza o commit caso não exista erros
        /// </summary>
        void Commit();        
    }
}
