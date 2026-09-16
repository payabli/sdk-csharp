using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Taptopay;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ActivationChallengeTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "entry": "8cfec329267",
              "deviceId": "499585-389fj484-3jcj8hj3"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "code": "748801",
                "expiresAt": "2026-09-10T20:28:27.586Z",
                "alreadyIssued": false
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/device/taptopay/activate/challenge")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Taptopay.ActivationChallengeAsync(
            new TapToPayActivationChallengeRequest
            {
                Entry = "8cfec329267",
                DeviceId = "499585-389fj484-3jcj8hj3",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
