using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;

namespace PayabliApi.Test.Unit.MockServer.Applications;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteApplicationDocumentTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v2/requests/3f3caa7b-bdfe-4bf1-814b-30d54859247c/documents/019ff1d7-6e14-7c8b-a2f5-91d3b7e04c62"
                    )
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Applications.DeleteApplicationDocumentAsync(
                "3f3caa7b-bdfe-4bf1-814b-30d54859247c",
                "019ff1d7-6e14-7c8b-a2f5-91d3b7e04c62"
            )
        );
    }
}
