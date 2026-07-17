using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Query;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListVcardsTransactionsOrgTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Summary": {
                "totalPages": 20,
                "totalRecords": 393,
                "totalAmount": 231.58,
                "totalactive": 388,
                "totalamountactive": 219.58,
                "totalbalanceactive": -213.83
              },
              "Records": [
                {
                  "Identifier": "7HQ2P9B4XD",
                  "CardToken": "5RJ8MN2KC4",
                  "LastFour": "1234",
                  "ExpirationDate": "06-30-2029",
                  "Mcc": "5943",
                  "PayoutId": 84210,
                  "CustomerId": 4440,
                  "VendorId": 456,
                  "MiscData1": "Invoice #12345",
                  "MiscData2": "Project: Office Supplies",
                  "CurrentUses": 1,
                  "Amount": 500,
                  "Balance": 425.5,
                  "PaypointId": 3040,
                  "PaypointLegal": "Global Factory LLC",
                  "PaypointDba": "Global Factory",
                  "ExternalPaypointID": "pay-10",
                  "OrgName": "SupplyPro",
                  "Type": "AUTHORIZATION",
                  "Status": "AUTHORIZATION",
                  "CreatedOn": "2026-05-05 03:28:53.082830",
                  "TransactionAmount": "74.500",
                  "PostedAmount": "0.000",
                  "MerchantName": "Office Supply Co.",
                  "AuthorizationStatus": "AUTHORIZATION"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Query/vcardsTransactions/org/123")
                    .WithParam("fromRecord", "0")
                    .WithParam("limitRecord", "20")
                    .WithParam("sortBy", "desc(CreatedOn)")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Query.ListVcardsTransactionsOrgAsync(
            123,
            new ListVcardsTransactionsOrgRequest
            {
                FromRecord = 0,
                LimitRecord = 20,
                SortBy = "desc(CreatedOn)",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
