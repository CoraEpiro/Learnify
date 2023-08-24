using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.UserQueries.UserExistByUsername;

public class UserExistByUsernameQuery : IRequest<bool>
{
    public string Username { get; set; }
}
