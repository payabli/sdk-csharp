using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
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
                "referenceId": "148-7e1528b9b7ab56d0bf3b837237b84479",
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
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponse>(mockResponse)).UsingDefaults()
        );
    }
}
