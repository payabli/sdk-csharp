using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;

namespace PayabliApi.Test.Unit.MockServer.BoardingTemplates;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ArchiveTemplateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/templates/019ff129-d393-7761-9a31-e5afe85b4081")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.BoardingTemplates.ArchiveTemplateAsync(
                "019ff129-d393-7761-9a31-e5afe85b4081"
            )
        );
    }
}
