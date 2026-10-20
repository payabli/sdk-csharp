using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Paypoints;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreatePaypointTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
              "paypointType": "merchant",
              "doingBusinessAs": "Rose Gardens",
              "description": "Boutique flower shop",
              "website": "https://example.com",
              "customerServiceEmail": "support@example.com",
              "customerServicePhone": "3055551212",
              "timezone": "America/New_York"
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Paypoint created successfully",
              "traceId": "0HNNN6HH5NDB3:00000001",
              "data": {
                "paypointReference": "019ff064-c690-7679-a73e-688418aadc7c",
                "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "doingBusinessAs": "Rose Gardens",
                "paypointStatus": "pending",
                "timezone": "America/New_York",
                "createdAt": "2026-08-11T10:36:04.115Z",
                "_links": {
                  "self": "/v2/paypoints/019ff064-c690-7679-a73e-688418aadc7c",
                  "business": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/paypoints")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Paypoints.CreatePaypointAsync(
            new CreatePaypointWithBusinessReference
            {
                BusinessReference = "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                PaypointType = "merchant",
                DoingBusinessAs = "Rose Gardens",
                Description = "Boutique flower shop",
                Website = "https://example.com",
                CustomerServiceEmail = "support@example.com",
                CustomerServicePhone = "3055551212",
                Timezone = "America/New_York",
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
              "paypointType": "merchant",
              "doingBusinessAs": "Rose Gardens Downtown",
              "timezone": "America/New_York"
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Paypoint created successfully",
              "traceId": "0HNP8M3LB1GJU:0000008B",
              "data": {
                "paypointReference": "019ff3a8-2c41-7b0e-9d52-6e1f0c84a7b3",
                "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "doingBusinessAs": "Rose Gardens Downtown",
                "paypointStatus": "pending",
                "timezone": "America/New_York",
                "createdAt": "2026-10-13T14:38:25.992Z",
                "_links": {
                  "self": "/v2/paypoints/019ff3a8-2c41-7b0e-9d52-6e1f0c84a7b3",
                  "business": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/paypoints")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Paypoints.CreatePaypointAsync(
            new CreatePaypointWithBusinessReference
            {
                BusinessReference = "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                PaypointType = "merchant",
                DoingBusinessAs = "Rose Gardens Downtown",
                Timezone = "America/New_York",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "paypointType": "merchant",
              "doingBusinessAs": "Rose Gardens",
              "description": "Boutique flower shop",
              "website": "https://example.com",
              "customerServiceEmail": "support@example.com",
              "customerServicePhone": "3055551212",
              "timezone": "America/New_York",
              "business": {
                "legalName": "Rose Gardens LLC",
                "legalStructure": "llc",
                "externalId": "rg-001",
                "website": "https://example.com",
                "phone": [
                  "3055551212"
                ],
                "emails": [
                  "ops@example.com"
                ],
                "merchantCatCode": "5814",
                "taxReference": "477498993",
                "parentReference": "8cfec329267"
              }
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Paypoint created successfully",
              "traceId": "0HNNN6HH5NDOA:00000001",
              "data": {
                "paypointReference": "019ff064-c690-7679-a73e-688418aadc7c",
                "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "doingBusinessAs": "Rose Gardens",
                "paypointStatus": "pending",
                "timezone": "America/New_York",
                "createdAt": "2026-08-11T13:09:48.904Z",
                "_links": {
                  "self": "/v2/paypoints/019ff064-c690-7679-a73e-688418aadc7c",
                  "business": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/paypoints")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Paypoints.CreatePaypointAsync(
            new CreatePaypointWithInlineBusiness
            {
                PaypointType = "merchant",
                DoingBusinessAs = "Rose Gardens",
                Description = "Boutique flower shop",
                Website = "https://example.com",
                CustomerServiceEmail = "support@example.com",
                CustomerServicePhone = "3055551212",
                Timezone = "America/New_York",
                Business = new CreateBusinessRequest
                {
                    LegalName = "Rose Gardens LLC",
                    LegalStructure = CreateBusinessRequestLegalStructure.Llc,
                    ExternalId = "rg-001",
                    Website = "https://example.com",
                    Phone = new List<string>() { "3055551212" },
                    Emails = new List<string>() { "ops@example.com" },
                    MerchantCatCode = "5814",
                    TaxReference = "477498993",
                    ParentReference = "8cfec329267",
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
