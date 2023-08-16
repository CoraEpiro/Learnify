using AppDomain.DTO;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Commands.Delete.UserDeletes.VerifyEmail;

public class VerifyEmailCommand : IRequest<Task>
{
    public string Email { get; set; }
    public string OTP { get; set;}
}