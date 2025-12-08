using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class SendInvoiceTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Invoice/send/23548884")
                    .WithParam("mail2", "tamara@example.com")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Invoice.SendInvoiceAsync(
            23548884,
            new SendInvoiceRequest { Attachfile = true, Mail2 = "tamara@example.com" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SendInvoiceResponse>(mockResponse)).UsingDefaults()
        );
    }
}
