using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Query;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTransactionsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
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
                    "BillingAddress1": "1111 street",
                    "BillingAddress2": "string",
                    "BillingCity": "myCity",
                    "BillingCountry": "US",
                    "BillingEmail": "customer@mail.com",
                    "BillingPhone": "1234567890",
                    "BillingState": "CA",
                    "BillingZip": "45567",
                    "CompanyName": "Sunshine LLC",
                    "customerId": 4440,
                    "CustomerNumber": "C-90010",
                    "FirstName": "John",
                    "LastName": "Doe",
                    "ShippingAddress1": "string",
                    "ShippingAddress2": "string",
                    "ShippingCity": "string",
                    "ShippingCountry": "string",
                    "ShippingState": "string",
                    "ShippingZip": "string"
                  },
                  "DeviceId": "499585-389fj484-3jcj8hj3",
                  "EntrypageId": 0,
                  "ExternalProcessorInformation": " ",
                  "FeeAmount": 10.25,
                  "GatewayTransId": "string",
                  "invoiceData": {
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
                    "frequency": "onetime",
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
                  "OrgId": 123,
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
                    "orderDescription": "Monthly subscription",
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
                  "PaypointId": 3040,
                  "PaypointLegalname": "Sunshine LLC",
                  "PendingFeeAmount": 2,
                  "RefundId": 0,
                  "ResponseData": {
                    "authcode": "123456",
                    "avsresponse": "N",
                    "avsresponse_text": "No address or ZIP match only",
                    "cvvresponse": "M",
                    "cvvresponse_text": "CVV2/CVC2 match",
                    "orderid": "10-bfcd5a17861d4a8690ca53c00000X",
                    "response": "Success",
                    "response_code": "100",
                    "response_code_text": "Transaction was approved.",
                    "responsetext": "SUCCESS",
                    "resultCode": "A0000",
                    "resultCodeText": "Approved",
                    "transactionid": "8082800000"
                  },
                  "ReturnedId": 0,
                  "ScheduleReference": 0,
                  "SettlementStatus": 0,
                  "Source": "vterminal",
                  "splitFundingInstructions": [
                    {}
                  ],
                  "splitCount": 1,
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
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "Records": [
                {
                  "ParentOrgName": "RealistRoofing",
                  "PaypointDbaname": "Eagle-Pointe",
                  "PaypointLegalname": "Eagle-Pointe",
                  "PaypointEntryname": "entry399",
                  "PaymentTransId": "399-8e7e5fc7-f483-43cc-9e78-d8a36ac857bf",
                  "ConnectorName": "GP",
                  "Method": "card",
                  "PayorId": 155974,
                  "PaymentData": {
                    "MaskedAccount": "5XXXXXXXXXXX4415",
                    "AccountExp": "12/29",
                    "HolderName": "RENEE DESCARTES",
                    "orderDescription": "Invoice 2034",
                    "binData": {
                      "binMatchedLength": "9",
                      "binCardBrand": "MASTERCARD",
                      "binCardType": "CREDIT",
                      "binCardCategory": "MIXED PRODUCT",
                      "binCardIssuer": "ALLIED IRISH BANKS, PLC",
                      "binCardIssuerCountry": "IRELAND",
                      "binCardIsRegulated": "False",
                      "binCardUseCategory": "PERSONAL"
                    },
                    "paymentDetails": {
                      "totalAmount": 6.79,
                      "serviceFee": 0,
                      "currency": "USD"
                    }
                  },
                  "TransStatus": -4,
                  "PaypointId": 3040,
                  "splitFundingInstructions": [
                    {}
                  ],
                  "splitCount": 1,
                  "TotalAmount": -6.79,
                  "NetAmount": -6.79,
                  "FeeAmount": 0,
                  "SettlementStatus": 0,
                  "Operation": "Reject",
                  "Source": "api",
                  "OrgId": 123,
                  "TransactionTime": "2026-03-02T18:56:23.109Z",
                  "Customer": {
                    "FirstName": "Blaise",
                    "LastName": "Pascal",
                    "CompanyName": "Pensees LLC",
                    "BillingAddress1": "49912 Aufengrupt Pointe",
                    "BillingAddress2": "apt 6",
                    "BillingCity": "South Litzy",
                    "BillingState": "FL",
                    "BillingZip": "33000",
                    "BillingCountry": "US",
                    "BillingPhone": "+18955791994",
                    "BillingEmail": "blaise.pascal@gmail.com",
                    "CustomerNumber": "C-90010",
                    "customerId": 4440,
                    "customerStatus": 1
                  },
                  "TransactionEvents": [
                    {
                      "TransEvent": "Created",
                      "EventData": "Card Reject - CTDR Id: 1379241",
                      "EventTime": "2026-03-02T18:56:23.352Z"
                    }
                  ]
                }
              ],
              "Summary": {
                "totalRecords": 14,
                "totalAmount": -79.48,
                "totalNetAmount": -74.41,
                "totalPages": 14,
                "pageSize": 1
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Query/transactions/8cfec329267")
                    .WithParam("limitRecord", "1")
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
                LimitRecord = 1,
                Parameters = new Dictionary<string, string?>() { { "operation(eq)", "Reject" } },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
