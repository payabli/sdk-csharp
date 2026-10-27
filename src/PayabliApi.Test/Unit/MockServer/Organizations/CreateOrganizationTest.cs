using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Organizations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateOrganizationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "doingBusinessAs": "PropertyManager Pro",
              "description": "Property management software partner",
              "website": "https://example.com",
              "customerServicePhone": "3055551212",
              "customerServiceEmail": "support@example.com",
              "timezone": "America/New_York",
              "externalId": "pmp-org-001",
              "business": {
                "legalName": "PropertyManager Pro LLC",
                "legalStructure": "llc",
                "externalId": "pmp-biz-001"
              }
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Organization created successfully",
              "traceId": "0HNPE4LGV8483:000006C9",
              "data": {
                "paypointReference": "a8806f02-23b3-4f6d-bba3-42e1b94326ea",
                "businessReference": "6e2b9d14-7a3c-4f58-b1e6-0c9d3a5f8e27",
                "doingBusinessAs": "PropertyManager Pro",
                "paypointStatus": "pending",
                "timezone": "America/New_York",
                "createdAt": "2026-10-20T22:20:37.029Z",
                "_links": {
                  "self": "/v2/organizations/a8806f02-23b3-4f6d-bba3-42e1b94326ea",
                  "business": "/v2/businesses/6e2b9d14-7a3c-4f58-b1e6-0c9d3a5f8e27"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/organizations")
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

        var response = await Client.Organizations.CreateOrganizationAsync(
            new CreateOrganizationWithInlineBusiness
            {
                DoingBusinessAs = "PropertyManager Pro",
                Description = "Property management software partner",
                Website = "https://example.com",
                CustomerServicePhone = "3055551212",
                CustomerServiceEmail = "support@example.com",
                Timezone = "America/New_York",
                ExternalId = "pmp-org-001",
                Business = new CreateBusinessRequest
                {
                    LegalName = "PropertyManager Pro LLC",
                    LegalStructure = CreateBusinessRequestLegalStructure.Llc,
                    ExternalId = "pmp-biz-001",
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "businessReference": "6e2b9d14-7a3c-4f58-b1e6-0c9d3a5f8e27",
              "doingBusinessAs": "PropertyManager Pro",
              "description": "Property management software partner",
              "website": "https://example.com",
              "timezone": "America/New_York",
              "externalId": "pmp-org-001"
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Organization created successfully",
              "traceId": "0HNPE4LGV825F:00000015",
              "data": {
                "paypointReference": "a8806f02-23b3-4f6d-bba3-42e1b94326ea",
                "businessReference": "6e2b9d14-7a3c-4f58-b1e6-0c9d3a5f8e27",
                "doingBusinessAs": "PropertyManager Pro",
                "paypointStatus": "pending",
                "timezone": "America/New_York",
                "createdAt": "2026-10-20T22:20:37.029Z",
                "_links": {
                  "self": "/v2/organizations/a8806f02-23b3-4f6d-bba3-42e1b94326ea",
                  "business": "/v2/businesses/6e2b9d14-7a3c-4f58-b1e6-0c9d3a5f8e27"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/organizations")
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

        var response = await Client.Organizations.CreateOrganizationAsync(
            new CreateOrganizationWithBusinessReference
            {
                BusinessReference = "6e2b9d14-7a3c-4f58-b1e6-0c9d3a5f8e27",
                DoingBusinessAs = "PropertyManager Pro",
                Description = "Property management software partner",
                Website = "https://example.com",
                Timezone = "America/New_York",
                ExternalId = "pmp-org-001",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
