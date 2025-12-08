using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class RemoveMethodTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": {
                "referenceId": "32-8877drt65345632-678",
                "resultCode": 1,
                "resultText": "Removed"
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/TokenStorage/32-8877drt00045632-678")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.TokenStorage.RemoveMethodAsync("32-8877drt00045632-678");
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponsePaymethodDelete>(mockResponse))
                .UsingDefaults()
        );
    }
}
