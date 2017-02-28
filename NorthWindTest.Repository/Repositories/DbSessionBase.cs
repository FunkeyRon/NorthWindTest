using NorthWindTest.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NorthWindTest.Repository.Repositories
{
    public class DbSessionBase: IDbSession
    {
        public DbSessionBase(string connString)
        {
            _connection = new SqlConnection(connString);
        }

        public DbSessionBase(IDbConnection connection)
        {
            _connection = connection;
        }

        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _IsUnitOfWork = false;

        public bool IsUnitOfWork
        {
            get { return _IsUnitOfWork; }
            set { _IsUnitOfWork = value; }
        }

        public IDbConnection Connection
        {
            get { return _connection; }
        }

        public IDbTransaction Transaction
        {
            get { return _transaction; }
        }


        /// <summary>
        /// 開始連線資料庫
        /// </summary>
        /// <param name="isolation"></param>
        /// <returns></returns>
        public void Create(IsolationLevel isolation = IsolationLevel.ReadCommitted)
        {
            _connection.Open();
            _transaction = _connection.BeginTransaction(isolation);
        }

        /// <summary>
        /// Commit
        /// </summary>
        public void Commit()
        {
            _transaction.Commit();
            _transaction = null;
        }

        /// <summary>
        /// Rollback
        /// </summary>
        public void Rollback()
        {
            _transaction.Rollback();
            _transaction = null;
        }

        /// <summary>
        /// 釋放資源
        /// </summary>
        public void Dispose()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                    _transaction = null;
                }
                _connection.Close();
                _connection = null;
            }
            GC.SuppressFinalize(this);
        }

    }
}
