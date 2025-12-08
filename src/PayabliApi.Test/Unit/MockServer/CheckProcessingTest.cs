using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class CheckProcessingTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "entryPoint": "47abcfea12",
              "frontImage": "/9j/4AAQSkZJRgABAQEASABIAAD...",
              "rearImage": "/9j/4AAQSkZJRgABAQEASABIAAD...",
              "checkAmount": 12550
            }
            """;

        const string mockResponse = """
            {
              "id": "txn_abc123def456",
              "success": true,
              "processDate": "2025-04-10T04:17:09.875Z",
              "ocrMicr": "⑆123456789⑆ ⑈123456⑈ 0123",
              "ocrMicrStatus": "SUCCESS",
              "ocrMicrConfidence": "95",
              "ocrAccountNumber": "123456",
              "ocrRoutingNumber": "123456789",
              "ocrCheckNumber": "0123",
              "ocrCheckTranCode": "",
              "ocrAmount": "125.50",
              "ocrAmountStatus": "SUCCESS",
              "ocrAmountConfidence": "98",
              "amountDiscrepancyDetected": false,
              "endorsementDetected": true,
              "errors": [],
              "messages": [
                "Check processed successfully"
              ],
              "carLarMatchConfidence": "97",
              "carLarMatchStatus": "MATCH",
              "checkType": 1,
              "referenceNumber": "REF_XYZ789",
              "pageIdentifier": null
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/CheckCapture/CheckProcessing")
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

        var response = await Client.CheckCapture.CheckProcessingAsync(
            new CheckCaptureRequestBody
            {
                EntryPoint = "47abcfea12",
                FrontImage = "/9j/4AAQSkZJRgABAQEASABIAAD...",
                RearImage = "/9j/4AAQSkZJRgABAQEASABIAAD...",
                CheckAmount = 12550,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CheckCaptureResponse>(mockResponse)).UsingDefaults()
        );
    }
}
