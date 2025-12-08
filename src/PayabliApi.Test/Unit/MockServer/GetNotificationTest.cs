using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class GetNotificationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "content": {
                "fileFormat": "csv",
                "reportName": "Returned"
              },
              "createdAt": "2024-02-21T09:16:31.000Z",
              "frequency": "weekly",
              "lastUpdated": "2024-02-21T09:16:31.000Z",
              "method": "report-email",
              "notificationId": 1717,
              "ownerId": "123",
              "ownerName": "The Pilgrim Planner",
              "ownerType": 0,
              "status": 1,
              "target": "admin@business.com"
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/Notification/1717").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Notification.GetNotificationAsync("1717");
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<NotificationQueryRecord>(mockResponse)).UsingDefaults()
        );
    }
}
