using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyOut;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SendVCardLinkTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "transId": "01K33Z6YQZ6GD5QVKZ856MJBSC"
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Email sent.",
              "link": "https://app.payabli.com/vendor/virtual-card-link/code"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyOut/vcard/send-card-link")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
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

        var response = await Client.MoneyOut.SendVCardLinkAsync(
            new SendVCardLinkRequest { TransId = "01K33Z6YQZ6GD5QVKZ856MJBSC" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
