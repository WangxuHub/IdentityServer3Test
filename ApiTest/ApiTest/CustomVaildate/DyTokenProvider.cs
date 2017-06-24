using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ApiTest.CustomVaildate
{
    public class DyTokenProvider: IOAuthBearerAuthenticationProvider
    {
        
        public Task ApplyChallenge(OAuthChallengeContext context)
        {
            return Task.FromResult(0);
        }

        public Task RequestToken(OAuthRequestTokenContext context)
        {
            var token = "";
            
            string authorization = context.Request.Headers.Get("Authorization");
            if (!string.IsNullOrEmpty(authorization))
            {
                if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    token = authorization.Substring("Bearer ".Length).Trim();
                    context.Token = token;
                    return Task.FromResult(0);
                }
            }

            token = context.Request.Query["accesstoken"];
            if (!string.IsNullOrEmpty(token))
            {
                context.Token = token;
                return Task.FromResult(0);
            }

            token = context.Request.Cookies["accesstoken"];
            if(!string.IsNullOrEmpty(token))
            {
                context.Token = token;
                return Task.FromResult(0);
            }


            return Task.FromResult(0);
        }

        public Task ValidateIdentity(OAuthValidateIdentityContext context)
        {
            return Task.FromResult(0);
        }
    }
}