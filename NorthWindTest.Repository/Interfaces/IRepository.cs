using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWindTest.Repository.Interfaces
{
    public interface IRepository
    {
        /// <summary>
        /// 取得Script
        /// </summary>
        /// <param name="Category"></param>
        /// <param name="ScriptName"></param>
        /// <returns></returns>
        //string GetScript(string Category, string ScriptName);

        /// <summary>
        /// 取得資料
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="sql">script</param>
        /// <param name="param">param</param>
        /// <returns></returns>
        IEnumerable<T> Query<T>(string sql, object param = null);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sql">script</param>
        /// <param name="param">parameters</param>
        /// <returns>回傳更新的筆數</returns>
        int Execute(string sql, object param);


    }
}
