using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Vendor;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ScheduleEnrichmentCallTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "vendorId": 456,
              "phone": "5555550200",
              "enrichmentId": "enrich-3890-a1b2c3d4",
              "billId": 54323,
              "fallbackMethod": "check",
              "maxRetries": 3,
              "timezone": "America/New_York"
            }
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "callScheduleId": 430,
                "enrichmentId": "enrich-3890-a1b2c3d4",
                "scheduledCallDate": "2026-06-16T13:00:00Z",
                "status": "dispatched"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Vendor/enrich/schedule_call/8cfec329267")
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

        var response = await Client.Vendor.ScheduleEnrichmentCallAsync(
            "8cfec329267",
            new ScheduleEnrichmentCallRequest
            {
                VendorId = 456,
                Phone = "5555550200",
                EnrichmentId = "enrich-3890-a1b2c3d4",
                BillId = 54323,
                FallbackMethod = "check",
                MaxRetries = 3,
                Timezone = "America/New_York",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
