using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Query;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTransactionsOrgTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "Records": [
                {
                  "AchHolderType": "personal",
                  "AchSecCode": "AchSecCode",
                  "BatchAmount": 30.22,
                  "BatchNumber": "batch_226_ach_12-30-2023",
                  "CfeeTransactions": [
                    {
                      "transactionTime": "2024-01-15T09:30:00.000Z"
                    }
                  ],
                  "ConnectorName": "gp",
                  "DeviceId": "499585-389fj484-3jcj8hj3",
                  "EntrypageId": 0,
                  "ExternalProcessorInformation": "[MER_xxxxxxxxxxxxxx]/[NNNNNNNNN]",
                  "FeeAmount": 1,
                  "GatewayTransId": "TRN_xwCAjQorWAYX1nAhAoHZVfN8iYHbI0",
                  "Method": "ach",
                  "NetAmount": 3762.87,
                  "Operation": "Sale",
                  "OrderId": "O-5140",
                  "OrgId": 123,
                  "ParentOrgName": "PropertyManager Pro",
                  "PaymentData": {
                    "orderDescription": "Monthly subscription",
                    "paymentDetails": {
                      "totalAmount": 100
                    }
                  },
                  "PaymentTransId": "226-fe55ec0348e34702bd91b4be198ce7ec",
                  "PayorId": 1551,
                  "PaypointDbaname": "Sunshine Gutters",
                  "PaypointEntryname": "d193cf9a46",
                  "PaypointId": 3040,
                  "PaypointLegalname": "Sunshine Services, LLC",
                  "PendingFeeAmount": 2,
                  "RefundId": 0,
                  "ResponseData": {
                    "authcode": " ",
                    "avsresponse": " ",
                    "avsresponse_text": "",
                    "cvvresponse": " ",
                    "cvvresponse_text": " ",
                    "emv_auth_response_data": " ",
                    "response": "Success",
                    "response_code": "100",
                    "response_code_text": "Transaction was approved.",
                    "responsetext": "CAPTURED",
                    "resultCode": "A0000",
                    "resultCodeText": "Approved",
                    "transactionid": "TRN_xwCAjQorWAYX1nAhAoHZVfN8iYHbI0"
                  },
                  "ReturnedId": 0,
                  "ScheduleReference": 0,
                  "SettlementStatus": 2,
                  "Source": "api",
                  "splitFundingInstructions": [
                    {}
                  ],
                  "splitCount": 1,
                  "TotalAmount": 30.22,
                  "TransactionEvents": [
                    {}
                  ],
                  "TransactionTime": "2025-10-19T00:00:00.000Z",
                  "TransAdditionalData": {
                    "key": "value"
                  },
                  "TransStatus": 1
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
                    .WithPath("/Query/transactions/org/123")
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

        var response = await Client.Query.ListTransactionsOrgAsync(
            123,
            new ListTransactionsOrgRequest
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
                    .WithPath("/Query/transactions/org/123")
                    .WithParam("limitRecord", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Query.ListTransactionsOrgAsync(
            123,
            new ListTransactionsOrgRequest
            {
                LimitRecord = 1,
                Parameters = new Dictionary<string, string?>() { { "operation(eq)", "Reject" } },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
