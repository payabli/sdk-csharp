using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.CaseManagement;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListMessagesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "messages": []
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/cases/9c2b7e14-3a5f-4d21-b8e0-1f6a4c9d2e70/messages")
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

        var response = await Client.CaseManagement.ListMessagesAsync(
            "9c2b7e14-3a5f-4d21-b8e0-1f6a4c9d2e70",
            new ListMessagesCaseManagementRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
