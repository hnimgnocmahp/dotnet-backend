using Application.DTOs.Promotion;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.UseCases;

public class CreatePromotionUseCase
{
    private readonly IPromotionRepository _promotionRepo;

    public CreatePromotionUseCase(IPromotionRepository promotionRepo)
    {
        _promotionRepo = promotionRepo;
    }

    public async Task<PromotionResponse?> ExecuteAsync(PromotionRequest request)
    {
        var promotion = request.ToEntity(); // mapping từ input DTO sang domain
        await _promotionRepo.AddAsync(promotion); // làm việc với entity
        return promotion.ToResponse(); // mapping domain sang output DTO
    } 
}