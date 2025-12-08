using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
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
                "invoiceNumber": "INV-6"
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseData": 332,
              "responseText": "Success",
              "pageidentifier": null,
              "roomId": 0
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Invoice/332")
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
            332,
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
                        InvoiceNumber = "INV-6",
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<InvoiceResponseWithoutData>(mockResponse))
                .UsingDefaults()
        );
    }
}
