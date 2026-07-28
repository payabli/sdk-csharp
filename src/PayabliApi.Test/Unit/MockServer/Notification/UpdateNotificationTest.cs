using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Notification;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateNotificationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "content": {
                "eventType": "approvedpayment"
              },
              "frequency": "untilcancelled",
              "method": "email",
              "ownerId": 136,
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
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
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
                    EventType = NotificationStandardRequestContentEventType.Approvedpayment,
                },
                Frequency = NotificationStandardRequestFrequency.Untilcancelled,
                Method = NotificationStandardRequestMethod.Email,
                OwnerId = 136,
                OwnerType = 0,
                Status = 1,
                Target = "newemail@email.com",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "content": {
                "eventType": "approvedpayment",
                "webHeaderParameters": [
                  {
                    "key": "Authorization",
                    "value": "Basic dXNlcjpwYXNzd29yZA=="
                  }
                ]
              },
              "frequency": "untilcancelled",
              "method": "web",
              "ownerId": 136,
              "ownerType": 0,
              "status": 1,
              "target": "https://webhook.site/2871b8f8-edc7-441a-b376-98d8c8e33275"
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
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
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
                    EventType = NotificationStandardRequestContentEventType.Approvedpayment,
                    WebHeaderParameters = new List<KeyValueDuo>()
                    {
                        new KeyValueDuo
                        {
                            Key = "Authorization",
                            Value = "Basic dXNlcjpwYXNzd29yZA==",
                        },
                    },
                },
                Frequency = NotificationStandardRequestFrequency.Untilcancelled,
                Method = NotificationStandardRequestMethod.Web,
                OwnerId = 136,
                OwnerType = 0,
                Status = 1,
                Target = "https://webhook.site/2871b8f8-edc7-441a-b376-98d8c8e33275",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
