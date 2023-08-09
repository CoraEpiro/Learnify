using AppDomain.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Insert.InsertUser
{
    public class InsertUserCommand : IRequest<UserDTO>
    {
        public UserDTO User { get; set;}
    }
}
