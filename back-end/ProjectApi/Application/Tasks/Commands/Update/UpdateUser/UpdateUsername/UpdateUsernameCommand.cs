﻿using AppDomain.Entities.UserRelated;
using MediatR;

namespace Application.Tasks.Commands.Update.UpdateUser.UpdateUsername;

public class UpdateUsernameCommand : IRequest<User>
{
    public string Id { get; set; }
    public string Username { get; set; }
}