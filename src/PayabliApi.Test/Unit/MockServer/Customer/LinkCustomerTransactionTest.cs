using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Customer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class LinkCustomerTransactionTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "responseCode": 1,
              "pageIdentifier": "null",
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": " "
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Customer/link/4440/45-as456777hhhhhhhhhh77777777-324")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Customer.LinkCustomerTransactionAsync(
            4440,
            "45-as456777hhhhhhhhhh77777777-324"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
