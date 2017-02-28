using NorthWindTest.Common.Helper;
using NorthWindTest.Models.JsonConfigModels;
using NorthWindTest.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace NorthWindTest.Repository.Repositories
{
    public class RepositoryBase: IRepository
    {
        private IDbSession _session;
        private static SqlConfigRoot jsonRoot = null;
        protected static string configPath = "C:\\Project\\NorthWindTest\\NorthWindTest\\App_Data\\SQLScript.json";

        /// <summary>
        /// RepositoryBase
        /// </summary>
        /// <param name="session"></param>
        public RepositoryBase(IDbSession session)
        {
            _session = session;

            if (jsonRoot == null)
            {
                //物件化Json檔案
                JsonHelper configReader = new JsonHelper();
                jsonRoot = configReader.GetJsonObject<SqlConfigRoot>(configPath);
            }
        }

        /// <summary>
        /// GetScript
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="scriptName"></param>
        /// <returns></returns>
        protected string GetScript(string categoryName, string scriptName)
        {
            string scriptResult = string.Empty;

            //取的Script
            CategoryItem categoryItem = jsonRoot.Categories.ToList().Where(p => p.name == categoryName).FirstOrDefault();

            if (categoryItem != null)
            {
                List<Script> lstScr = categoryItem.Scripts;
                scriptResult = lstScr.Where(p => p.name == scriptName).FirstOrDefault() != null ?
                               lstScr.Where(p => p.name == scriptName).FirstOrDefault().cmd : string.Empty;
            }

            return scriptResult;
        }

        /// <summary>
        /// Query<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string sql, object param = null)
        {
            IEnumerable<T> result = null;

            if (_session.IsUnitOfWork)
                _session.Create();

            result = _session.Connection.Query<T>(sql, param, _session.Transaction);

            if (_session.IsUnitOfWork)
            {
                _session.Commit();
                _session.Dispose();
            }
            return result;
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Execute(string sql, object param)
        {
            int result = 0;

            if (_session.IsUnitOfWork)
                _session.Create();

            result = _session.Connection.Execute(sql, param, _session.Transaction);

            if (_session.IsUnitOfWork)
            {
                _session.Commit();
                _session.Dispose();
            }
            return result;
        }

    }
}
