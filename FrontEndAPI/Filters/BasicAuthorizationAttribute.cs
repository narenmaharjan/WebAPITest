using Microsoft.AspNetCore.Authorization;

using System.Net;

namespace FrontEndApi.Filters
{
    public class BasicAuthorizationAttribute: AuthorizeAttribute
    {

        public BasicAuthorizationAttribute()
        {
            AuthenticationSchemes = BasicAuthenticationScheme.Basic;
        }
    }
}
