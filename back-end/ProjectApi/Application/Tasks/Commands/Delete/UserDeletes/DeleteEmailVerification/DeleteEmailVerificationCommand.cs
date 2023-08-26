using AppDomain.DTO;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Commands.Delete.UserDeletes.DeleteEmailVerification;

public class DeleteEmailVerificationCommand : IRequest<string>
{
    public string Email { get; set; }
    public string OTP { get; set;}
}