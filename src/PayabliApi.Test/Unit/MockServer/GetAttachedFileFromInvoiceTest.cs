using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class GetAttachedFileFromInvoiceTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "fContent": "fContent",
              "filename": "filename",
              "ftype": "pdf",
              "furl": "furl"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Invoice/attachedFileFromInvoice/1/filename")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Invoice.GetAttachedFileFromInvoiceAsync(
            1,
            "filename",
            new GetAttachedFileFromInvoiceRequest()
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<FileContent>(mockResponse)).UsingDefaults()
        );
    }
}
