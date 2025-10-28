using Domain.Common;
using Application.DTOs.Customer;
using Application.Mapper;
using Domain.Interfaces;

public class GetAllCustomersUseCase
{
    private readonly ICustomerRepository _customerRepository;
    public GetAllCustomersUseCase(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<PagedResult<CustomerResponse>?> ExecuteAsync(int page, int pageSize)
    {
        var result = await _customerRepository.GetAllPagedAsync(page, pageSize);

      // 2. Map Entity sang DTO
      var dtos = result.Items.Select(CustomerMapper.ToResponse);

      // 3. Trả về PagedResult DTO
      return new PagedResult<CustomerResponse>(
          dtos,
          result.TotalCount,
          result.Page,
          result.PageSize
      );
   }
}