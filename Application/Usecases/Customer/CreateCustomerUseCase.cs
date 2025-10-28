using Application.DTOs.Customer;
using Application.Mapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases;

public class CreateCustomerUseCase
{
   private readonly ICustomerRepository _customerRepository;

   public CreateCustomerUseCase(ICustomerRepository cusRepo)
   {
      _customerRepository = cusRepo;
   }

   public async Task<CustomerResponse> ExecuteAsync(CreateCustomerRequest req)
   {
      // 1. Kiểm tra nghiệp vụ (ví dụ: email không được trùng)
      if (!string.IsNullOrEmpty(req.Email))
      {
         var existing = await _customerRepository.GetByEmailAsync(req.Email);
         if (existing != null)
         {
            throw new Exception("Email đã tồn tại.");
         }
      }

      var customer = new Domain.Entities.Customer
      {
         Name = req.Name,
         Phone = req.Phone,
         Email = req.Email,
         Address = req.Address
      };


      var newCustomer = await _customerRepository.AddAsync(customer);

      return CustomerMapper.ToResponse(newCustomer);

   }

   

}