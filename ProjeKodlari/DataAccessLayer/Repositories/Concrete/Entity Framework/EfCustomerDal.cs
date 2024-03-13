using Core.DataAccess.EntityFramework;
using DataAccessLayer.Repositories.Abstract;
using Entities.DTOs;
using Entities.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Concrete.Entity_Framework
{
   public class EfCustomerDal:EfEntityRepositoryBase<Customer,ReCarContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCarContext context = new ReCarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.LastName equals u.LastName
                             select new CustomerDetailDto
                             {
                                 UserId = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = c.TcNo
                             };
                return result.ToList();
            }
        }
    }
}
