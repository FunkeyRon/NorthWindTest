using NorthWindTest.Repository;
using NorthWindTest.Common.Helper;
using NorthWindTest.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWindTest.Service.Services
{
    public class CustomerService : ICustomerService
    {
        public CustomerService() { }

        public string GetCustomersReturnJson()
        {
            var jsonHelper = new JsonHelper();

            string result = jsonHelper.JsonObjectToString(RepositoriesFactory.CustomerRepository.GetCusetomers());

            return result;
        }

    }
}
