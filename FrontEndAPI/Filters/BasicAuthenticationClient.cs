using System.Security.Principal;

namespace FrontEndApi.Filters
{
    public class BasicAuthenticationClient : IIdentity
    {

        public string AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }

        public string Name { get; set; }
    }
}
