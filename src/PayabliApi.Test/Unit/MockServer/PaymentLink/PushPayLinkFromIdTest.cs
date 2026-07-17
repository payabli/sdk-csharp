using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.PaymentLink;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
                    .WithPath("/PaymentLink/push/2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234")
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
            "2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234",
            new PushPayLinkRequest(new PushPayLinkRequest.Sms(new PushPayLinkRequestSms()))
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "channel": "email",
              "additionalEmails": [
                "admin@example.com",
                "accounting@example.com"
              ],
              "attachFile": true
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
                    .WithPath("/PaymentLink/push/2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234")
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
            "2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234",
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
        JsonAssert.AreEqual(response, mockResponse);
    }
}
