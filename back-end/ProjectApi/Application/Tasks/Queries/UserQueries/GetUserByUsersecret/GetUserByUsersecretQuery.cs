using AppDomain.Entities.UserRelated;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.UserQueries.GetUserByUsersecret;

public class GetUserByUsersecretQuery : IRequest<User>
{
    public string Secret { get; set; }
}