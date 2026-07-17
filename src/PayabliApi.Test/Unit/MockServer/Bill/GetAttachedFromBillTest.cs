using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Bill;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetAttachedFromBillTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "fContent": "TXkgdGVzdCBmaWxlHJ==...",
              "filename": "my-doc.pdf",
              "ftype": "pdf",
              "furl": "https://mysite.com/my-doc.pdf"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Bill/attachedFileFromBill/285/0_Bill.pdf")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Bill.GetAttachedFromBillAsync(
            285,
            "0_Bill.pdf",
            new GetAttachedFromBillRequest { ReturnObject = true }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
