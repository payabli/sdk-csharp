using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.CaseManagement;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListAttachmentsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            [
              {
                "uuid": "a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5c6d",
                "caseUuid": "9c2b7e14-3a5f-4d21-b8e0-1f6a4c9d2e70",
                "fileType": "application/pdf",
                "filename": "voided-check.pdf",
                "fileUrl": "cases/9c2b7e14-3a5f-4d21-b8e0-1f6a4c9d2e70/attachments/a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5c6d",
                "uploadedAt": "2026-01-15T10:45:00.000Z",
                "uploadedBy": "4238"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/cases/9c2b7e14-3a5f-4d21-b8e0-1f6a4c9d2e70/attachments")
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

        var response = await Client.CaseManagement.ListAttachmentsAsync(
            "9c2b7e14-3a5f-4d21-b8e0-1f6a4c9d2e70"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
