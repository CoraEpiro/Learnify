using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.UserQueries.UserExistByEmail;

public class UserExistByEmailQuery : IRequest<bool>
{
    public string Email { get; set; }
}
