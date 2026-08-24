using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.CaseManagement;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AssignCaseTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "assigneeId": 4238,
              "reason": "Routing to the risk team for review."
            }
            """;

        const string mockResponse = """
            {
              "uuid": "9c2b7e14-3a5f-4d21-b8e0-1f6a4c9d2e70",
              "state": "Assigned",
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
              "updatedAt": "2026-01-15T11:40:00.000Z",
              "createdBy": 0,
              "assigneeId": 4238,
              "stateHistory": [
                {
                  "uuid": "019f80f0-2b3c-74d5-8e6f-7a8b9c0d1e2f",
                  "caseUuid": "9c2b7e14-3a5f-4d21-b8e0-1f6a4c9d2e70",
                  "fromState": "PendingReview",
                  "toState": "Assigned",
                  "ipAddress": "203.0.113.10",
                  "triggeredBy": 4110,
                  "reason": "Routing to the risk team for review.",
                  "createdAt": "2026-01-15T11:40:00.000Z",
                  "triggeredByUser": {
                    "id": 4110,
                    "name": "Alex Chen"
                  }
                }
              ],
              "attachments": [],
              "roomId": 96370,
              "metadata": {
                "verification": {
                  "verificationResult": {
                    "code": 5,
                    "name": "RiskAlert",
                    "description": "The suggested action is to further investigate the bank account and/or customer data for this inquiry due to a risk alert ."
                  },
                  "accountResponseCode": {
                    "code": 12,
                    "name": "_1111",
                    "description": "Account Verified – The account was found to be an open and valid checking account."
                  },
                  "customerResponseCode": {
                    "code": 3,
                    "name": "CA21",
                    "description": "The customer or business name data did not match gAuthenticate data."
                  }
                }
              },
              "org": {
                "id": 123,
                "name": "Example Partner Org"
              },
              "paypoint": {
                "id": 3040,
                "name": "Gruzya Adventure Outfitters"
              },
              "assignee": {
                "id": 4238,
                "name": "Jordan Rivera"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/cases/9c2b7e14-3a5f-4d21-b8e0-1f6a4c9d2e70/assign")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CaseManagement.AssignCaseAsync(
            "9c2b7e14-3a5f-4d21-b8e0-1f6a4c9d2e70",
            new AssignCaseRequest
            {
                AssigneeId = 4238,
                Reason = "Routing to the risk team for review.",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
