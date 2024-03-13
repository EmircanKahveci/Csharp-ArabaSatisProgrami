﻿using Core.DataAccess;
using Entities.DTOs;
using Entities.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Abstract
{
   public interface ICustomerDal:IEntityRepository<Customer>
    {
         List<CustomerDetailDto> GetCustomerDetails();
    }
}
