using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Applications;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListApplicationDocumentsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Documents retrieved successfully",
              "traceId": "0HNPA8416RDEU:00000001",
              "data": [
                {
                  "documentReference": "019ff1d7-5c2e-7a41-9b3d-2f6e8c1a4d90",
                  "kind": "applicantUpload",
                  "subjectType": "business",
                  "fieldPath": "documents.bankStatement",
                  "fileName": "bank-statement-september.pdf",
                  "mimeType": "application/pdf",
                  "fileSizeBytes": 482113,
                  "uploadedAt": "2026-10-16T13:20:22.876Z"
                },
                {
                  "documentReference": "019ff1d7-6e14-7c8b-a2f5-91d3b7e04c62",
                  "kind": "applicantUpload",
                  "subjectType": "person",
                  "personReference": "01a0014d-ce1a-7110-9bac-c4c59647a88d",
                  "fieldPath": "person.documents.w9",
                  "fileName": "w9-marcus-delgado.pdf",
                  "mimeType": "application/pdf",
                  "fileSizeBytes": 96270,
                  "uploadedAt": "2026-10-16T13:34:51.377Z"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/requests/3f3caa7b-bdfe-4bf1-814b-30d54859247c/documents")
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

        var response = await Client.Applications.ListApplicationDocumentsAsync(
            "3f3caa7b-bdfe-4bf1-814b-30d54859247c"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
