using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ListInvoicesOrgTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Records": [
                {
                  "billEvents": [
                    {
                      "description": "Invoice created",
                      "eventTime": "2024-03-05T23:08:45.000Z",
                      "refData": "00-802fa578504a7af6f3dd890a3802f7ef-61b4bedXXXX1234"
                    }
                  ],
                  "createdAt": "2024-03-05T18:08:45.000Z",
                  "Customer": {
                    "AdditionalData": {
                      "key1": {
                        "key": "value"
                      },
                      "key2": {
                        "key": "value"
                      },
                      "key3": {
                        "key": "value"
                      }
                    },
                    "BillingPhone": "1234567890",
                    "customerId": 1323
                  },
                  "customerId": 1323,
                  "discount": 0,
                  "dutyAmount": 0,
                  "externalPaypointID": "seattletrade01-10",
                  "firstName": "Amirah",
                  "freightAmount": 0,
                  "frequency": "one-time",
                  "termsConditions": null,
                  "notes": null,
                  "invoiceAmount": 50,
                  "invoiceDate": "2025-03-05",
                  "invoiceDueDate": "2025-03-05",
                  "invoiceId": 3674,
                  "invoiceNumber": "QA-1709680125",
                  "invoicePaidAmount": 0,
                  "invoiceStatus": 1,
                  "invoiceType": 0,
                  "items": [
                    {
                      "itemCost": 50,
                      "itemDescription": "service",
                      "itemProductName": "Internet",
                      "itemQty": 1
                    }
                  ],
                  "lastName": "Tan",
                  "ParentOrgName": "Emerald Enterprises",
                  "ParentOrgId": 123,
                  "paylinkId": "3674-cf15b881-f276-4b69-bdc8-841b2d123XXXXXX",
                  "paymentTerms": "N30",
                  "PaypointDbaname": "Emerald City Trading",
                  "PaypointEntryname": "47a30009s",
                  "paypointId": 10,
                  "PaypointLegalname": "Emerald City LLC",
                  "shippingAddress1": "1234 Rainier Ave",
                  "shippingAddress2": "Apt 567",
                  "shippingCity": "Seattle",
                  "shippingCountry": "US",
                  "shippingEmail": "amirah.tan@example.com",
                  "shippingFromZip": "",
                  "shippingPhone": "",
                  "shippingState": "WA",
                  "shippingZip": "98101",
                  "tax": 0
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
                    .WithPath("/Query/invoices/org/123")
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

        var response = await Client.Invoice.ListInvoicesOrgAsync(
            123,
            new ListInvoicesOrgRequest
            {
                FromRecord = 251,
                LimitRecord = 0,
                SortBy = "desc(field_name)",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<QueryInvoiceResponse>(mockResponse)).UsingDefaults()
        );
    }
}
