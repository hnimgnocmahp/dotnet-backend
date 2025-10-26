using Application.DTOs.Product;
using Application.Mappers;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases
{
    public class UpdateProductUseCase
    {
        private readonly IProductRepository _repository;

        public UpdateProductUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductResponse?> ExecuteAsync(int id, ProductRequest request)
        {
            // Lấy sản phẩm cần cập nhật
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
                return null;

            // Cập nhật dữ liệu
            product.ProductName = request.ProductName;
            product.Barcode = request.Barcode;
            product.CategoryId = request.CategoryId;
            product.SupplierId = request.SupplierId;
            product.Unit = request.Unit;
            product.Price = request.Price;

            // Gọi repo update và lưu thay đổi
            await _repository.UpdateAsync(product);

            // Trả về ProductResponse (dùng mapper)
            return product.ToResponse();
        }
    }
}
