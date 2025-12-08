using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class PushPayLinkFromIdTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "channel": "sms"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": "2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234",
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PaymentLink/push/payLinkId")
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

        var response = await Client.PaymentLink.PushPayLinkFromIdAsync(
            "payLinkId",
            new PushPayLinkRequest(new PushPayLinkRequest.Sms(new PushPayLinkRequestSms()))
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponsePaymentLinks>(mockResponse))
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "additionalEmails": [
                "admin@example.com",
                "accounting@example.com"
              ],
              "attachFile": true,
              "channel": "email"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": "2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234",
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PaymentLink/push/payLinkId")
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

        var response = await Client.PaymentLink.PushPayLinkFromIdAsync(
            "payLinkId",
            new PushPayLinkRequest(
                new PushPayLinkRequest.Email(
                    new PushPayLinkRequestEmail
                    {
                        AdditionalEmails = new List<string>()
                        {
                            "admin@example.com",
                            "accounting@example.com",
                        },
                        AttachFile = true,
                    }
                )
            )
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponsePaymentLinks>(mockResponse))
                .UsingDefaults()
        );
    }
}
