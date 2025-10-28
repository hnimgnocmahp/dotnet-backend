using Domain.Common;
using Application.DTOs.Customer;
using Application.Mapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases;

public class SearchCustomersUseCase(ICustomerRepository customerRepository)
{
   private readonly ICustomerRepository _customerRepository = customerRepository;

   public async Task<PagedResult<CustomerResponse>?> ExecuteAsync(string searchTerm, int page, int pageSize)
   {
      // 1. Gọi Repository đã phân trang
      var result = await _customerRepository.SearchPagedAsync(searchTerm,page, pageSize);

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