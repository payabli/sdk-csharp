using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Applications;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateApplicationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "externalId": "APP-2025-0417-REV2",
              "tags": [
                "priority",
                "expedited"
              ]
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Application updated successfully",
              "traceId": "0HNNNPRPLVN3H:00000011",
              "data": {
                "requestsReference": "3f3caa7b-bdfe-4bf1-814b-30d54859247c",
                "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "externalId": "APP-2025-0417-REV2",
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
                  "priority",
                  "expedited"
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
                    .WithPath("/v2/requests/3f3caa7b-bdfe-4bf1-814b-30d54859247c")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Applications.UpdateApplicationAsync(
            "3f3caa7b-bdfe-4bf1-814b-30d54859247c",
            new UpdateApplicationRequest
            {
                ExternalId = "APP-2025-0417-REV2",
                Tags = new List<string>() { "priority", "expedited" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "services": {
                "moneyIn": [
                  "Ach"
                ],
                "moneyOut": [
                  "Rtp"
                ]
              }
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Application updated successfully",
              "traceId": "0HNONVRI1TBCM:00000072",
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
                "services": {
                  "moneyIn": [
                    "Ach"
                  ],
                  "moneyOut": [
                    "Rtp"
                  ]
                },
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
                    .WithPath("/v2/requests/3f3caa7b-bdfe-4bf1-814b-30d54859247c")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Applications.UpdateApplicationAsync(
            "3f3caa7b-bdfe-4bf1-814b-30d54859247c",
            new UpdateApplicationRequest
            {
                Services = new RequestedServices
                {
                    MoneyIn = new List<MoneyInService>() { MoneyInService.Ach },
                    MoneyOut = new List<MoneyOutService>() { MoneyOutService.Rtp },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
