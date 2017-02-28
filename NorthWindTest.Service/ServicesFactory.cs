using NorthWindTest.Service.Interface;
using NorthWindTest.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWindTest.Service
{
    public static class ServicesFactory
    {
        static ServicesFactory()
        {
            CustomerService = CustomerService ?? new CustomerService();
        }

        public static ICustomerService CustomerService { get; set; }

    }
}
