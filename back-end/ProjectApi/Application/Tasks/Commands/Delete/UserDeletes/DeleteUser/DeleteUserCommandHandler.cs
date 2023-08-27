using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using MediatR;

namespace Application.Tasks.Commands.Delete.UserDeletes.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _userRepository.DeleteUserAsync(request.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}