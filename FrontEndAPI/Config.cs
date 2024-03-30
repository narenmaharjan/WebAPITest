using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace FrontEndApi
{
    public static class Config
    {
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
            new Client
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "api1" }
            }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
            new ApiScope("api1", "My API")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
            new ApiResource("api1", "My API")
            };

        public static List<TestUser> Users => new()
        {
            new TestUser
            {
                SubjectId = "1",
                Username = "narendra",
                Password = "password",
                Claims = new List<Claim>
                {
                    new Claim("name", "narendra"),
                }
            }
        };

    }

}
