using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Invoice;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListInvoicesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Records": [
                {
                  "invoiceId": 3674,
                  "customerId": 4440,
                  "paypointId": 3040,
                  "invoiceNumber": "INV-2345",
                  "invoiceDate": "2025-03-05",
                  "invoiceDueDate": "2025-03-05",
                  "invoiceSentDate": "2025-03-05",
                  "invoiceEndDate": "2025-03-05",
                  "createdAt": "2024-03-05T18:08:45.000Z",
                  "invoiceStatus": 1,
                  "invoiceType": 0,
                  "frequency": "onetime",
                  "paymentTerms": "NET30",
                  "tax": 0,
                  "discount": 0,
                  "invoiceAmount": 50,
                  "invoicePaidAmount": 0,
                  "freightAmount": 0,
                  "dutyAmount": 0,
                  "firstName": "Amirah",
                  "lastName": "Tan",
                  "shippingAddress1": "1234 Rainier Ave",
                  "shippingAddress2": "Apt 567",
                  "shippingCity": "Seattle",
                  "shippingState": "WA",
                  "shippingZip": "98101",
                  "shippingFromZip": "",
                  "shippingCountry": "US",
                  "shippingEmail": "amirah.tan@example.com",
                  "shippingPhone": "",
                  "items": [
                    {
                      "itemCost": 50,
                      "itemDescription": "service",
                      "itemProductName": "Internet",
                      "itemQty": 1
                    }
                  ],
                  "Customer": {
                    "AdditionalData": {
                      "key1": "value",
                      "key2": "value",
                      "key3": "value"
                    },
                    "BillingPhone": "1234567890",
                    "customerId": 4440
                  },
                  "paylinkId": "2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234",
                  "billEvents": [
                    {
                      "description": "Invoice created",
                      "eventTime": "2024-03-05T23:08:45.000Z",
                      "refData": "00-802fa578504a7af6f3dd890a3802f7ef-61b4bedXXXX1234"
                    }
                  ],
                  "PaypointLegalname": "Emerald City LLC",
                  "PaypointDbaname": "Emerald City Trading",
                  "PaypointEntryname": "47a30009s",
                  "ParentOrgId": 123,
                  "ParentOrgName": "Emerald Enterprises",
                  "externalPaypointID": "seattletrade01-10"
                }
              ],
              "Summary": {
                "pageIdentifier": "null",
                "pageSize": 20,
                "totalAmount": 77.22,
                "totalNetAmount": 77.22,
                "totalPages": 2,
                "totalRecords": 2
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Query/invoices/8cfec329267")
                    .WithParam("fromRecord", "251")
                    .WithParam("limitRecord", "0")
                    .WithParam("sortBy", "desc(field_name)")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Invoice.ListInvoicesAsync(
            "8cfec329267",
            new ListInvoicesRequest
            {
                FromRecord = 251,
                LimitRecord = 0,
                SortBy = "desc(field_name)",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
