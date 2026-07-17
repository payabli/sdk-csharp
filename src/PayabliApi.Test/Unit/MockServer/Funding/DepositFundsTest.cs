using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Funding;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DepositFundsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "amount": 10,
              "entrypoint": "48acde49",
              "accountId": "333"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Funding/depositFunds")
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

        var response = await Client.Funding.DepositFundsAsync(
            new DepositFundsRequest
            {
                Amount = 10,
                Entrypoint = "48acde49",
                AccountId = "333",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
