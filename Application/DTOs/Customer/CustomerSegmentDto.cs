namespace Application.DTOs.Customer;

public record CustomerSegmentDto(
    int CustomerId,
    string CustomerName,
    string Segment, // Sẽ là "VIP", "Khách thân thiết", "Khách mới"
    decimal TotalSpending
);