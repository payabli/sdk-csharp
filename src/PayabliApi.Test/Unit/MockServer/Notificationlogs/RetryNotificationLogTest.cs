using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Notificationlogs;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RetryNotificationLogTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "message": "Notification retry succeeded."
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/notificationlogs/550e8400-e29b-41d4-a716-446655440000/retry")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Notificationlogs.RetryNotificationLogAsync(
            "550e8400-e29b-41d4-a716-446655440000"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
