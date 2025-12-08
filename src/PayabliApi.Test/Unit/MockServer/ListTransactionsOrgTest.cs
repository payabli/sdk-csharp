using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ListTransactionsOrgTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
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
                  "DeviceId": "6c361c7d-674c-44cc-b790-382b75d1xxx",
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
                    "paymentDetails": {
                      "totalAmount": 100
                    }
                  },
                  "PaymentTransId": "226-fe55ec0348e34702bd91b4be198ce7ec",
                  "PayorId": 1551,
                  "PaypointDbaname": "Sunshine Gutters",
                  "PaypointEntryname": "d193cf9a46",
                  "PaypointId": 226,
                  "PaypointLegalname": "Sunshine Services, LLC",
                  "PendingFeeAmount": 2,
                  "RefundId": 0,
                  "ResponseData": {
                    "response_code": "XXX",
                    "response_code_text": "Transaction was approved.",
                    "responsetext": "CAPTURED"
                  },
                  "ReturnedId": 0,
                  "ScheduleReference": 0,
                  "SettlementStatus": 2,
                  "Source": "api",
                  "splitFundingInstructions": [
                    {}
                  ],
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
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<QueryResponseTransactions>(mockResponse))
                .UsingDefaults()
        );
    }
}
