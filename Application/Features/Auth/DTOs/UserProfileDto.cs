namespace Application.Features.Auth.DTOs;

public class UserProfileDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public bool IsActive { get; set; }
    public string TelegramChatId { get; set; }
    public decimal Balance { get; set; }
    public List<PortfolioDto> Portfolios { get; set; }
}