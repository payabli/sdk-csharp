using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyOut;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetCheckImageTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            "JVBERi0xLjcKJeLjz9MKMTIzIDAgb2JqCjwvTGluZWFyaXplZCAxL0wgMTIzNDU2L08gMTI1L0UgNzg5MDEvTiAxL1QgMTIzNDUwL0ggWyA4MDAgMjAwXT4+CmVuZG9iagouLi4="
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/MoneyOut/checkimage/check133832686289732320_01JKBNZ5P32JPTZY8XXXX000000.pdf"
                    )
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyOut.GetCheckImageAsync(
            "check133832686289732320_01JKBNZ5P32JPTZY8XXXX000000.pdf"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
