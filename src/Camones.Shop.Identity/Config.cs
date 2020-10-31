using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Camones.Shop.Identity
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiScope> GetApisScopes =>
            new List<ApiScope>
            {
                new ApiScope("camonesshop", "API de servicios Camones Shop")
            };

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("camonesshop", "API de servicios Camones Shop")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "camonesweb",
                    ClientName="Postman",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowOfflineAccess = true,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "camonesshop"
                    },
                    RequireConsent = false,
                    AllowedCorsOrigins= new List<string>(new string[]{
                        "http://localhost:7001",
                    }),
                    UpdateAccessTokenClaimsOnRefresh = true,
                    RefreshTokenUsage = TokenUsage.ReUse
                },
                new Client {
                    ClientId = "camoneswebjs",

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris = { "http://localhost:7002/home/signin" },
                    PostLogoutRedirectUris = { "http://localhost:7002/Home/Index" },
                    AllowedCorsOrigins = { "http://localhost:7002" },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "camonesshop"
                    },

                    AccessTokenLifetime = 1,

                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                },
            };
        }
    }
}