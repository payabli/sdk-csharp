using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class AddNotificationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "content": {
                "eventType": "CreatedApplication"
              },
              "frequency": "untilcancelled",
              "method": "web",
              "ownerId": "236",
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
                    .WithPath("/Notification")
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

        var response = await Client.Notification.AddNotificationAsync(
            new NotificationStandardRequest
            {
                Content = new NotificationStandardRequestContent
                {
                    EventType = NotificationStandardRequestContentEventType.CreatedApplication,
                },
                Frequency = NotificationStandardRequestFrequency.Untilcancelled,
                Method = NotificationStandardRequestMethod.Web,
                OwnerId = "236",
                OwnerType = 0,
                Status = 1,
                Target = "https://webhook.site/2871b8f8-edc7-441a-b376-98d8c8e33275",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponseNotifications>(mockResponse))
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "content": {
                "eventType": "Report",
                "fileFormat": "json",
                "reportName": "Transaction",
                "timeZone": -5,
                "transactionId": "0"
              },
              "frequency": "biweekly",
              "method": "report-email",
              "ownerId": "236",
              "ownerType": 0,
              "status": 1,
              "target": "admin@example.com"
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
                    .WithPath("/Notification")
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

        var response = await Client.Notification.AddNotificationAsync(
            new NotificationReportRequest
            {
                Content = new NotificationReportRequestContent
                {
                    EventType = "Report",
                    FileFormat = NotificationReportRequestContentFileFormat.Json,
                    ReportName = NotificationReportRequestContentReportName.Transaction,
                    TimeZone = -5,
                    TransactionId = "0",
                },
                Frequency = NotificationReportRequestFrequency.Biweekly,
                Method = NotificationReportRequestMethod.ReportEmail,
                OwnerId = "236",
                OwnerType = 0,
                Status = 1,
                Target = "admin@example.com",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponseNotifications>(mockResponse))
                .UsingDefaults()
        );
    }
}
