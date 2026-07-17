using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Customer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteCustomerTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "responseCode": 1,
              "isSuccess": true,
              "pageIdentifier": "null",
              "roomId": 0,
              "responseData": " ",
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/Customer/4440").UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Customer.DeleteCustomerAsync(4440);
        JsonAssert.AreEqual(response, mockResponse);
    }
}
