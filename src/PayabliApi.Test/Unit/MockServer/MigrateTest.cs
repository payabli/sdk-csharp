using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class MigrateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "entryPoint": "473abc123def",
              "newParentOrganizationId": 123,
              "notificationRequest": {
                "notificationUrl": "https://webhook-test.yoursie.com",
                "webHeaderParameters": [
                  {
                    "key": "testheader",
                    "value": "1234567890"
                  }
                ]
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Paypoint/migrate")
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

        var response = await Client.Paypoint.MigrateAsync(
            new PaypointMoveRequest
            {
                EntryPoint = "473abc123def",
                NewParentOrganizationId = 123,
                NotificationRequest = new NotificationRequest
                {
                    NotificationUrl = "https://webhook-test.yoursie.com",
                    WebHeaderParameters = new List<WebHeaderParameter>()
                    {
                        new WebHeaderParameter { Key = "testheader", Value = "1234567890" },
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<MigratePaypointResponse>(mockResponse)).UsingDefaults()
        );
    }
}
