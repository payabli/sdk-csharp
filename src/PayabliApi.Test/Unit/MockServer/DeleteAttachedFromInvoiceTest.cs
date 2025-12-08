using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class DeleteAttachedFromInvoiceTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseData": 3625,
              "responseText": "Success",
              "pageidentifier": null,
              "roomId": 0
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Invoice/attachedFileFromInvoice/23548884/0_Bill.pdf")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Invoice.DeleteAttachedFromInvoiceAsync("0_Bill.pdf", 23548884);
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<InvoiceResponseWithoutData>(mockResponse))
                .UsingDefaults()
        );
    }
}
