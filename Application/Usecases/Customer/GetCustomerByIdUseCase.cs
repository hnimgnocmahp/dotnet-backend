using Application.DTOs.Customer;
using Application.Mapper;
using Domain.Interfaces;

namespace Application.UseCases;

public class GetCustomerByIdUseCase(ICustomerRepository customerRepository)
{
   private readonly ICustomerRepository _customerRepository = customerRepository;
   public async Task<CustomerResponse?> ExecuteAsync(int id)
   {
      var customer = await _customerRepository.GetByIdAsync(id);

      if (customer == null)
         return null;

      return CustomerMapper.ToResponse(customer);
   }
}