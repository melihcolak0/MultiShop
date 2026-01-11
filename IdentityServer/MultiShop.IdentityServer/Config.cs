// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission", "CatalogReadPermission"}},
            new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"}},
            new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"}},
            new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"}},
            new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"}},
            new ApiResource("ResourceComment"){Scopes={"CommentFullPermission"}},
            new ApiResource("ResourcePayment"){Scopes={"PaymentFullPermission"}},
            new ApiResource("ResourceImages"){Scopes={"ImagesFullPermission"}},
            new ApiResource("ResourceOcelot"){Scopes={"OcelotFullPermission"}},
            new ApiResource("ResourceMessage"){Scopes={"MessageFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full Authority for Catalog Operations"),
            new ApiScope("CatalogReadPermission", "Reading Authority for Catalog Operations"),
            new ApiScope("DiscountFullPermission", "Full Authority for Discount Operations"),
            new ApiScope("OrderFullPermission", "Full Authority for Order Operations"),
            new ApiScope("CargoFullPermission", "Full Authority for Cargo Operations"),
            new ApiScope("BasketFullPermission", "Full Authority for Basket Operations"),
            new ApiScope("CommentFullPermission", "Full Authority for Comment Operations"),
            new ApiScope("PaymentFullPermission", "Full Authority for Payment Operations"),
            new ApiScope("ImagesFullPermission", "Full Authority for Images Operations"),
            new ApiScope("OcelotFullPermission", "Full Authority for Ocelot Operations"),
            new ApiScope("MessageFullPermission", "Full Authority for Message Operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            // Visitor
            new Client
            {
                ClientId = "MultiShopVisitorId",
                ClientName = "MultiShop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = { "CatalogReadPermission", "OcelotFullPermission", "CommentFullPermission", "ImagesFullPermission" }
            },

            // Manager
            new Client
            {
                ClientId = "MultiShopManagerId",
                ClientName = "MultiShop Manager User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = { "CatalogReadPermission",
                    "CatalogFullPermission",
                    "BasketFullPermission",
                    "ImagesFullPermission",
                    "OcelotFullPermission",
                    "PaymentFullPermission",
                    "DiscountFullPermission",
                    "OrderFullPermission",
                    "MessageFullPermission",
                    "CargoFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile}
            },

            // Admin
            new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "MultiShop Admin User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = { "CatalogFullPermission",
                    "CatalogReadPermission",
                    "DiscountFullPermission",
                    "OrderFullPermission",
                    "CargoFullPermission",
                    "BasketFullPermission",
                    "CommentFullPermission",
                    "PaymentFullPermission",
                    "ImagesFullPermission",
                    "OcelotFullPermission",
                    "MessageFullPermission",

                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile },

                AccessTokenLifetime = 600                
            } 
        };
    }
}

//public static IEnumerable<IdentityResource> IdentityResources =>
//                   new IdentityResource[]
//                   {
//                new IdentityResources.OpenId(),
//                new IdentityResources.Profile(),
//                   };

//public static IEnumerable<ApiScope> ApiScopes =>
//    new ApiScope[]
//    {
//                new ApiScope("scope1"),
//                new ApiScope("scope2"),
//    };

//public static IEnumerable<Client> Clients =>
//    new Client[]
//    {
//                // m2m client credentials flow client
//                new Client
//                {
//                    ClientId = "m2m.client",
//                    ClientName = "Client Credentials Client",

//                    AllowedGrantTypes = GrantTypes.ClientCredentials,
//                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

//                    AllowedScopes = { "scope1" }
//                },

//                // interactive client using code flow + pkce
//                new Client
//                {
//                    ClientId = "interactive",
//                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

//                    AllowedGrantTypes = GrantTypes.Code,

//                    RedirectUris = { "https://localhost:44300/signin-oidc" },
//                    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
//                    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

//                    AllowOfflineAccess = true,
//                    AllowedScopes = { "openid", "profile", "scope2" }
//                },
//    };