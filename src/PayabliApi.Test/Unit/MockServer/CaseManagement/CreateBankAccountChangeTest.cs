using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.CaseManagement;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateBankAccountChangeTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "nickname": "Main Settlement Account",
              "bankName": "First National Bank",
              "routingNumber": "123456789",
              "accountNumber": "987654321",
              "accountType": "checking",
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
            }
            """;

        const string mockResponse = """
            {
              "uuid": "9c2b7e14-3a5f-4d21-b8e0-1f6a4c9d2e70",
              "state": "Submitted",
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
              "updatedAt": "2026-01-15T10:30:00.000Z",
              "createdBy": 0,
              "stateHistory": [],
              "attachments": [],
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
                    .WithPath("/v2/cases/bank-account/3040")
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

        var response = await Client.CaseManagement.CreateBankAccountChangeAsync(
            3040,
            new CreateBankAccountChangeCaseRequest
            {
                Nickname = "Main Settlement Account",
                BankName = "First National Bank",
                RoutingNumber = "123456789",
                AccountNumber = "987654321",
                AccountType = "checking",
                BankAccountHolderType = "business",
                BankAccountFunction = CaseManagementBankAccountFunction.Deposits,
                Services = new BankAccountServices
                {
                    MoneyIn = new List<MoneyInService>() { MoneyInService.Ach },
                    MoneyOut = new List<MoneyOutService>() { MoneyOutService.Ach },
                },
                Default = true,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
