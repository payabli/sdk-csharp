using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.GhostCard;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateGhostCardTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "vendorId": 456,
              "expenseLimit": 500,
              "amount": 500,
              "maxNumberOfUses": 3,
              "exactAmount": false,
              "expenseLimitPeriod": "monthly",
              "billingCycle": "monthly",
              "billingCycleDay": "1",
              "dailyTransactionCount": 5,
              "dailyAmountLimit": 200,
              "transactionAmountLimit": 100,
              "mcc": "5411",
              "tcc": "R",
              "misc1": "PO-98765",
              "misc2": "Dept-Finance"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "ReferenceId": "129-219",
                "ResultCode": 1,
                "ResultText": "Ghost Card created"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyOutCard/GhostCard/8cfec329267")
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

        var response = await Client.GhostCard.CreateGhostCardAsync(
            "8cfec329267",
            new CreateGhostCardRequestBody
            {
                VendorId = 456,
                ExpenseLimit = 500,
                Amount = 500,
                MaxNumberOfUses = 3,
                ExactAmount = false,
                ExpenseLimitPeriod = "monthly",
                BillingCycle = "monthly",
                BillingCycleDay = "1",
                DailyTransactionCount = 5,
                DailyAmountLimit = 200,
                TransactionAmountLimit = 100,
                Mcc = "5411",
                Tcc = "R",
                Misc1 = "PO-98765",
                Misc2 = "Dept-Finance",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
