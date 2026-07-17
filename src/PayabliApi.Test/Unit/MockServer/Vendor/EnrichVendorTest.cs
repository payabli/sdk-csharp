using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Vendor;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class EnrichVendorTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "vendorId": 456,
              "scope": [
                "invoice_scan"
              ],
              "applyEnrichmentData": false,
              "fallbackMethod": "check",
              "invoiceFile": {
                "ftype": "pdf",
                "filename": "invoice-2026-001.pdf",
                "fContent": "<base64-encoded-pdf>"
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseText": "Success",
              "responseData": {
                "enrichmentId": "enrich-3890-a1b2c3d4",
                "status": "insufficient",
                "stagesTriggered": [
                  "invoice_scan"
                ],
                "vendorPayoutReady": false,
                "enrichmentData": {
                  "invoiceScan": {
                    "vendorName": "Greenfield Landscaping",
                    "street": "456 Commerce Blvd",
                    "city": "Indianapolis",
                    "state": "IN",
                    "zipCode": "46201",
                    "country": "US",
                    "phone": "5555550100",
                    "cardAccepted": "unable to determine",
                    "achAccepted": "unable to determine",
                    "checkAccepted": "yes",
                    "invoiceNumber": "INV-2345",
                    "amountDue": 390.5,
                    "dueDate": "2026-01-31"
                  }
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Vendor/enrich/8cfec329267")
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

        var response = await Client.Vendor.EnrichVendorAsync(
            "8cfec329267",
            new VendorEnrichRequest
            {
                VendorId = 456,
                Scope = new List<string>() { "invoice_scan" },
                ApplyEnrichmentData = false,
                FallbackMethod = "check",
                InvoiceFile = new FileContent
                {
                    Ftype = FileContentFtype.Pdf,
                    Filename = "invoice-2026-001.pdf",
                    FContent = "<base64-encoded-pdf>",
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "vendorId": 456,
              "scope": [
                "web_search"
              ],
              "applyEnrichmentData": false,
              "fallbackMethod": "check"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseText": "Success",
              "responseData": {
                "enrichmentId": "enrich-3891-e5f6a7b8",
                "status": "completed",
                "stagesTriggered": [
                  "web_search"
                ],
                "vendorPayoutReady": true,
                "enrichmentData": {
                  "webSearch": {
                    "phone": "5555550200",
                    "phoneType": "main",
                    "email": "ap@greenfield-landscaping.com",
                    "emailType": "billing",
                    "street": "456 Commerce Blvd",
                    "city": "Indianapolis",
                    "state": "IN",
                    "zipCode": "46201",
                    "country": "US",
                    "addressType": "business",
                    "paymentLink": "https://greenfield-landscaping.com/pay",
                    "paymentLinkType": "payment_portal",
                    "cardAccepted": "yes",
                    "achAccepted": "unable to determine",
                    "checkAccepted": "yes"
                  }
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Vendor/enrich/8cfec329267")
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

        var response = await Client.Vendor.EnrichVendorAsync(
            "8cfec329267",
            new VendorEnrichRequest
            {
                VendorId = 456,
                Scope = new List<string>() { "web_search" },
                ApplyEnrichmentData = false,
                FallbackMethod = "check",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "vendorId": 456,
              "scope": [
                "web_search"
              ],
              "applyEnrichmentData": true,
              "fallbackMethod": "check"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseText": "Success",
              "responseData": {
                "enrichmentId": "enrich-3891-c9d0e1f2",
                "status": "completed",
                "stagesTriggered": [
                  "web_search"
                ],
                "vendorPayoutReady": true,
                "enrichmentData": {
                  "webSearch": {
                    "phone": "5555550200",
                    "phoneType": "main",
                    "email": "ap@greenfield-landscaping.com",
                    "emailType": "billing",
                    "street": "456 Commerce Blvd",
                    "city": "Indianapolis",
                    "state": "IN",
                    "zipCode": "46201",
                    "country": "US",
                    "addressType": "business",
                    "paymentLink": "https://greenfield-landscaping.com/pay",
                    "paymentLinkType": "payment_portal",
                    "cardAccepted": "yes",
                    "achAccepted": "unable to determine",
                    "checkAccepted": "yes"
                  }
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Vendor/enrich/8cfec329267")
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

        var response = await Client.Vendor.EnrichVendorAsync(
            "8cfec329267",
            new VendorEnrichRequest
            {
                VendorId = 456,
                Scope = new List<string>() { "web_search" },
                ApplyEnrichmentData = true,
                FallbackMethod = "check",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
