using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Applications;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListApplicationDocumentRequirementsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Document requirements retrieved successfully",
              "traceId": "0HNPA847I3953:0000001E",
              "data": [
                {
                  "fieldPath": "documents.bankStatement",
                  "label": "Bank Statements",
                  "source": "businessRule",
                  "subjectTypes": [
                    "paypoint",
                    "business"
                  ],
                  "required": true,
                  "maxUploads": 3,
                  "allowedFormats": [
                    "pdf",
                    "jpg",
                    "jpeg",
                    "png"
                  ],
                  "uploadedCount": 0
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v2/requests/3f3caa7b-bdfe-4bf1-814b-30d54859247c/documents/requirements"
                    )
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

        var response = await Client.Applications.ListApplicationDocumentRequirementsAsync(
            "3f3caa7b-bdfe-4bf1-814b-30d54859247c"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Document requirements retrieved successfully",
              "traceId": "0HNPA8416RDFS:0000000E",
              "data": [
                {
                  "fieldPath": "documents.businessLicense",
                  "label": "Business License",
                  "hint": "Current business operating license",
                  "source": "template",
                  "subjectTypes": [
                    "paypoint",
                    "business"
                  ],
                  "required": false,
                  "maxUploads": 1,
                  "allowedFormats": [
                    "pdf",
                    "png",
                    "jpg"
                  ],
                  "uploadedCount": 0
                },
                {
                  "fieldPath": "person.documents.w9",
                  "label": "W-9 Form",
                  "hint": "Signed W-9 tax form",
                  "source": "template",
                  "subjectTypes": [
                    "person"
                  ],
                  "personReference": "01a0014d-ce1a-7110-9bac-c4c59647a88d",
                  "required": true,
                  "maxUploads": 1,
                  "allowedFormats": [
                    "pdf"
                  ],
                  "uploadedCount": 0
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v2/requests/3f3caa7b-bdfe-4bf1-814b-30d54859247c/documents/requirements"
                    )
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

        var response = await Client.Applications.ListApplicationDocumentRequirementsAsync(
            "3f3caa7b-bdfe-4bf1-814b-30d54859247c"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
