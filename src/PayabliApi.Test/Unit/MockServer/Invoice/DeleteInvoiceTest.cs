using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Invoice;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteInvoiceTest : BaseMockServerTest
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
              "roomId": 0
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Invoice/23548884")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Invoice.DeleteInvoiceAsync(23548884);
        JsonAssert.AreEqual(response, mockResponse);
    }
}
