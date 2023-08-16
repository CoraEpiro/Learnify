using AppDomain.DTO;
using AppDomain.DTOs.User;
using AppDomain.Entities.UserRelated;
using MediatR;

namespace Application.Tasks.Commands.Insert.UserInserts.InserOTPCode;

public class InsertOTPCommand : IRequest<Task>
{
    public string Email { get; set; }
}