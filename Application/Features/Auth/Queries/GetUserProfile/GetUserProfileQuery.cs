using Application.Common.Interfaces;
using Application.Features.Auth.DTOs;
using AutoMapper;
using Core.Constants;
using Core.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auth.Queries.GetUserProfile
{
    public class GetUserProfileQuery : IRequest<Core.Results.IDataResult<UserProfileDto>>
    {
        public Guid UserId { get; set; }
    }

    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, Core.Results.IDataResult<UserProfileDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUserProfileQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Core.Results.IDataResult<UserProfileDto>> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Include(u => u.PortfolioIds)
                .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (user == null)
                return new ErrorDataResult<UserProfileDto>(Messages.Auth.UserNotFound);

            var userProfile = _mapper.Map<UserProfileDto>(user);
            return new SuccessDataResult<UserProfileDto>(userProfile);
        }
    }
}
