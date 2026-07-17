using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyIn;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ReverseTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "responseCode": 1,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "authCode": "A0000",
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "REVERSED"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/reverse/10-3ffa27df-b171-44e0-b251-e95fbfc7a723/0")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyIn.ReverseAsync(
            "10-3ffa27df-b171-44e0-b251-e95fbfc7a723",
            0
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "responseCode": 1,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "authCode": "A0000",
                "referenceId": "129-219",
                "resultCode": 10,
                "resultText": "INITIATED"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/reverse/10-3ffa27df-b171-44e0-b251-e95fbfc7a723/53.76")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyIn.ReverseAsync(
            "10-3ffa27df-b171-44e0-b251-e95fbfc7a723",
            53.76
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
