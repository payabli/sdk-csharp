using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyOut;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RenewVCardTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "expirationDate": "12-2027"
            }
            """;

        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "responseData": {
                "referenceId": "20231206142225227890",
                "resultCode": 1,
                "resultText": "Virtual card renewed"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyOutCard/vcard/20231206142225226104/renew")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyOut.RenewVCardAsync(
            "20231206142225226104",
            new RenewVCardRequest { ExpirationDate = "12-2027" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
