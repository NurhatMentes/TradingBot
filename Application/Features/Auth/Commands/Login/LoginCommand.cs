using Application.Common.Interfaces;
using Core.Constants;
using Core.Results;
using Core.Security.Hashing;
using Core.Security.JWT;
using FluentValidation;
using MediatR;
using Application.Features.Auth.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<IDataResult<LoginDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(Messages.Validation.RequiredField)
                .EmailAddress().WithMessage(Messages.Validation.InvalidEmail);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(Messages.Validation.RequiredField)
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");
        }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, IDataResult<LoginDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHashingHelper _hashingHelper;
        private readonly ITokenHelper _tokenHelper;

        public LoginCommandHandler(
            IApplicationDbContext context,
            IHashingHelper hashingHelper,
            ITokenHelper tokenHelper)
        {
            _context = context;
            _hashingHelper = hashingHelper;
            _tokenHelper = tokenHelper;
        }

        public async Task<IDataResult<LoginDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

            if (user == null)
                return new ErrorDataResult<LoginDto>(Messages.Auth.UserNotFound);

            if (!_hashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                return new ErrorDataResult<LoginDto>(Messages.Auth.PasswordError);

            var operationClaims = await _context.UserOperationClaims
                .Include(x => x.OperationClaim)
                .Where(x => x.UserId == user.Id)
                .Select(x => x.OperationClaim)
                .ToListAsync(cancellationToken);

            var accessToken = _tokenHelper.CreateToken(user, operationClaims);

            return new SuccessDataResult<LoginDto>(new LoginDto
            {
                AccessToken = accessToken,
                UserId = user.Id,
                Email = user.Email,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName
            }, Messages.Auth.SuccessfulLogin);
        }
    }
}