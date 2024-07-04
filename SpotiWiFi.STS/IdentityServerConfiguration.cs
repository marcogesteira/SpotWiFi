using IdentityServer4;
using IdentityServer4.Models;

namespace SpotiWiFi.STS
{
    public class IdentityServerConfiguration
    {
        public static IEnumerable<IdentityResource> GetIdentityResource()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResource()
        {
            return new List<ApiResource>()
            {
                new ApiResource("SpotiWiFi-api", "SpotiWiFi-api", new string[] {"spotiwifi-user"})
                {
                    ApiSecrets =
                    {
                        new Secret("SpotiWiFiSecret".Sha256())
                    },
                    Scopes =
                    {
                        "SpotiWiFiScope"
                    }
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>()
            {
                new ApiScope()
                {
                    Name = "SpotiWiFiScope",
                    DisplayName = "SpotiWiFi API",
                    UserClaims = {"spotiwifi-user"}
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "client-angular-spotiWiFi",
                    ClientName = "Acesso do Front as APIs",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("SpotiWiFiSecret".Sha256())
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "SpotiWiFiScope"
                    }
                }
            };
        }
    }
}
