using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Invoice;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class EditInvoiceTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "invoiceData": {
                "items": [
                  {
                    "itemProductName": "Deposit",
                    "itemDescription": "Deposit for trip planning",
                    "itemCost": 882.37,
                    "itemQty": 1
                  }
                ],
                "invoiceDate": "2025-10-19",
                "invoiceAmount": 982.37,
                "invoiceNumber": "INV-2345"
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseData": 332,
              "responseText": "Success",
              "roomId": 0
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Invoice/23548884")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Invoice.EditInvoiceAsync(
            23548884,
            new EditInvoiceRequest
            {
                Body = new InvoiceDataRequest
                {
                    InvoiceData = new BillData
                    {
                        Items = new List<BillItem>()
                        {
                            new BillItem
                            {
                                ItemProductName = "Deposit",
                                ItemDescription = "Deposit for trip planning",
                                ItemCost = 882.37,
                                ItemQty = 1,
                            },
                        },
                        InvoiceDate = new DateOnly(2025, 10, 19),
                        InvoiceAmount = 982.37,
                        InvoiceNumber = "INV-2345",
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
