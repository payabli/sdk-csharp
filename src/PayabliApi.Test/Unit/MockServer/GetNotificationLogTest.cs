using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class GetNotificationLogTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
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
              "isInProgress": false,
              "webHeaders": [
                {
                  "key": "Content-Type",
                  "value": "application/json"
                },
                {
                  "key": "User-Agent",
                  "value": "PaymentSystem/1.0"
                }
              ],
              "responseHeaders": [
                {
                  "key": "Content-Type",
                  "value": [
                    "application/json"
                  ]
                },
                {
                  "key": "X-Request-ID",
                  "value": [
                    "req_abc123"
                  ]
                }
              ],
              "responseContent": "{\"status\":\"received\",\"id\":\"wh_123\"}"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/notificationlogs/550e8400-e29b-41d4-a716-446655440000")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Notificationlogs.GetNotificationLogAsync(
            "550e8400-e29b-41d4-a716-446655440000"
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<NotificationLogDetail>(mockResponse)).UsingDefaults()
        );
    }
}
