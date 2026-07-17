using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Ocr;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class OcrDocumentJsonTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseText": "responseText",
              "responseCode": 1,
              "responseData": {
                "resultData": {
                  "billNumber": "billNumber",
                  "netAmount": 1.1,
                  "billDate": "2024-01-15T09:30:00.000Z",
                  "dueDate": "2024-01-15T09:30:00.000Z",
                  "comments": "comments",
                  "billItems": [
                    {}
                  ],
                  "mode": 1,
                  "accountingField1": "accountingField1",
                  "accountingField2": "accountingField2",
                  "endDate": "2024-01-15T09:30:00.000Z",
                  "frequency": "frequency",
                  "terms": "terms",
                  "status": 1,
                  "lotNumber": "lotNumber",
                  "attachments": [
                    {}
                  ]
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Import/ocrDocumentJson/typeResult")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Ocr.OcrDocumentJsonAsync(
            "typeResult",
            new FileContentImageOnly()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
