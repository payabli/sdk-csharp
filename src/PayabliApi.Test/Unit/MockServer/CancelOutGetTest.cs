using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class CancelOutGetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseText": "Success",
              "pageIdentifier": null,
              "responseData": {
                "ReferenceId": "129-219",
                "ResultCode": 1,
                "ResultText": "Approved",
                "CustomerId": 0,
                "AuthCode": null,
                "cvvResponseText": null,
                "avsResponseText": null,
                "methodReferenceId": null
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyOut/cancel/129-219")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyOut.CancelOutGetAsync("129-219");
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponse0000>(mockResponse)).UsingDefaults()
        );
    }
}
