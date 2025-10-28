using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Customer;

public record CreateCustomerRequest(
    string Name,
    string? Phone,
    string? Email,
    string? Address
);