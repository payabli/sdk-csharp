using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.CaseManagement;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PostMessageTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "content": "Reviewed supporting documents; account ownership confirmed."
            }
            """;

        const string mockResponse = """
            {
              "messageId": 4821,
              "roomId": 96369,
              "createdAt": "2026-01-15T11:05:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/cases/9c2b7e14-3a5f-4d21-b8e0-1f6a4c9d2e70/messages")
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

        var response = await Client.CaseManagement.PostMessageAsync(
            "9c2b7e14-3a5f-4d21-b8e0-1f6a4c9d2e70",
            new PostCaseMessageRequest
            {
                Content = "Reviewed supporting documents; account ownership confirmed.",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
