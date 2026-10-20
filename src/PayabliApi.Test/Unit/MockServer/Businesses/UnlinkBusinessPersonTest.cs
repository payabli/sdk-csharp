using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;

namespace PayabliApi.Test.Unit.MockServer.Businesses;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UnlinkBusinessPersonTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55/people/01a0014d-ce1a-7110-9bac-c4c59647a88d"
                    )
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Businesses.UnlinkBusinessPersonAsync(
                "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "01a0014d-ce1a-7110-9bac-c4c59647a88d"
            )
        );
    }
}
