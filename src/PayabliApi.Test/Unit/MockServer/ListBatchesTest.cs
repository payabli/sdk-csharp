using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ListBatchesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Summary": {
                "pageidentifier": null,
                "pageSize": 20,
                "totalAmount": 54049.71,
                "totalNetAmount": 0,
                "totalPages": 3,
                "totalRecords": 3
              },
              "Records": [
                {
                  "IdBatch": 1049,
                  "BatchNumber": "batch_2857_combined_08-26-2025_001",
                  "TransferIdentifier": null,
                  "EventsData": [
                    {
                      "description": "Created",
                      "eventTime": "2025-08-25T07:19:27.619Z",
                      "refData": null,
                      "extraData": null,
                      "source": "api"
                    }
                  ],
                  "ConnectorName": "GP",
                  "BatchDate": "2025-08-25T20:00:00.000Z",
                  "BatchAmount": 0,
                  "BatchFeesAmount": 0,
                  "BatchAuthAmount": 0,
                  "BatchReleasedAmount": 0,
                  "BatchHoldAmount": 0,
                  "BatchReturnedAmount": 0,
                  "BatchRefundAmount": 0,
                  "BatchSplitAmount": 0,
                  "BatchStatus": 2,
                  "BatchRecords": 2,
                  "PaypointId": 187,
                  "PaypointName": "Gruzya Adventure Outfitters, LLC",
                  "PaypointDba": "Gruzya Adventure Outfitters",
                  "ParentOrgName": "Pilgrim Planner",
                  "ParentOrgId": 105,
                  "externalPaypointID": null,
                  "EntryName": "47f4f8c7e1",
                  "BankName": null,
                  "BatchType": 0,
                  "Method": "combined",
                  "ExpectedDepositDate": "2025-08-26T00:00:00.000Z",
                  "DepositDate": null,
                  "TransferDate": "2025-08-26T00:00:00.000Z",
                  "Transfer": null
                },
                {
                  "IdBatch": 1043,
                  "BatchNumber": "BT-2023041817-187",
                  "TransferIdentifier": null,
                  "EventsData": null,
                  "ConnectorName": null,
                  "BatchDate": "2023-04-18T17:01:03.000Z",
                  "BatchAmount": 219.02,
                  "BatchFeesAmount": 0,
                  "BatchAuthAmount": 0,
                  "BatchReleasedAmount": 0,
                  "BatchHoldAmount": 0,
                  "BatchReturnedAmount": 0,
                  "BatchRefundAmount": 0,
                  "BatchSplitAmount": 0,
                  "BatchStatus": 2,
                  "BatchRecords": 1,
                  "PaypointId": 187,
                  "PaypointName": "Gruzya Adventure Outfitters, LLC",
                  "PaypointDba": "Gruzya Adventure Outfitters",
                  "ParentOrgName": "Pilgrim Planner",
                  "ParentOrgId": 105,
                  "externalPaypointID": null,
                  "EntryName": "d193cf9a46",
                  "BankName": null,
                  "BatchType": 0,
                  "Method": "card",
                  "ExpectedDepositDate": "2023-04-19T00:00:00.000Z",
                  "DepositDate": null,
                  "TransferDate": "2025-09-02T00:00:00.000Z",
                  "Transfer": null
                },
                {
                  "IdBatch": 1012,
                  "BatchNumber": "BT-2023041421-187",
                  "TransferIdentifier": "ec310c3d-d4bf-4670-9524-00fcc4ab6a2a",
                  "EventsData": [
                    {
                      "description": "Created",
                      "eventTime": "2023-04-14T21:01:03.000Z",
                      "refData": null,
                      "extraData": null,
                      "source": "api"
                    },
                    {
                      "description": "Closed",
                      "eventTime": "2023-04-15T03:05:10.000Z",
                      "refData": "batchId: 1012",
                      "extraData": null,
                      "source": "worker"
                    }
                  ],
                  "ConnectorName": "GP",
                  "BatchDate": "2023-04-14T21:01:03.000Z",
                  "BatchAmount": 1080.44,
                  "BatchFeesAmount": 0,
                  "BatchAuthAmount": 1080.44,
                  "BatchReleasedAmount": 0,
                  "BatchHoldAmount": 0,
                  "BatchReturnedAmount": 0,
                  "BatchRefundAmount": 0,
                  "BatchSplitAmount": 0,
                  "BatchStatus": 2,
                  "BatchRecords": 4,
                  "PaypointId": 187,
                  "PaypointName": "Gruzya Adventure Outfitters, LLC",
                  "PaypointDba": "Gruzya Adventure Outfitters",
                  "ParentOrgName": "Pilgrim Planner",
                  "ParentOrgId": 105,
                  "externalPaypointID": null,
                  "EntryName": "d193cf9a46",
                  "BankName": null,
                  "BatchType": 0,
                  "Method": "card",
                  "ExpectedDepositDate": "2023-04-15T00:00:00.000Z",
                  "DepositDate": null,
                  "TransferDate": "2025-09-02T00:00:00.000Z",
                  "Transfer": {
                    "TransferId": 5998,
                    "TransferDate": "2025-09-02T00:00:00.000Z",
                    "Processor": "gp",
                    "TransferStatus": 1,
                    "GrossAmount": 1080.44,
                    "ChargeBackAmount": 0,
                    "ReturnedAmount": 0,
                    "RefundAmount": 0,
                    "HoldAmount": 0,
                    "ReleasedAmount": 0,
                    "BillingFeesAmount": 0,
                    "ThirdPartyPaidAmount": 0,
                    "AdjustmentsAmount": 0,
                    "NetFundedAmount": 1080.44
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Query/batches/8cfec329267")
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

        var response = await Client.Query.ListBatchesAsync(
            "8cfec329267",
            new ListBatchesRequest
            {
                FromRecord = 251,
                LimitRecord = 0,
                SortBy = "desc(field_name)",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<QueryBatchesResponse>(mockResponse)).UsingDefaults()
        );
    }
}
