using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class UpdateNotificationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "content": {
                "eventType": "ApprovedPayment"
              },
              "frequency": "untilcancelled",
              "method": "email",
              "ownerId": "136",
              "ownerType": 0,
              "status": 1,
              "target": "newemail@email.com"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseData": 1717,
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Notification/1717")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Notification.UpdateNotificationAsync(
            "1717",
            new NotificationStandardRequest
            {
                Content = new NotificationStandardRequestContent
                {
                    EventType = NotificationStandardRequestContentEventType.ApprovedPayment,
                },
                Frequency = NotificationStandardRequestFrequency.Untilcancelled,
                Method = NotificationStandardRequestMethod.Email,
                OwnerId = "136",
                OwnerType = 0,
                Status = 1,
                Target = "newemail@email.com",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponseNotifications>(mockResponse))
                .UsingDefaults()
        );
    }
}
