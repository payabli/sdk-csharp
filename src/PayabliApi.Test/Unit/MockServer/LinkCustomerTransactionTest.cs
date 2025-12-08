using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
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
                    .WithPath("/Customer/link/998/45-as456777hhhhhhhhhh77777777-324")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Customer.LinkCustomerTransactionAsync(
            998,
            "45-as456777hhhhhhhhhh77777777-324"
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<PayabliApiResponse00Responsedatanonobject>(mockResponse)
                )
                .UsingDefaults()
        );
    }
}
