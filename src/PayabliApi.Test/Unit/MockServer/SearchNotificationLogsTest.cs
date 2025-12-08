using System.Globalization;
using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class SearchNotificationLogsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "startDate": "2024-01-01T00:00:00.000Z",
              "endDate": "2024-01-31T23:59:59.000Z",
              "orgId": 12345,
              "notificationEvent": "ActivatedMerchant",
              "succeeded": true
            }
            """;

        const string mockResponse = """
            [
              {
                "id": "550e8400-e29b-41d4-a716-446655440000",
                "orgId": 12345,
                "paypointId": 67890,
                "notificationEvent": "ActivatedMerchant",
                "target": "https://webhook.example.com/payments",
                "responseStatus": "200",
                "success": true,
                "jobData": "{\"transactionId\":\"txn_123\"}",
                "createdDate": "2024-01-15T10:30:00.000Z",
                "successDate": "2024-01-15T10:30:05.000Z",
                "lastFailedDate": null,
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
                Body = new NotificationLogSearchRequest
                {
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
                    OrgId = 12345,
                    NotificationEvent = "ActivatedMerchant",
                    Succeeded = true,
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<IEnumerable<NotificationLog>>(mockResponse))
                .UsingDefaults()
        );
    }
}
