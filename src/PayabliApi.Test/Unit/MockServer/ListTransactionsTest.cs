using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ListTransactionsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Records": [
                {
                  "BatchAmount": 30.22,
                  "BatchNumber": "1234567",
                  "CfeeTransactions": [
                    {
                      "cFeeTransid": "string",
                      "feeAmount": 0,
                      "operation": "string",
                      "refundId": 0,
                      "settlementStatus": 0,
                      "transactionTime": "2019-08-24T14:15:22.000Z",
                      "transStatus": 0
                    }
                  ],
                  "ConnectorName": "gp",
                  "Customer": {
                    "AdditionalData": "AdditionalData",
                    "BillingAddress1": "1111 street",
                    "BillingAddress2": "string",
                    "BillingCity": "myCity",
                    "BillingCountry": "US",
                    "BillingEmail": "customer@mail.com",
                    "BillingPhone": "1234567890",
                    "BillingState": "CA",
                    "BillingZip": "45567",
                    "CompanyName": "Sunshine LLC",
                    "customerId": 34,
                    "CustomerNumber": "3456-7645A",
                    "FirstName": "John",
                    "LastName": "Doe",
                    "ShippingAddress1": "string",
                    "ShippingAddress2": "string",
                    "ShippingCity": "string",
                    "ShippingCountry": "string",
                    "ShippingState": "string",
                    "ShippingZip": "string"
                  },
                  "DeviceId": "6c361c7d-674c-44cc-b790-382b75d1xxx",
                  "EntrypageId": 0,
                  "ExternalProcessorInformation": " ",
                  "FeeAmount": 10.25,
                  "GatewayTransId": "string",
                  "InvoiceData": {
                    "attachments": [
                      {
                        "fContent": "TXkgdGVzdCBmaWxlHJ==...",
                        "filename": "my-doc.pdf",
                        "ftype": "pdf",
                        "furl": "https://mysite.com/my-doc.pdf"
                      }
                    ],
                    "company": "string",
                    "discount": 0,
                    "dutyAmount": 0,
                    "firstName": "string",
                    "freightAmount": 10,
                    "frequency": "one-time",
                    "invoiceAmount": 105,
                    "invoiceDate": "2026-01-01",
                    "invoiceDueDate": "2026-01-15",
                    "invoiceEndDate": "2026-01-15",
                    "invoiceNumber": "INV-2345",
                    "invoiceStatus": 0,
                    "invoiceType": 0,
                    "items": [
                      {
                        "itemCategories": [
                          "string"
                        ],
                        "itemCommodityCode": "string",
                        "itemCost": 1,
                        "itemDescription": "string",
                        "itemMode": 0,
                        "itemProductCode": "string",
                        "itemProductName": "product 01",
                        "itemQty": 1,
                        "itemTaxAmount": 0,
                        "itemTaxRate": 0,
                        "itemTotalAmount": 0,
                        "itemUnitOfMeasure": "U"
                      }
                    ],
                    "lastName": "string",
                    "notes": "string",
                    "paymentTerms": "PIA",
                    "purchaseOrder": "string",
                    "shippingAddress1": "string",
                    "shippingAddress2": "string",
                    "shippingCity": "string",
                    "shippingCountry": "string",
                    "shippingEmail": "string",
                    "shippingFromZip": "string",
                    "shippingPhone": "string",
                    "shippingState": "string",
                    "shippingZip": "string",
                    "summaryCommodityCode": "string",
                    "tax": 2.05,
                    "termsConditions": "string"
                  },
                  "Method": "card",
                  "NetAmount": 100,
                  "Operation": "Sale",
                  "OrderId": "9876543",
                  "OrgId": 2,
                  "ParentOrgName": "Payabli",
                  "PaymentData": {
                    "AccountExp": "0426",
                    "AccountType": "visa",
                    "binData": {
                      "binMatchedLength": "6",
                      "binCardBrand": "VISA",
                      "binCardType": "DEBIT",
                      "binCardCategory": "CLASSIC",
                      "binCardIssuer": "CONOTOXIA SP. Z O.O",
                      "binCardIssuerCountry": "POLAND",
                      "binCardIssuerCountryCodeA2": "PL",
                      "binCardIssuerCountryNumber": "616",
                      "binCardIsRegulated": "true",
                      "binCardUseCategory": "Consumer",
                      "binCardIssuerCountryCodeA3": "POL"
                    },
                    "HolderName": "Billy J Franks",
                    "Initiator": "payor",
                    "MaskedAccount": "411111XXXXXX1111",
                    "paymentDetails": {
                      "totalAmount": 100
                    },
                    "Sequence": "first",
                    "StoredId": "675b43c1-9867-463c-8dc7-3d6ddb68554b-12812",
                    "StoredMethodUsageType": "unscheduled"
                  },
                  "PaymentTransId": "2345667-ddd-fff",
                  "PayorId": 55,
                  "PaypointDbaname": "Sunshine LLC",
                  "PaypointEntryname": "7acda8200",
                  "PaypointId": 2,
                  "PaypointLegalname": "Sunshine LLC",
                  "PendingFeeAmount": 2,
                  "RefundId": 0,
                  "ResponseData": {
                    "authcode": "00",
                    "response_code": "100",
                    "response_code_text": "Transaction was approved.",
                    "responsetext": "CAPTURED",
                    "transactionid": "TRN_xwCAjQorWAYX1nAhAoHZVfN8iYHbI0"
                  },
                  "ReturnedId": 0,
                  "ScheduleReference": 0,
                  "SettlementStatus": 0,
                  "Source": "vterminal",
                  "splitFundingInstructions": [
                    {}
                  ],
                  "TotalAmount": 110.25,
                  "TransactionEvents": [
                    {}
                  ],
                  "TransactionTime": "2019-08-24T14:15:22.000Z",
                  "TransStatus": 1
                }
              ],
              "Summary": {
                "pageIdentifier": "XXXXXXXXXXXXXXXXXXX",
                "pageSize": 20,
                "totalAmount": 177.22,
                "totalNetAmount": 177.22,
                "totalPages": 1,
                "totalRecords": 2
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Query/transactions/8cfec329267")
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

        var response = await Client.Query.ListTransactionsAsync(
            "8cfec329267",
            new ListTransactionsRequest
            {
                FromRecord = 251,
                LimitRecord = 0,
                SortBy = "desc(field_name)",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<QueryResponseTransactions>(mockResponse))
                .UsingDefaults()
        );
    }
}
