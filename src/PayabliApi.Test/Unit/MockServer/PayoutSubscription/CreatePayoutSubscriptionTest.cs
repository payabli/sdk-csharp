using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.PayoutSubscription;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreatePayoutSubscriptionTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "entryPoint": "8cfec329267",
              "paymentMethod": {
                "method": "ach",
                "achHolder": "Herman Coatings",
                "achRouting": "021000021",
                "achAccount": "3453445666",
                "achAccountType": "checking"
              },
              "paymentDetails": {
                "totalAmount": 500,
                "serviceFee": 0,
                "currency": "USD"
              },
              "vendorData": {
                "vendorId": 456
              },
              "billData": [
                {
                  "invoiceNumber": "INV-2345",
                  "netAmount": "500",
                  "invoiceDate": "2025-08-01",
                  "dueDate": "2025-08-15"
                }
              ],
              "scheduleDetails": {
                "startDate": "09/01/2027",
                "endDate": "09/01/2026",
                "frequency": "monthly"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "responseData": 42,
              "customerId": 4440
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PayoutSubscription")
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

        var response = await Client.PayoutSubscription.CreatePayoutSubscriptionAsync(
            new RequestPayoutSchedule
            {
                EntryPoint = "8cfec329267",
                PaymentMethod = new AuthorizePaymentMethod
                {
                    Method = "ach",
                    AchHolder = "Herman Coatings",
                    AchRouting = "021000021",
                    AchAccount = "3453445666",
                    AchAccountType = "checking",
                },
                PaymentDetails = new PayoutPaymentDetail
                {
                    TotalAmount = 500,
                    ServiceFee = 0,
                    Currency = "USD",
                },
                VendorData = new RequestOutAuthorizeVendorData { VendorId = 456 },
                BillData = new List<BillPayOutDataRequest>()
                {
                    new BillPayOutDataRequest
                    {
                        InvoiceNumber = "INV-2345",
                        NetAmount = "500",
                        InvoiceDate = new DateOnly(2025, 8, 1),
                        DueDate = new DateOnly(2025, 8, 15),
                    },
                },
                ScheduleDetails = new PayoutScheduleDetail
                {
                    StartDate = "09/01/2027",
                    EndDate = "09/01/2026",
                    Frequency = Frequency.Monthly,
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
              "entryPoint": "8cfec329267",
              "paymentMethod": {
                "method": "vcard"
              },
              "paymentDetails": {
                "totalAmount": 250,
                "serviceFee": 0
              },
              "vendorData": {
                "vendorId": 456
              },
              "billData": [
                {
                  "invoiceNumber": "INV-2345",
                  "netAmount": "250",
                  "invoiceDate": "2025-08-15",
                  "dueDate": "2025-09-01"
                }
              ],
              "scheduleDetails": {
                "startDate": "09/01/2027",
                "frequency": "weekly",
                "endDate": "untilcancelled"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "responseData": 42,
              "customerId": 4440
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PayoutSubscription")
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

        var response = await Client.PayoutSubscription.CreatePayoutSubscriptionAsync(
            new RequestPayoutSchedule
            {
                EntryPoint = "8cfec329267",
                PaymentMethod = new AuthorizePaymentMethod { Method = "vcard" },
                PaymentDetails = new PayoutPaymentDetail { TotalAmount = 250, ServiceFee = 0 },
                VendorData = new RequestOutAuthorizeVendorData { VendorId = 456 },
                BillData = new List<BillPayOutDataRequest>()
                {
                    new BillPayOutDataRequest
                    {
                        InvoiceNumber = "INV-2345",
                        NetAmount = "250",
                        InvoiceDate = new DateOnly(2025, 8, 15),
                        DueDate = new DateOnly(2025, 9, 1),
                    },
                },
                ScheduleDetails = new PayoutScheduleDetail
                {
                    StartDate = "09/01/2027",
                    Frequency = Frequency.Weekly,
                    EndDate = "untilcancelled",
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
