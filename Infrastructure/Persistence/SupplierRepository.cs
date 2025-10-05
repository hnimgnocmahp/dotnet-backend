using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class SupplierRepository : ISupplierRepository
{
    private readonly AppDbContext _context;
    public SupplierRepository(AppDbContext context) => _context = context;

}
