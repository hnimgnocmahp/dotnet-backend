using Application.DTOs.Customer;
using Application.Mapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases;

public class UpdateCustomerUseCase(ICustomerRepository customerRepository)
{
   private readonly ICustomerRepository _customerRepository = customerRepository;

   public async Task<CustomerResponse> ExecuteAsync(int id, UpdateCustomerRequest req)
   {
      var customer = await _customerRepository.GetByIdAsync(id);
      if (customer == null)
      {
         throw new Exception("Không tìm thấy khách hàng.");
      }

      if (!string.IsNullOrEmpty(req.Email) && req.Email != customer.Email)
      {
         var existing = await _customerRepository.GetByEmailAsync(req.Email);
         if (existing != null)
         {
            throw new Exception("Email đã tồn tại.");
         }
      }
      customer.CustomerId = req.CustomerId;
      customer.Name = req.Name;
      customer.Phone = req.Phone;
      customer.Email = req.Email;
      customer.Address = req.Address;

      var result = await _customerRepository.UpdateAsync(customer);

      return CustomerMapper.ToResponse(result);
   }

}