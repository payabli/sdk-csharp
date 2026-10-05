using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;

namespace PayabliApi.Test.Unit.MockServer.Notificationlogs;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class BulkRetryNotificationLogsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            [
              "string",
              "string"
            ]
            """;

        const string mockResponse = "string";

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/notificationlogs/retry")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Notificationlogs.BulkRetryNotificationLogsAsync(
            new List<string>() { "string", "string" }
        );
        Assert.That(response, Is.EqualTo(mockResponse));
    }
}
