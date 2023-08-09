using AppDomain.DTOs.User;
using AppDomain.Interfaces;
using MediatR;

namespace Application.Tasks.Commands.Insert.InsertUser
{
    public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand, UserDTO>
    {
        private readonly IUserRepository _userRepository;

        public InsertUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetUserByIdAsync("example");

            return result;
        }
    }
}
