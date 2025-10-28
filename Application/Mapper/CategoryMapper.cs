using Application.DTOs.Category;
using Application.DTOs.Supplier;
using Domain.Entities;
using Microsoft.VisualBasic;
namespace Application.Mapper
{
    public static class CategoryMapper
    {
        public static CategoryResponse ToResponse(this Category category)
            => new CategoryResponse(
                category.CategoryId,
                category.CategoryName
            );
        public static List<CategoryResponse> ToResponse(this IEnumerable<Category> entities)
    => entities.Select(c => c.ToResponse()).ToList();

        public static Category ToEntity(this CategoryRequest request)
            => new()
            {
                CategoryName = request.Name
            };

    }
}