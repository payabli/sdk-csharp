using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Applications;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateApplicationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
              "externalId": "APP-2025-0417",
              "tags": [
                "priority"
              ]
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Application created successfully",
              "traceId": "0HNNNPRPLVN40:00000012",
              "data": {
                "requestsReference": "3f3caa7b-bdfe-4bf1-814b-30d54859247c",
                "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "externalId": "APP-2025-0417",
                "paypointReference": "019ff064-c690-7679-a73e-688418aadc7c",
                "paypointStatus": "pending",
                "applicationStatus": "draft",
                "applicationStatusCode": 1,
                "allowedActions": [
                  "submit",
                  "withdraw",
                  "abandon"
                ],
                "tags": [
                  "priority"
                ],
                "createdAt": "2026-07-01T15:00:01.734346",
                "_links": {
                  "self": "/v2/requests/3f3caa7b-bdfe-4bf1-814b-30d54859247c",
                  "business": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/requests")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Applications.CreateApplicationAsync(
            new CreateApplicationRequest
            {
                BusinessReference = "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                ExternalId = "APP-2025-0417",
                Tags = new List<string>() { "priority" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
              "externalId": "APP-2025-0417",
              "requestTemplate": "019ff129-d393-7761-9a31-e5afe85b4081",
              "services": {
                "moneyIn": [
                  "Ach",
                  "Card"
                ],
                "moneyOut": [
                  "Ach",
                  "Check"
                ]
              }
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Application created successfully",
              "traceId": "0HNONVRI1TBCP:00000054",
              "data": {
                "requestsReference": "3f3caa7b-bdfe-4bf1-814b-30d54859247c",
                "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "externalId": "APP-2025-0417",
                "parent": "a8806f02-23b3-4f6d-bba3-42e1b94326ea",
                "parentOrgName": "PropertyManager Pro",
                "paypointReference": "019ff064-c690-7679-a73e-688418aadc7c",
                "paypointStatus": "pending",
                "applicationStatus": "draft",
                "applicationStatusCode": 1,
                "allowedActions": [
                  "submit",
                  "withdraw",
                  "abandon"
                ],
                "requestTemplate": "019ff129-d393-7761-9a31-e5afe85b4081",
                "services": {
                  "moneyIn": [
                    "Ach",
                    "Card"
                  ],
                  "moneyOut": [
                    "Ach",
                    "Check"
                  ]
                },
                "createdAt": "2026-07-01T15:00:01.734346Z",
                "_links": {
                  "self": "/v2/requests/3f3caa7b-bdfe-4bf1-814b-30d54859247c",
                  "business": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/requests")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Applications.CreateApplicationAsync(
            new CreateApplicationRequest
            {
                BusinessReference = "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                ExternalId = "APP-2025-0417",
                RequestTemplate = "019ff129-d393-7761-9a31-e5afe85b4081",
                Services = new RequestedServices
                {
                    MoneyIn = new List<MoneyInService>()
                    {
                        MoneyInService.Ach,
                        MoneyInService.Card,
                    },
                    MoneyOut = new List<MoneyOutService>()
                    {
                        MoneyOutService.Ach,
                        MoneyOutService.Check,
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
              "paypointReference": "019ff3a8-2c41-7b0e-9d52-6e1f0c84a7b3",
              "externalId": "APP-2026-1013",
              "requestTemplate": "019ff129-d393-7761-9a31-e5afe85b4081",
              "services": {
                "moneyIn": [
                  "Card"
                ]
              }
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Application created successfully",
              "traceId": "0HNP8M4GTH3JG:00000003",
              "data": {
                "requestsReference": "b7e2c915-4f0a-4d6b-a3c8-91e5d2f7c406",
                "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "externalId": "APP-2026-1013",
                "parent": "a8806f02-23b3-4f6d-bba3-42e1b94326ea",
                "parentOrgName": "PropertyManager Pro",
                "paypointReference": "019ff3a8-2c41-7b0e-9d52-6e1f0c84a7b3",
                "paypointStatus": "pending",
                "applicationStatus": "draft",
                "applicationStatusCode": 1,
                "allowedActions": [
                  "submit",
                  "withdraw",
                  "abandon"
                ],
                "requestTemplate": "019ff129-d393-7761-9a31-e5afe85b4081",
                "services": {
                  "moneyIn": [
                    "Card"
                  ]
                },
                "createdAt": "2026-10-13T14:42:31.0326419Z",
                "_links": {
                  "self": "/v2/requests/b7e2c915-4f0a-4d6b-a3c8-91e5d2f7c406",
                  "business": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/requests")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Applications.CreateApplicationAsync(
            new CreateApplicationRequest
            {
                BusinessReference = "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                PaypointReference = "019ff3a8-2c41-7b0e-9d52-6e1f0c84a7b3",
                ExternalId = "APP-2026-1013",
                RequestTemplate = "019ff129-d393-7761-9a31-e5afe85b4081",
                Services = new RequestedServices
                {
                    MoneyIn = new List<MoneyInService>() { MoneyInService.Card },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string requestJson = """
            {
              "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
              "paypointReference": "019ff064-c690-7679-a73e-688418aadc7c",
              "externalId": "APP-2025-0418",
              "requestTemplate": "019ff129-d393-7761-9a31-e5afe85b4081",
              "services": {
                "moneyOut": [
                  "Ach",
                  "Check"
                ]
              },
              "tags": [
                "add-services"
              ]
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Application created successfully",
              "traceId": "0HNONVRI1TBG9:00000029",
              "data": {
                "requestsReference": "4463979d-6336-4298-90cb-52d446030874",
                "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "externalId": "APP-2025-0418",
                "parent": "a8806f02-23b3-4f6d-bba3-42e1b94326ea",
                "parentOrgName": "PropertyManager Pro",
                "paypointReference": "019ff064-c690-7679-a73e-688418aadc7c",
                "paypointStatus": "active",
                "applicationStatus": "draft",
                "applicationStatusCode": 1,
                "allowedActions": [
                  "submit",
                  "withdraw",
                  "abandon"
                ],
                "tags": [
                  "add-services"
                ],
                "requestTemplate": "019ff129-d393-7761-9a31-e5afe85b4081",
                "services": {
                  "moneyOut": [
                    "Ach",
                    "Check"
                  ]
                },
                "createdAt": "2026-09-28T15:48:54.0628351Z",
                "_links": {
                  "self": "/v2/requests/4463979d-6336-4298-90cb-52d446030874",
                  "business": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/requests")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Applications.CreateApplicationAsync(
            new CreateApplicationRequest
            {
                BusinessReference = "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                PaypointReference = "019ff064-c690-7679-a73e-688418aadc7c",
                ExternalId = "APP-2025-0418",
                RequestTemplate = "019ff129-d393-7761-9a31-e5afe85b4081",
                Services = new RequestedServices
                {
                    MoneyOut = new List<MoneyOutService>()
                    {
                        MoneyOutService.Ach,
                        MoneyOutService.Check,
                    },
                },
                Tags = new List<string>() { "add-services" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
