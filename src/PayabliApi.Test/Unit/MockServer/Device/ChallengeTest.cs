using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Device;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ChallengeTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "responseCode": 1,
              "pageIdentifier": "",
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "code": "748801",
                "expiresAt": "2026-08-13T19:58:27.586Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Device/challenge/8cfec329267")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Device.ChallengeAsync("8cfec329267");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
