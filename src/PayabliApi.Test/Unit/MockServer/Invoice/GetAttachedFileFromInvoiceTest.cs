using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Invoice;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
        JsonAssert.AreEqual(response, mockResponse);
    }
}
