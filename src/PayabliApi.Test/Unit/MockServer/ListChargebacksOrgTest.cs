using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ListChargebacksOrgTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Records": [
                {
                  "AccountType": "4XXXXXX0003",
                  "CaseNumber": "00001",
                  "ChargebackDate": "2023-02-08T00:00:00.000Z",
                  "CreatedAt": "2022-07-01T15:00:01.000Z",
                  "externalPaypointID": "Paypoint-100",
                  "Id": 578,
                  "LastFour": "4XXXXXX0003",
                  "Method": "card",
                  "NetAmount": 1.5,
                  "OrderId": "O-5140",
                  "pageidentifier": "null",
                  "ParentOrgName": "PropertyManager Pro",
                  "PaymentData": {
                    "paymentDetails": {
                      "totalAmount": 100
                    }
                  },
                  "PaymentTransId": "10-bfcd5a17861d4a8690ca53c142ca3810",
                  "PaypointDbaname": "Sunshine Gutters",
                  "PaypointEntryname": "d193cf9a46",
                  "PaypointLegalname": "Sunshine Services, LLC",
                  "Reason": "Testing",
                  "ReasonCode": "00001",
                  "ReferenceNumber": "10-bfcd5a17861d4a8690ca53c142ca3810",
                  "ReplyBy": "2022-07-11T15:00:01.000Z",
                  "Responses": "Responses",
                  "ScheduleReference": 0,
                  "Status": 3,
                  "Transaction": {
                    "EntrypageId": 0,
                    "FeeAmount": 1,
                    "PayorId": 1551,
                    "PaypointId": 226,
                    "SettlementStatus": 2,
                    "TotalAmount": 30.22,
                    "TransStatus": 1
                  },
                  "TransactionTime": "2024-01-15T09:30:00.000Z"
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
                    .WithPath("/Query/chargebacks/org/123")
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

        var response = await Client.Query.ListChargebacksOrgAsync(
            123,
            new ListChargebacksOrgRequest
            {
                FromRecord = 251,
                LimitRecord = 0,
                SortBy = "desc(field_name)",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<QueryChargebacksResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
