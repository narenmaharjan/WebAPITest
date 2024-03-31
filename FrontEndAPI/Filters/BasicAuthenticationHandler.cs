using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;


namespace FrontEndApi.Filters
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }



        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue("Authorization", out Microsoft.Extensions.Primitives.StringValues value))
            {
                return Task.FromResult(AuthenticateResult.Fail("Missing Authorization Key"));
            }

            var authorizationHeader = value.ToString();

            if (!authorizationHeader.StartsWith("Basic", StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(AuthenticateResult.Fail("No Basic Authorization"));
            }

            var authBaseDecode = Encoding.UTF8.GetString(
                Convert.FromBase64String(authorizationHeader.Replace("Basic", "", StringComparison.OrdinalIgnoreCase)));
            var authSplit = authBaseDecode.Split(new[] { ':' }, 2);

            if (authSplit.Length != 2)
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization header format"));
            }

            var userName = authSplit[0];
            var userPassword = authSplit[1];

            // The credential check is hardcoded for simplicity.
            // In real applications, the User credential is checked against the LDAP authentication server, credentials stored in the database, or some other methods.  
            if (userName != "narendra" && userPassword != "password") 
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid credential!"));
            }

            var client = new BasicAuthenticationClient
            {
                AuthenticationType = BasicAuthenticationScheme.Basic,
                IsAuthenticated = true,
                Name = userName
            };


            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(client, new[]
            {
                new Claim(ClaimTypes.Name,userName)
            }));

            return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
        }



    }

}
