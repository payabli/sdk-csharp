using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.CaseManagement;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ValidateBankAccountChangeTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
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
              }
            }
            """;

        const string mockResponse = """
            {
              "isValid": true,
              "blockingConditions": [],
              "warnings": [
                "This paypoint has active batches. Consider scheduling the bank account change after the current batch is closed."
              ],
              "validationErrors": []
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/cases/bank-account/3040/validate")
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

        var response = await Client.CaseManagement.ValidateBankAccountChangeAsync(
            3040,
            new ValidateBankAccountChangeRequest
            {
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
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
