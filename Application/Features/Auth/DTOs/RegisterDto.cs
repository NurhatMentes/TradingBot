namespace Application.Features.Auth.DTOs;

public class RegisterDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
}