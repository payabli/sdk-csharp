using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Billing;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetProfileTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": 1,
              "versionId": 4229,
              "versionNumber": 31,
              "business": {
                "entityType": 1,
                "entityId": 123
              },
              "name": "Default PayIn Profile",
              "feeType": 1,
              "createdAt": "2026-01-01T00:00:00.000Z",
              "updatedAt": "2026-01-01T00:00:00.000Z",
              "parentId": "1:123",
              "billableEvents": [
                {
                  "id": 1,
                  "name": "payin-card-sale-all",
                  "vertical": 1,
                  "service": 1,
                  "serviceType": 0,
                  "eventType": 4,
                  "eventGroup": 5,
                  "eventSource": 0,
                  "regionType": 1,
                  "feeSchedules": [
                    {
                      "id": 13419,
                      "value": 0.3,
                      "rate": 2.9,
                      "passthrough": 0,
                      "payor": {
                        "entityType": 1,
                        "entityId": 123
                      },
                      "collector": {
                        "entityType": 1,
                        "entityId": 123
                      },
                      "effectiveDate": "2026-01-01T00:00:00.000Z",
                      "createdAt": "2026-01-01T00:00:00.000Z",
                      "updatedAt": "2026-01-01T00:00:00.000Z",
                      "createdBy": "395",
                      "collectionSchedule": 2,
                      "billDate": 1,
                      "feeType": 1
                    }
                  ]
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/billing/configuration/PayIn/Organization/123")
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

        var response = await Client.Billing.GetProfileAsync(
            GetProfileBillingRequestServiceGroup.PayIn,
            GetProfileBillingRequestEntityType.Organization,
            123
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
