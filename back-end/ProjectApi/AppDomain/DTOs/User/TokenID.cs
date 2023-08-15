using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.DTOs.User;

public class TokenID
{
    public string Id { get; set; }
    public string AccessToken { get; set; }

    public TokenID(string id, string accessToken)
    {
        Id = id;
        AccessToken = accessToken;
    }
}