// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Multishop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
           new ApiResource("ResourceCatalog"){ Scopes= {"CatalogFullPermission", "CatalogReadPermission"} },
           new ApiResource("ResourceDiscount"){ Scopes= {"DiscountFullPermission"} },
           new ApiResource("ResourceOrder"){ Scopes= {"OrderFullPermission"} },
           new ApiResource("ResourceCargo"){ Scopes= {"CargoFullPermission"} },
           new ApiResource("ResourceBasket"){ Scopes= {"BasketFullPermission"} },
           new ApiResource("ResourceComment"){ Scopes= { "CommentFullPermission" } },
           new ApiResource("ResourcePayment"){ Scopes= { "PaymentFullPermission" } },
           new ApiResource("ResourceImages"){ Scopes= { "ImagesFullPermission" } },
           new ApiResource("ResourceGateway"){ Scopes= {"GatewayFullPermission"} },
           new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
       };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full Authority For Catalog Operations"),
            new ApiScope("CatalogReadPermission","Read Authority For Catalog Operations"),
            new ApiScope("DiscountFullPermission","Full Authority For Discount Operations"),
            new ApiScope("OrderFullPermission","Full Authority For Order Operations"),
            new ApiScope("CargoFullPermission","Full Authority For Cargo Operations"),
            new ApiScope("BasketFullPermission","Full Authority For Basket Operations"),
            new ApiScope("CommentFullPermission","Full Authority For Comment Operations"),
            new ApiScope("PaymentFullPermission","Full Authority For Payment Operations"),
            new ApiScope("ImagesFullPermission","Full Authority For Image Operations"),
            new ApiScope("GatewayFullPermission","Full Authority For Gateway Operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)

        };


        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
               ClientId="MultishopVisitorId",
               ClientName="Multishop Visitor User",
               AllowedGrantTypes=GrantTypes.ClientCredentials,
               ClientSecrets= {new Secret("multishopsecret".Sha256())},
               AllowedScopes={ "CatalogFullPermission", "GatewayFullPermission", "CommentFullPermission", "ImagesFullPermission" }
            },


            //Manager
            new Client
            {
                ClientId="MultishopManagerId",
                ClientName="Multishop Manager User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
               ClientSecrets= {new Secret("multishopsecret".Sha256())},
               AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", "BasketFullPermission", "GatewayFullPermission", "CommentFullPermission", "PaymentFullPermission","DiscountFullPermission",  "ImagesFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
               IdentityServerConstants.StandardScopes.Email,
               IdentityServerConstants.StandardScopes.OpenId,
               IdentityServerConstants.StandardScopes.Profile}
            },

            //Admin
            new Client
            {
                 ClientId="MultishopAdminId",
                ClientName="Multishop Admin User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
               ClientSecrets= {new Secret("multishopsecret".Sha256())},
               AllowedScopes=
                { "CatalogFullPermission", "DiscountFullPermission","CargoFullPermission", "OrderFullPermission", "CommentFullPermission" , "PaymentFullPermission","ImagesFullPermission" ,"GatewayFullPermission" , "BasketFullPermission",
               IdentityServerConstants.LocalApi.ScopeName, 
               IdentityServerConstants.StandardScopes.Email,
               IdentityServerConstants.StandardScopes.OpenId,
               IdentityServerConstants.StandardScopes.Profile
                },
               AccessTokenLifetime=600


            }

        };
    }
}