using Application.Common.Interfaces;
using Core.Constants;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    private readonly IApplicationDbContext _context;

    public RegisterCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage(Messages.Validation.RequiredField)
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage(Messages.Validation.RequiredField)
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(Messages.Validation.RequiredField)
            .EmailAddress().WithMessage(Messages.Validation.InvalidEmail)
            .MustAsync(BeUniqueEmail).WithMessage("Email already exists");

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage(Messages.Validation.RequiredField)
            .MinimumLength(3).WithMessage("Username must be at least 3 characters")
            .MustAsync(BeUniqueUsername).WithMessage("Username already exists");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(Messages.Validation.RequiredField)
            .MinimumLength(6).WithMessage("Password must be at least 6 characters");

        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password).WithMessage("Passwords do not match");
    }

    private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
    {
        return !await _context.Users.AnyAsync(x => x.Email == email, cancellationToken);
    }

    private async Task<bool> BeUniqueUsername(string username, CancellationToken cancellationToken)
    {
        return !await _context.Users.AnyAsync(x => x.Username == username, cancellationToken);
    }
}