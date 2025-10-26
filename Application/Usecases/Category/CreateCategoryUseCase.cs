using Application.DTOs.Category;
using Domain.Interfaces;
using Domain.Entities;
using Application.DTOs.Supplier;
using Application.Mapper;
public class CreateCategoryUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryResponse?> ExecuteAsync(CategoryRequest request)
    {
        var category = request.ToEntity();

        await _categoryRepository.AddAsync(category);

        return category.ToResponse(); 
    }
}