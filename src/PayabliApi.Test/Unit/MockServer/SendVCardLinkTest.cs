using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
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
              "message": "Successfully sent email to: vendor@vendor.com",
              "success": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/vcard/send-card-link")
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
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<OperationResult>(mockResponse)).UsingDefaults()
        );
    }
}
