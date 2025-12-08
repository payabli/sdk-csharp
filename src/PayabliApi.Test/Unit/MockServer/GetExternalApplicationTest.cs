using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class GetExternalApplicationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseData": {
                "appLink": "https://boarding-sandbox.payabli.com/boarding/externalapp/load/17E",
                "referenceId": "n6UCd1f1ygG7"
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Boarding/applink/352/mail2")
                    .UsingPut()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Boarding.GetExternalApplicationAsync(
            352,
            "mail2",
            new GetExternalApplicationRequest()
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponse00>(mockResponse)).UsingDefaults()
        );
    }
}
