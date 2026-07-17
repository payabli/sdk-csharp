using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Invoice;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AddInvoiceTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "customerData": {
                "firstName": "Tamara",
                "lastName": "Bagratoni",
                "customerNumber": "C-90010"
              },
              "invoiceData": {
                "items": [
                  {
                    "itemProductName": "Adventure Consult",
                    "itemDescription": "Consultation for Georgian tours",
                    "itemCost": 100,
                    "itemQty": 2,
                    "itemMode": 2,
                    "itemTotalAmount": 200
                  },
                  {
                    "itemProductName": "Deposit ",
                    "itemDescription": "Deposit for trip planning",
                    "itemCost": 882.37,
                    "itemQty": 1,
                    "itemMode": 2,
                    "itemTotalAmount": 882.37
                  }
                ],
                "invoiceDate": "2025-10-19",
                "invoiceType": 0,
                "invoiceStatus": 1,
                "frequency": "onetime",
                "invoiceAmount": 1082.37,
                "discount": 10,
                "invoiceNumber": "INV-2345"
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseData": 3625,
              "responseText": "Success",
              "roomId": 0
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Invoice/8cfec329267")
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

        var response = await Client.Invoice.AddInvoiceAsync(
            "8cfec329267",
            new AddInvoiceRequest
            {
                Body = new InvoiceDataRequest
                {
                    CustomerData = new PayorDataRequest
                    {
                        FirstName = "Tamara",
                        LastName = "Bagratoni",
                        CustomerNumber = "C-90010",
                    },
                    InvoiceData = new BillData
                    {
                        Items = new List<BillItem>()
                        {
                            new BillItem
                            {
                                ItemProductName = "Adventure Consult",
                                ItemDescription = "Consultation for Georgian tours",
                                ItemCost = 100,
                                ItemQty = 2,
                                ItemMode = 2,
                                ItemTotalAmount = 200,
                            },
                            new BillItem
                            {
                                ItemProductName = "Deposit ",
                                ItemDescription = "Deposit for trip planning",
                                ItemCost = 882.37,
                                ItemQty = 1,
                                ItemMode = 2,
                                ItemTotalAmount = 882.37,
                            },
                        },
                        InvoiceDate = new DateOnly(2025, 10, 19),
                        InvoiceType = 0,
                        InvoiceStatus = 1,
                        Frequency = Frequency.OneTime,
                        InvoiceAmount = 1082.37,
                        Discount = 10,
                        InvoiceNumber = "INV-2345",
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
