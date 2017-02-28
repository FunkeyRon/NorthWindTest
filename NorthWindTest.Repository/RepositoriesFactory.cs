using NorthWindTest.Repository.Interfaces;
using NorthWindTest.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWindTest.Repository
{
    public static class RepositoriesFactory
    {
        static RepositoriesFactory()
        {
            CustomerRepository = CustomerRepository ?? new CustomerRepository();
        }

        public static ICustomerRepository CustomerRepository { get; set; }


    }
}
