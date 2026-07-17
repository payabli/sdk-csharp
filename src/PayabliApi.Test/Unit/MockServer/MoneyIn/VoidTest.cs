using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyIn;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class VoidTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "responseCode": 1,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "authCode": "123456",
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Transaction Void Successful"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/void/10-3ffa27df-b171-44e0-b251-e95fbfc7a723")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyIn.VoidAsync("10-3ffa27df-b171-44e0-b251-e95fbfc7a723");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
