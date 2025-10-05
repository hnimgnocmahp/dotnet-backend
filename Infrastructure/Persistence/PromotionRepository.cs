using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class PromotionRepository : IPromotionRepository
{
    private readonly AppDbContext _context;
    public PromotionRepository(AppDbContext context) => _context = context;

}
