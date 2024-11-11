namespace Application.Features.Auth.DTOs;

public class PortfolioDto
{
    public Guid Id { get; set; }
    public decimal Balance { get; set; }
    public decimal InitialBalance { get; set; }
    public decimal TotalValue { get; set; }
    public List<HoldingItemDto> Holdings { get; set; }
}