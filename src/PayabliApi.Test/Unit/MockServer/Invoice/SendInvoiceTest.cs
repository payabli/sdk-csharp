using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Invoice;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
        JsonAssert.AreEqual(response, mockResponse);
    }
}
