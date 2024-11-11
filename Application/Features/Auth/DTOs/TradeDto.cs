using Domain.Enums;

namespace Application.Features.Auth.DTOs;

public class TradeDto
{
    public Guid Id { get; set; }
    public string Symbol { get; set; }
    public decimal EntryPrice { get; set; }
    public decimal? ExitPrice { get; set; }
    public int Quantity { get; set; }
    public OrderType OrderType { get; set; }
    public TradeStatus Status { get; set; }
    public DateTime EntryTime { get; set; }
    public DateTime? ExitTime { get; set; }
    public decimal? StopLoss { get; set; }
    public decimal? TakeProfit { get; set; }
    public decimal? ProfitLoss { get; set; }
    public double Duration { get; set; }  // Saat cinsinden
}