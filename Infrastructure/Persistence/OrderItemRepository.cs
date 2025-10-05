using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly AppDbContext _context;
    public OrderItemRepository(AppDbContext context) => _context = context;

}
