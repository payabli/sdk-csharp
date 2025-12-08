using NUnit.Framework;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class BulkRetryNotificationLogsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        const string requestJson = """
            [
              "550e8400-e29b-41d4-a716-446655440000",
              "550e8400-e29b-41d4-a716-446655440001",
              "550e8400-e29b-41d4-a716-446655440002"
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/notificationlogs/retry")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Notificationlogs.BulkRetryNotificationLogsAsync(
                new List<string>()
                {
                    "550e8400-e29b-41d4-a716-446655440000",
                    "550e8400-e29b-41d4-a716-446655440001",
                    "550e8400-e29b-41d4-a716-446655440002",
                }
            )
        );
    }
}
