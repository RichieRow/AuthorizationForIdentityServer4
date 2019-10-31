﻿using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace IdentityServer
{
    public class InitMemoryData
    {
        // scopes define the API resources in your system
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("inventoryapi", "this is inventory api"),
                new ApiResource("orderapi", "this is order api"),
                new ApiResource("productapi", "this is product api"),
                new ApiResource("api", "this is api")
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    //客户端id自定义
                    ClientId = "lzy",

                    AllowedGrantTypes = GrantTypes.ClientCredentials, ////设置模式，客户端模式

                    // 加密验证
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    // client可以访问的范围，在GetScopes方法定义的名字。
                    AllowedScopes = new List<string>
                    {
                        "api"
                    }
                },
                new Client
                {
                    ClientId = "inventory",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("inventorysecret".Sha256())
                    },

                    AllowedScopes = { "inventoryapi" }
                },
                 new Client
                {
                    ClientId = "order",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("ordersecret".Sha256())
                    },

                    AllowedScopes = { "orderapi" }
                },
                 new Client
                {
                    ClientId = "product",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("productsecret".Sha256())
                    },

                    AllowedScopes = { "productapi" }
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password"
                }
            };
        }
    }
}
