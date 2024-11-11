namespace Application.Features.Auth.DTOs;

public class HoldingItemDto
{
    public Guid Id { get; set; }
    public string Symbol { get; set; }
    public decimal Quantity { get; set; }
}