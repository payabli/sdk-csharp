using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyOut;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PayoutTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "entryPoint": "8cfec329267",
              "invoiceData": [
                {
                  "billId": 54323
                }
              ],
              "orderDescription": "Window Painting",
              "paymentDetails": {
                "totalAmount": 47
              },
              "paymentMethod": {
                "method": "managed"
              },
              "vendorData": {
                "vendorNumber": "VEN-123"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Captured",
                "customerId": 456,
                "vendorId": 456
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyOut/payout")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
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

        var response = await Client.MoneyOut.PayoutAsync(
            new PayoutRequest
            {
                Body = new AuthorizePayoutBody
                {
                    EntryPoint = "8cfec329267",
                    InvoiceData = new List<RequestOutAuthorizeInvoiceData>()
                    {
                        new RequestOutAuthorizeInvoiceData { BillId = 54323 },
                    },
                    OrderDescription = "Window Painting",
                    PaymentDetails = new RequestOutAuthorizePaymentDetails { TotalAmount = 47 },
                    PaymentMethod = new AuthorizePaymentMethod { Method = "managed" },
                    VendorData = new RequestOutAuthorizeVendorData { VendorNumber = "VEN-123" },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
