﻿using NorthWindTest.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWindTest.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerDataModel> GetCusetomers();
    }
}
