using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ListNotificationsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Records": [
                {
                  "content": {
                    "eventType": "ReceivedChargeBack",
                    "timeZone": 0
                  },
                  "createdAt": "2022-06-07T05:00:00.000Z",
                  "frequency": "untilcancelled",
                  "lastUpdated": "2022-06-07T05:00:00.000Z",
                  "method": "email",
                  "notificationId": 88976,
                  "ownerId": "123",
                  "ownerName": "Pilgrim Planner",
                  "ownerType": 2,
                  "source": "api",
                  "status": 1,
                  "target": "example@example.com"
                },
                {
                  "content": {
                    "eventType": "ReceivedAchReturn",
                    "timeZone": 0
                  },
                  "createdAt": "2022-06-07T05:00:00.000Z",
                  "frequency": "untilcancelled",
                  "lastUpdated": "2022-06-07T05:00:00.000Z",
                  "method": "email",
                  "notificationId": 88975,
                  "ownerId": "123",
                  "ownerName": "Pilgrim Planner",
                  "ownerType": 2,
                  "source": "api",
                  "status": 1,
                  "target": "example@example.com"
                }
              ],
              "Summary": {
                "pageSize": 20,
                "totalAmount": 0,
                "totalNetAmount": 0,
                "totalPages": 1,
                "totalRecords": 2
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Query/notifications/8cfec329267")
                    .WithParam("fromRecord", "251")
                    .WithParam("limitRecord", "0")
                    .WithParam("sortBy", "desc(field_name)")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Query.ListNotificationsAsync(
            "8cfec329267",
            new ListNotificationsRequest
            {
                FromRecord = 251,
                LimitRecord = 0,
                SortBy = "desc(field_name)",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<QueryResponseNotifications>(mockResponse))
                .UsingDefaults()
        );
    }
}
