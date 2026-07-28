using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.CaseManagement;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetCaseTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
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
              "stateHistory": [
                {
                  "uuid": "019f806f-453f-701c-b77d-cb585b743bef",
                  "caseUuid": "9c2b7e14-3a5f-4d21-b8e0-1f6a4c9d2e70",
                  "fromState": "Submitted",
                  "toState": "Verifying",
                  "reason": "Background verification started",
                  "createdAt": "2026-01-15T10:30:03.000Z"
                },
                {
                  "uuid": "019f806f-e00e-73d2-b6a4-9dd5b540e11e",
                  "caseUuid": "9c2b7e14-3a5f-4d21-b8e0-1f6a4c9d2e70",
                  "fromState": "Verifying",
                  "toState": "AutoApproved",
                  "reason": "Polling outcome: approved",
                  "createdAt": "2026-01-15T10:30:43.000Z"
                },
                {
                  "uuid": "019f806f-e015-730b-be18-ec695f42f133",
                  "caseUuid": "9c2b7e14-3a5f-4d21-b8e0-1f6a4c9d2e70",
                  "fromState": "AutoApproved",
                  "toState": "PendingCompletion",
                  "reason": "funding hold acquired",
                  "createdAt": "2026-01-15T10:30:43.000Z"
                }
              ],
              "attachments": [],
              "roomId": 96369,
              "metadata": {
                "verification": {
                  "verificationResult": {
                    "code": 6,
                    "name": "Pass",
                    "description": "The suggested action is to accept the bank account and/or customer data for this inquiry."
                  },
                  "accountResponseCode": {
                    "code": 12,
                    "name": "_1111",
                    "description": "Account Verified – The account was found to be an open and valid checking account."
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
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/cases/9c2b7e14-3a5f-4d21-b8e0-1f6a4c9d2e70")
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

        var response = await Client.CaseManagement.GetCaseAsync(
            "9c2b7e14-3a5f-4d21-b8e0-1f6a4c9d2e70"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
