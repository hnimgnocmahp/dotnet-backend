using Domain.Interfaces;
using Domain.Entities;
using Application.DTOs.Category;
using Application.Mapper;
using Application.DTOs.Supplier;
public class GetCategoryByIdUseCase
{
    private readonly ICategoryRepository _categoryRepository;
    public GetCategoryByIdUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<CategoryResponse?> ExecuteAsync(int id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        if (category == null) return null;
        return category.ToResponse();
    }
}