using Application.DTOs.Category;
using Domain.Interfaces;
using Domain.Entities;
using Application.Mapper;
using Application.DTOs.Supplier;
namespace Application.Usecases.Category;
public class GetAllCategoryUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoryUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryResponse>?> ExecuteAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        if (categories == null) return null;
        return categories.ToResponse();
    }
}