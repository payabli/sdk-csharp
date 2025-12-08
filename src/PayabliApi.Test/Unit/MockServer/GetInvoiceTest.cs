using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class GetInvoiceTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "AdditionalData": null,
              "billEvents": [
                {
                  "description": "TransferCreated",
                  "eventTime": "2023-07-05T22:31:06.000Z",
                  "extraData": {
                    "key": "value"
                  },
                  "refData": "refData",
                  "source": "api"
                }
              ],
              "company": "Acme Inc",
              "createdAt": "2022-07-01T15:00:01.000Z",
              "Customer": {
                "AdditionalData": null,
                "BillingAddress1": "1111 West 1st Street",
                "BillingAddress2": "Suite 200",
                "BillingCity": "Miami",
                "BillingCountry": "US",
                "BillingEmail": "example@email.com",
                "BillingPhone": "5555555555",
                "BillingState": "FL",
                "BillingZip": "45567",
                "CompanyName": "Sunshine LLC",
                "customerId": 4440,
                "CustomerNumber": "3456-7645A",
                "customerStatus": 1,
                "FirstName": "John",
                "Identifiers": [
                  "\\\"firstname\\\"",
                  "\\\"lastname\\\"",
                  "\\\"email\\\"",
                  "\\\"customId\\\""
                ],
                "LastName": "Doe",
                "ShippingAddress1": "123 Walnut St",
                "ShippingAddress2": "STE 900",
                "ShippingCity": "Johnson City",
                "ShippingCountry": "US",
                "ShippingState": "TN",
                "ShippingZip": "37619"
              },
              "customerId": 4440,
              "discount": 10,
              "DocumentsRef": {
                "filelist": [
                  {}
                ],
                "zipfile": "zx45.zip"
              },
              "dutyAmount": 0,
              "firstName": "firstName",
              "freightAmount": 10,
              "frequency": "one-time",
              "invoiceAmount": 105,
              "invoiceDate": "2025-07-01",
              "invoiceDueDate": "2025-07-01",
              "invoiceEndDate": "2025-07-01",
              "invoiceId": 236,
              "invoiceNumber": "INV-2345",
              "invoicePaidAmount": 0,
              "invoiceSentDate": "2025-10-19T00:00:00.000Z",
              "invoiceStatus": 1,
              "invoiceType": 0,
              "items": [
                {
                  "itemCommodityCode": "010",
                  "itemCost": 5,
                  "itemDescription": "Deposit for materials.",
                  "itemMode": 0,
                  "itemProductCode": "M-DEPOSIT",
                  "itemProductName": "Materials deposit",
                  "itemQty": 1,
                  "itemTaxAmount": 7,
                  "itemTaxRate": 0.075,
                  "itemTotalAmount": 1.1,
                  "itemUnitOfMeasure": "SqFt"
                }
              ],
              "lastName": "lastName",
              "lastPaymentDate": "2025-10-19T00:00:00.000Z",
              "notes": null,
              "ParentOrgName": "parentOrgName",
              "paylinkId": "paylinkId",
              "paymentTerms": "NET30",
              "PaypointDbaname": "Sinks Inc",
              "PaypointEntryname": "5789a30009s",
              "paypointId": 56,
              "PaypointLegalname": "Sinks and Faucets LLC",
              "purchaseOrder": "PO-345",
              "scheduledOptions": {
                "includePaylink": true,
                "includePdf": true
              },
              "shippingAddress1": "123 Walnut St",
              "shippingAddress2": "STE 900",
              "shippingCity": "Johnson City",
              "shippingCountry": "US",
              "shippingEmail": "example@email.com",
              "shippingFromZip": "30040",
              "shippingPhone": "shippingPhone",
              "shippingState": "TN",
              "shippingZip": "37619",
              "summaryCommodityCode": "501718",
              "tax": 2.05,
              "termsConditions": "termsConditions"
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/Invoice/23548884").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Invoice.GetInvoiceAsync(23548884);
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetInvoiceRecord>(mockResponse)).UsingDefaults()
        );
    }
}
