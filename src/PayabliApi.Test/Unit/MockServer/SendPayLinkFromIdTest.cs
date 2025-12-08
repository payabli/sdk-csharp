using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class SendPayLinkFromIdTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
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
                    .WithPath("/PaymentLink/send/payLinkId")
                    .WithParam("mail2", "jo@example.com; ceo@example.com")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PaymentLink.SendPayLinkFromIdAsync(
            "payLinkId",
            new SendPayLinkFromIdRequest { Mail2 = "jo@example.com; ceo@example.com" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponsePaymentLinks>(mockResponse))
                .UsingDefaults()
        );
    }
}
