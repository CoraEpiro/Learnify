using AppDomain.DTO;
using AppDomain.Interfaces;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Commands.Delete.UserDeletes.VerifyEmail
{
    public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand, Task>
    {
        private readonly IUserRepository _userRepository;

        public VerifyEmailCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Task> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.VerifyEmailAsync(request.Email, request.OTP);
        }
    }
}