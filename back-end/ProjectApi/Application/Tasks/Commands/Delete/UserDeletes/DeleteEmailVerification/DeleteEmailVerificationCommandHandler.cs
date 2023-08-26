using AppDomain.DTO;
using AppDomain.Interfaces;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Commands.Delete.UserDeletes.DeleteEmailVerification;

public class DeleteEmailVerificationCommandHandler : IRequestHandler<DeleteEmailVerificationCommand, string>
{
    private readonly IUserRepository _userRepository;

    public DeleteEmailVerificationCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> Handle(DeleteEmailVerificationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _userRepository.DeleteEmailVerificationAsync(request.Email, request.OTP);

            return result;
        }
        catch (Exception)
        {
            return null!;
        }
    }
}