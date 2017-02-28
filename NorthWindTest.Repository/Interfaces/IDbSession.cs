using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWindTest.Repository.Interfaces
{
    public interface IDbSession
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        bool IsUnitOfWork { get; set; }

        void Create(IsolationLevel isolation = IsolationLevel.ReadCommitted);
        void Commit();
        void Rollback();
        void Dispose();
    }
}
