using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
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
                "customerNumber": "3"
              },
              "invoiceData": {
                "items": [
                  {
                    "itemProductName": "Adventure Consult",
                    "itemDescription": "Consultation for Georgian tours",
                    "itemCost": 100,
                    "itemQty": 1,
                    "itemMode": 1
                  },
                  {
                    "itemProductName": "Deposit ",
                    "itemDescription": "Deposit for trip planning",
                    "itemCost": 882.37,
                    "itemQty": 1
                  }
                ],
                "invoiceDate": "2025-10-19",
                "invoiceType": 0,
                "invoiceStatus": 1,
                "frequency": "one-time",
                "invoiceAmount": 982.37,
                "discount": 10,
                "invoiceNumber": "INV-3"
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseData": 3625,
              "responseText": "Success",
              "pageidentifier": null,
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
                        CustomerNumber = "3",
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
                                ItemQty = 1,
                                ItemMode = 1,
                            },
                            new BillItem
                            {
                                ItemProductName = "Deposit ",
                                ItemDescription = "Deposit for trip planning",
                                ItemCost = 882.37,
                                ItemQty = 1,
                            },
                        },
                        InvoiceDate = new DateOnly(2025, 10, 19),
                        InvoiceType = 0,
                        InvoiceStatus = 1,
                        Frequency = Frequency.OneTime,
                        InvoiceAmount = 982.37,
                        Discount = 10,
                        InvoiceNumber = "INV-3",
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
