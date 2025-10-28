namespace Application.DTOs.Customer;

public record CustomerResponse(
   int CustomerId,
   string Name,
   string? Phone,
   string? Email,
   string? Address,
   DateTime CreatedAt
);