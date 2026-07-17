using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyIn;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CaptureTest : BaseMockServerTest
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
                "resultText": "SUCCESS"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/capture/10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13/0")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyIn.CaptureAsync(
            "10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13",
            0
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
