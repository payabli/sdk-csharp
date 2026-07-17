using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyIn;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ReverseCreditTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": {
                "authCode": null,
                "avsResponseText": null,
                "customerId": 4440,
                "cvvResponseText": null,
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "transaction processed."
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/reverseCredit/45-as456777hhhhhhhhhh77777777-324")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyIn.ReverseCreditAsync("45-as456777hhhhhhhhhh77777777-324");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
