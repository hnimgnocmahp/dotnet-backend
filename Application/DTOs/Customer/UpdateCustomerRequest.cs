using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Customer;

public record UpdateCustomerRequest(
    int CustomerId,
    string Name,
    string? Phone,
    string? Email,
    string? Address
);