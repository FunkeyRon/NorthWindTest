using NorthWindTest.Common.Helper;
using NorthWindTest.Models.DataModels;
using NorthWindTest.Models.JsonConfigModels;
using NorthWindTest.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWindTest.Repository.Repositories
{
    public class CustomerRepository : RepositoryBase, ICustomerRepository
    {
        public CustomerRepository() : base(new DbSessionBase(connectionStrings.NorthwindConnection)) { }
        public CustomerRepository(IDbSession _dbSession) : base(_dbSession) { }


        public IEnumerable<CustomerDataModel> GetCusetomers()
        {
            string sql = base.GetScript("Customer", "GetCustomers");
            IEnumerable<CustomerDataModel> result = base.Query<CustomerDataModel>(sql);
            return result;
        }
    }
}
