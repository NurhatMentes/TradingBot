using Domain.Enums;

namespace Application.Features.Auth.DTOs;

public class TradingStrategyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal RiskPercentage { get; set; }
    public decimal MaxPositionSize { get; set; }
    public TimeFrame TimeFrame { get; set; }
    public bool IsActive { get; set; }
    public Dictionary<string, string> Parameters { get; set; }
}