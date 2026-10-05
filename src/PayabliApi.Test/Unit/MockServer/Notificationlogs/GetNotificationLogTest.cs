using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Notificationlogs;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetNotificationLogTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
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
              "responseContent": "{\"status\":\"received\",\"id\":\"wh_123\"}",
              "organizationName": "The Pilgrim Planner",
              "paypointName": "Pilgrim Planner",
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/notificationlogs/550e8400-e29b-41d4-a716-446655440000")
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

        var response = await Client.Notificationlogs.GetNotificationLogAsync(
            "550e8400-e29b-41d4-a716-446655440000"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
