using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;

namespace PayabliApi.Test.Unit.MockServer.CaseManagement;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteAttachmentTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/cases/caseUuid/attachments/attachmentId")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.CaseManagement.DeleteAttachmentAsync("caseUuid", "attachmentId")
        );
    }
}
