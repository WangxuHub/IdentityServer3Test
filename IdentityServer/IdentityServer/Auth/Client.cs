using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityServer.Auth
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
            new Client
            {
                Enabled = true,
                ClientName = "JS Client",
                ClientId = "js",
                Flow = Flows.Implicit,

                RedirectUris = new List<string>
                {
                    "http://localhost:6749/popup.html"
                },

                AllowedCorsOrigins = new List<string>
                {
                    "http://localhost:6749"
                },

                AllowAccessToAllScopes = true,
                AccessTokenType =AccessTokenType.Jwt
            }
        };
        }
    }
}