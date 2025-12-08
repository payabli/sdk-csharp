using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class AddBillTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "billNumber": "ABC-123",
              "netAmount": 3762.87,
              "billDate": "2024-07-01",
              "dueDate": "2024-07-01",
              "comments": "Deposit for materials",
              "billItems": [
                {
                  "itemProductCode": "M-DEPOSIT",
                  "itemProductName": "Materials deposit",
                  "itemDescription": "Deposit for materials",
                  "itemCommodityCode": "010",
                  "itemUnitOfMeasure": "SqFt",
                  "itemCost": 5,
                  "itemQty": 1,
                  "itemMode": 0,
                  "itemCategories": [
                    "deposits"
                  ],
                  "itemTotalAmount": 123,
                  "itemTaxAmount": 7,
                  "itemTaxRate": 0.075
                }
              ],
              "mode": 0,
              "accountingField1": "MyInternalId",
              "vendor": {
                "vendorNumber": "1234-A"
              },
              "endDate": "2024-07-01",
              "frequency": "monthly",
              "terms": "NET30",
              "status": -99,
              "attachments": [
                {
                  "ftype": "pdf",
                  "filename": "my-doc.pdf",
                  "furl": "https://mysite.com/my-doc.pdf"
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "pageIdentifier": null,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": 6101
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Bill/single/8cfec329267")
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

        var response = await Client.Bill.AddBillAsync(
            "8cfec329267",
            new AddBillRequest
            {
                Body = new BillOutData
                {
                    BillNumber = "ABC-123",
                    NetAmount = 3762.87,
                    BillDate = new DateOnly(2024, 7, 1),
                    DueDate = new DateOnly(2024, 7, 1),
                    Comments = "Deposit for materials",
                    BillItems = new List<BillItem>()
                    {
                        new BillItem
                        {
                            ItemProductCode = "M-DEPOSIT",
                            ItemProductName = "Materials deposit",
                            ItemDescription = "Deposit for materials",
                            ItemCommodityCode = "010",
                            ItemUnitOfMeasure = "SqFt",
                            ItemCost = 5,
                            ItemQty = 1,
                            ItemMode = 0,
                            ItemCategories = new List<string>() { "deposits" },
                            ItemTotalAmount = 123,
                            ItemTaxAmount = 7,
                            ItemTaxRate = 0.075,
                        },
                    },
                    Mode = 0,
                    AccountingField1 = "MyInternalId",
                    Vendor = new VendorData { VendorNumber = "1234-A" },
                    EndDate = new DateOnly(2024, 7, 1),
                    Frequency = Frequency.Monthly,
                    Terms = "NET30",
                    Status = -99,
                    Attachments = new List<FileContent>()
                    {
                        new FileContent
                        {
                            Ftype = FileContentFtype.Pdf,
                            Filename = "my-doc.pdf",
                            Furl = "https://mysite.com/my-doc.pdf",
                        },
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BillResponse>(mockResponse)).UsingDefaults()
        );
    }
}
