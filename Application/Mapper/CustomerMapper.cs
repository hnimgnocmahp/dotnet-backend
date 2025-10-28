using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Order;
using Domain.Entities;
using Application.DTOs.Customer;

namespace Application.Mapper
{
   public static class CustomerMapper
   {


      public static CustomerResponse ToResponse(Customer customer) => new(
      customer.CustomerId,
      customer.Name,
      customer.Phone,
      customer.Email,
      customer.Address,
      customer.CreatedAt
   );
   }
}
