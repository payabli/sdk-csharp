using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Vendor;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetEnrichmentCallStatusTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "vendorId": 456,
              "state": "scheduled",
              "scheduled": {
                "scheduledFor": "2026-06-16T13:00:00Z",
                "attemptsRemaining": 3,
                "maxAttempts": 3
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Vendor/456/enrichment/call-status")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Vendor.GetEnrichmentCallStatusAsync(456);
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "vendorId": 456,
              "state": "successful",
              "completed": {
                "completedAt": "2026-06-16T13:13:42Z",
                "durationSeconds": 222,
                "summary": "Vendor confirmed they accept card payments and provided a billing email.",
                "callId": "call-3890-9f8e7d6c",
                "transcript": "AI Agent: Hi, I'm calling on behalf of Acme Corporation about payment options. Does Greenfield Landscaping accept card payments?\nVendor: Yes, we take cards. You can send receipts to our billing email.",
                "extractedData": {
                  "selectedPaymentMethod": "card",
                  "contactEmail": "ap@greenfield-landscaping.com"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Vendor/456/enrichment/call-status")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Vendor.GetEnrichmentCallStatusAsync(456);
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string mockResponse = """
            {
              "vendorId": 456,
              "state": "failed",
              "failed": {
                "lastAttemptAt": "2026-06-16T13:00:00Z",
                "reason": "No answer",
                "attemptsRemaining": 2,
                "maxAttempts": 3,
                "nextRetryScheduledFor": "2026-06-17T13:00:00Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Vendor/456/enrichment/call-status")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Vendor.GetEnrichmentCallStatusAsync(456);
        JsonAssert.AreEqual(response, mockResponse);
    }
}
