// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer
{
    public static class Config
    {
        public static List<TestUser> TestUsers =>
           new List<TestUser>
           {
                new TestUser
                {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "abassi",
                    Password = "0000",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName, "omar"),
                        new Claim(JwtClaimTypes.FamilyName, "abassi")
                    }
                }
           };
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {

                new ApiScope("productApi"),
            };
        public static IEnumerable<ApiResource> ApiResources =>
          new ApiResource[]
          {
               new ApiResource("productApi", "Product Api")
          };
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                //new Client
                //{
                //    ClientId = "m2m.client",
                //    ClientName = "Client Credentials Client",

                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                //    AllowedScopes = { "scope1" }
                //},

                // interactive client using code flow + pkce
                 new Client
                {
                    ClientId = "spaclientApp",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },
                    RedirectUris = {
                          "http://192.168.55.8:5104/signun-oidc",
                         "http://localhost:60191/signin-oidc",
                        },
                    AllowedGrantTypes = GrantTypes.Code,
                    
                    //FrontChannelLogoutUri = "http://localhost:60191/signout-oidc",
                    PostLogoutRedirectUris = { "http://localhost:60191/signout-callback-oidc",
                         "http://192.168.55.8:60191/signout-callback-oidc" },
                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "productApi","role"}
                }
            };
    }
}