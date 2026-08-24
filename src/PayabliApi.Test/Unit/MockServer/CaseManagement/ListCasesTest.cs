using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.CaseManagement;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListCasesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "summary": {
                "totalRecords": 1,
                "totalAmount": 0,
                "totalNetAmount": 0,
                "totalPages": 1,
                "pageSize": 20
              },
              "records": [
                {
                  "uuid": "9c2b7e14-3a5f-4d21-b8e0-1f6a4c9d2e70",
                  "state": "PendingCompletion",
                  "caseType": "BankAccountChange",
                  "parameters": {
                    "type": "BankAccountChange",
                    "nickname": "Main Settlement Account",
                    "bankName": "First National Bank",
                    "bankToken": "bnk_2b1c9e40f5a34c9a8f219e7c6b1a2d34",
                    "accountType": "Checking",
                    "bankAccountHolderName": "Gruzya Adventure Outfitters LLC",
                    "bankAccountHolderType": "business",
                    "bankAccountFunction": "Deposits",
                    "services": {
                      "moneyIn": [
                        "Ach"
                      ],
                      "moneyOut": [
                        "Ach"
                      ]
                    },
                    "default": true
                  },
                  "orgId": 123,
                  "paypointId": 3040,
                  "createdAt": "2026-01-15T10:30:00.000Z",
                  "updatedAt": "2026-01-15T10:30:43.000Z",
                  "createdBy": 0,
                  "stateHistory": [],
                  "attachments": [],
                  "roomId": 96369,
                  "org": {
                    "id": 123,
                    "name": "Example Partner Org"
                  },
                  "paypoint": {
                    "id": 3040,
                    "name": "Gruzya Adventure Outfitters"
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/cases/organization/123")
                    .WithParam("fromRecord", "0")
                    .WithParam("limitRecord", "20")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CaseManagement.ListCasesAsync(
            123,
            new ListCasesCaseManagementRequest { FromRecord = 0, LimitRecord = 20 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
