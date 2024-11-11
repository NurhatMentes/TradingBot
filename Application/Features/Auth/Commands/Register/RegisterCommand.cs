using Application.Common.Interfaces;
using Application.Features.Auth.DTOs;
using Core.Constants;
using Core.Entities.Concrete;
using Core.Enums;
using Core.Results;
using Core.Security.Hashing;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<IDataResult<RegisterDto>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, IDataResult<RegisterDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHashingHelper _hashingHelper;

        public RegisterCommandHandler(
            IApplicationDbContext context,
            IHashingHelper hashingHelper)
        {
            _context = context;
            _hashingHelper = hashingHelper;
        }

        public async Task<IDataResult<RegisterDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _context.Users
                .AnyAsync(u => u.Email == request.Email || u.Username == request.Username, cancellationToken);

            if (userExists)
                return new ErrorDataResult<RegisterDto>(Messages.Auth.UserAlreadyExists);


            _hashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Username,
                passwordHash,
                passwordSalt
            );

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken); 

         
            var basicClaims = await _context.OperationClaims
                .Where(c => new[] {
                OperationClaimType.UserView.ToString(),
                OperationClaimType.ProjectView.ToString(),
                OperationClaimType.TaskView.ToString(),
                OperationClaimType.MessageView.ToString(),
                OperationClaimType.NotificationView.ToString()
                }.Contains(c.Name))
                .ToListAsync(cancellationToken);

     
            foreach (var claim in basicClaims)
            {
                var userClaim = new UserOperationClaim(user.Id, claim.Id);
                await _context.UserOperationClaims.AddAsync(userClaim, cancellationToken);
            }

            await _context.SaveChangesAsync(cancellationToken); 

         
            var registerDto = new RegisterDto
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username
            };

            return new SuccessDataResult<RegisterDto>(registerDto, Messages.Auth.UserRegistered);
        }
    }

}
