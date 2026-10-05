using global::System.Globalization;
using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Notificationlogs;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SearchNotificationLogsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "startDate": "2024-01-01T00:00:00.000Z",
              "endDate": "2024-01-31T23:59:59.000Z",
              "orgId": 123,
              "notificationEvent": "approvedpayment",
              "succeeded": true
            }
            """;

        const string mockResponse = """
            [
              {
                "organizationName": "The Pilgrim Planner",
                "organizationLogo": "https://example.com/org-logo.png",
                "organizationFavIcon": "https://example.com/org-favicon.png",
                "paypointName": "Pilgrim Planner",
                "paypointLogo": "https://example.com/paypoint-logo.png",
                "notificationType": 1,
                "requestId": "f47ac10b-58cc-4372-a567-0e02b2c3d479",
                "id": "550e8400-e29b-41d4-a716-446655440000",
                "orgId": 123,
                "paypointId": 3040,
                "notificationEvent": "approvedpayment",
                "target": "https://webhook.example.com/payments",
                "responseStatusCode": 200,
                "responseStatus": "OK",
                "success": true,
                "jobData": "{\"transactionId\":\"txn_123\"}",
                "createdDate": "2024-01-15T10:30:00.000Z",
                "successDate": "2024-01-15T10:30:05.000Z",
                "isInProgress": false
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/notificationlogs")
                    .WithParam("PageSize", "20")
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

        var response = await Client.Notificationlogs.SearchNotificationLogsAsync(
            new SearchNotificationLogsRequest
            {
                PageSize = 20,
                StartDate = DateTime.Parse(
                    "2024-01-01T00:00:00.000Z",
                    null,
                    DateTimeStyles.AdjustToUniversal
                ),
                EndDate = DateTime.Parse(
                    "2024-01-31T23:59:59.000Z",
                    null,
                    DateTimeStyles.AdjustToUniversal
                ),
                OrgId = 123,
                NotificationEvent = "approvedpayment",
                Succeeded = true,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
