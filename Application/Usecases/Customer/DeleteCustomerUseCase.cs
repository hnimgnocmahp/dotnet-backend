using Domain.Interfaces;

namespace Application.UseCases;

public class DeleteCustomerUseCase(ICustomerRepository customerRepository)
{
   private readonly ICustomerRepository _customerRepository = customerRepository;

   public async Task<bool> ExecuteAsync(int id)
   {
      var customer = await _customerRepository.GetByIdAsync(id);
      if (customer == null)
      {
         throw new Exception("Không tìm thấy khách hàng.");
      }

      var result = await _customerRepository.DeleteAsync(customer);
   
      return result;
   }
}