using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.TokenStorage;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RemoveMethodTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": {
                "referenceId": "129-219",
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
        JsonAssert.AreEqual(response, mockResponse);
    }
}
