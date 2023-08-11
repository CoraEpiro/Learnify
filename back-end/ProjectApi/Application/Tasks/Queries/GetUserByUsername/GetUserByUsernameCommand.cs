using AppDomain.Entities.UserRelated;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.GetUserByUsername;

public class GetUserByUsernameCommand : IRequest<User>
{
    public string Username { get; set; }
}