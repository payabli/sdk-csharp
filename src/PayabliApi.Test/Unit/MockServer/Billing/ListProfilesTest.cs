using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Billing;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListProfilesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "summary": {
                "pageIdentifier": "E8955DBE2D534C80B9AF",
                "pageSize": 20,
                "totalPages": 1,
                "totalRecords": 2
              },
              "records": [
                {
                  "id": 695,
                  "versionId": 1322,
                  "versionNumber": 1,
                  "business": {
                    "entityType": "Organization",
                    "entityId": 123
                  },
                  "serviceVertical": "PayOut",
                  "name": "PayOut Default Configuration",
                  "feeType": "Flat",
                  "createdAt": "2026-01-01T00:00:00.000Z",
                  "updatedAt": "2026-01-01T00:00:00.000Z",
                  "entitiesAssigned": {
                    "organizations": 11,
                    "paypoints": 2,
                    "templates": 2,
                    "applications": 357
                  },
                  "parentId": "1:123",
                  "countOfEvents": 10
                },
                {
                  "id": 1,
                  "versionId": 4229,
                  "versionNumber": 31,
                  "business": {
                    "entityType": "Organization",
                    "entityId": 123
                  },
                  "serviceVertical": "PayIn",
                  "name": "Default PayIn Profile",
                  "feeType": "Flat",
                  "createdAt": "2026-01-01T00:00:00.000Z",
                  "updatedAt": "2026-01-01T00:00:00.000Z",
                  "entitiesAssigned": {
                    "organizations": 11,
                    "paypoints": 2,
                    "templates": 0,
                    "applications": 13
                  },
                  "parentId": "1:123",
                  "countOfEvents": 11
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/billing/configuration/org/123")
                    .WithParam("limitRecord", "20")
                    .WithParam("fromRecord", "0")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Billing.ListProfilesAsync(
            123,
            new ListBillingProfilesRequest { LimitRecord = 20, FromRecord = 0 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "summary": {
                "pageIdentifier": "A1B2C3D04E5F6A7B8C9D",
                "pageSize": 20,
                "totalPages": 1,
                "totalRecords": 1
              },
              "records": [
                {
                  "id": 1,
                  "versionId": 4229,
                  "versionNumber": 31,
                  "business": {
                    "entityType": "Organization",
                    "entityId": 123
                  },
                  "serviceVertical": "PayIn",
                  "name": "Default PayIn Profile",
                  "feeType": "Flat",
                  "createdAt": "2026-01-01T00:00:00.000Z",
                  "updatedAt": "2026-01-01T00:00:00.000Z",
                  "entitiesAssigned": {
                    "organizations": 11,
                    "paypoints": 2,
                    "templates": 0,
                    "applications": 13
                  },
                  "parentId": "1:123",
                  "countOfEvents": 11
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/billing/configuration/org/123")
                    .WithParam("limitRecord", "20")
                    .WithParam("fromRecord", "0")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Billing.ListProfilesAsync(
            123,
            new ListBillingProfilesRequest
            {
                ServiceVertical = new List<int>() { 1 },
                FeeType = new List<int>() { 1 },
                LimitRecord = 20,
                FromRecord = 0,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
