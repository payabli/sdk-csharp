using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ListPaymentMethodDomainsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "records": [
                {
                  "id": "pmd_7b4b3ca0f6b74f02853dfcee5ec090a3",
                  "type": "PaymentMethodDomains",
                  "entityId": 1147,
                  "entityType": "paypoint",
                  "domainName": "payment.example.com",
                  "applePay": {
                    "isEnabled": true
                  },
                  "googlePay": {
                    "isEnabled": true
                  },
                  "ownerEntityId": 1147,
                  "ownerEntityType": "paypoint",
                  "createdAt": "2025-02-13T18:31:07.023Z",
                  "updatedAt": "2025-03-18T13:48:39.056Z"
                },
                {
                  "id": "pmd_1f799c8ab7dd432dbc2052ce332c101c",
                  "type": "PaymentMethodDomains",
                  "entityId": 1147,
                  "entityType": "paypoint",
                  "domainName": "checkout.example.com",
                  "applePay": {
                    "isEnabled": true
                  },
                  "googlePay": {
                    "isEnabled": true
                  },
                  "ownerEntityId": 1147,
                  "ownerEntityType": "paypoint",
                  "createdAt": "2025-02-13T18:04:50.207Z",
                  "updatedAt": "2025-02-13T18:04:50.207Z"
                },
                {
                  "id": "pmd_135ac1be6fab4a97850aadbbba77ce1b",
                  "type": "PaymentMethodDomains",
                  "entityId": 1147,
                  "entityType": "paypoint",
                  "domainName": "pay.example.com",
                  "applePay": {
                    "isEnabled": true
                  },
                  "googlePay": {
                    "isEnabled": false
                  },
                  "ownerEntityId": 1147,
                  "ownerEntityType": "paypoint",
                  "createdAt": "2026-09-06T03:55:32.213Z",
                  "updatedAt": "2026-09-06T03:55:47.586Z"
                }
              ],
              "summary": {
                "pageIdentifier": "t.wlbQ4YZ3/JJkaP2/muAxibhlwdVz1Ve89QtI40H9KPhf...",
                "pageSize": 20,
                "totalPages": 1,
                "totalRecords": 17
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PaymentMethodDomain/list")
                    .WithParam("entityId", "1147")
                    .WithParam("entityType", "paypoint")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PaymentMethodDomain.ListPaymentMethodDomainsAsync(
            new ListPaymentMethodDomainsRequest { EntityId = 1147, EntityType = "paypoint" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<ListPaymentMethodDomainsResponse>(mockResponse))
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "records": [
                {
                  "id": "pmd_1bed085c821e432fa71ae0817c571dd6",
                  "type": "PaymentMethodDomains",
                  "entityId": 39,
                  "entityType": "organization",
                  "domainName": "checkout.example.com",
                  "applePay": {
                    "isEnabled": true
                  },
                  "googlePay": {
                    "isEnabled": false
                  },
                  "ownerEntityId": 39,
                  "ownerEntityType": "organization",
                  "createdAt": "2026-09-27T01:20:17.486Z",
                  "updatedAt": "2025-03-26T23:55:36.876Z"
                },
                {
                  "id": "pmd_dab1e3d2a3774216920bdc2afd62c307",
                  "type": "PaymentMethodDomains",
                  "entityId": 39,
                  "entityType": "organization",
                  "domainName": "checkout.example.com",
                  "applePay": {
                    "isEnabled": true
                  },
                  "googlePay": {
                    "isEnabled": false
                  },
                  "ownerEntityId": 39,
                  "ownerEntityType": "organization",
                  "createdAt": "2026-08-23T03:42:06.673Z",
                  "updatedAt": "2025-03-26T23:56:15.708Z"
                }
              ],
              "summary": {
                "pageIdentifier": "pageIdentifier",
                "pageSize": 20,
                "totalPages": 1,
                "totalRecords": 2
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PaymentMethodDomain/list")
                    .WithParam("entityId", "39")
                    .WithParam("entityType", "organization")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PaymentMethodDomain.ListPaymentMethodDomainsAsync(
            new ListPaymentMethodDomainsRequest { EntityId = 39, EntityType = "organization" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<ListPaymentMethodDomainsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
