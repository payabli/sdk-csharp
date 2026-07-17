using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyOut;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ReissueOutTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "paymentMethod": {
                "method": "ach",
                "achAccount": "9876543210",
                "achAccountType": "savings",
                "achRouting": "021000021",
                "achHolder": "Acme Corp",
                "achHolderType": "business"
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseText": "Success",
              "responseData": {
                "transactionId": "130-220",
                "status": "Authorized",
                "originalTransactionId": "129-219"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyOut/reissue")
                    .WithParam("transId", "129-219")
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

        var response = await Client.MoneyOut.ReissueOutAsync(
            new ReissueOutRequest
            {
                TransId = "129-219",
                PaymentMethod = new ReissuePaymentMethod
                {
                    Method = "ach",
                    AchAccount = "9876543210",
                    AchAccountType = "savings",
                    AchRouting = "021000021",
                    AchHolder = "Acme Corp",
                    AchHolderType = AchHolderType.Business,
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "paymentMethod": {
                "method": "check"
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseText": "Success",
              "responseData": {
                "transactionId": "130-221",
                "status": "Authorized",
                "originalTransactionId": "129-219"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyOut/reissue")
                    .WithParam("transId", "129-219")
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

        var response = await Client.MoneyOut.ReissueOutAsync(
            new ReissueOutRequest
            {
                TransId = "129-219",
                PaymentMethod = new ReissuePaymentMethod { Method = "check" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "paymentMethod": {
                "method": "vcard"
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseText": "Success",
              "responseData": {
                "transactionId": "130-222",
                "status": "Authorized",
                "originalTransactionId": "129-219"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyOut/reissue")
                    .WithParam("transId", "129-219")
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

        var response = await Client.MoneyOut.ReissueOutAsync(
            new ReissueOutRequest
            {
                TransId = "129-219",
                PaymentMethod = new ReissuePaymentMethod { Method = "vcard" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
