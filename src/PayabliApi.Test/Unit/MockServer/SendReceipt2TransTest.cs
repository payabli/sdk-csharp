using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class SendReceipt2TransTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "pageIdentifier": "null",
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/sendreceipt/45-as456777hhhhhhhhhh77777777-324")
                    .WithParam("email", "example@email.com")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyIn.SendReceipt2TransAsync(
            "45-as456777hhhhhhhhhh77777777-324",
            new SendReceipt2TransRequest { Email = "example@email.com" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<ReceiptResponse>(mockResponse)).UsingDefaults()
        );
    }
}
