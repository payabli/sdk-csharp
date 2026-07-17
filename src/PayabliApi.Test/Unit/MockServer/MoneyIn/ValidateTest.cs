using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyIn;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ValidateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "entryPoint": "8cfec329267",
              "paymentMethod": {
                "method": "card",
                "cardnumber": "4360000001000005",
                "cardexp": "12/29",
                "cardzip": "14602-8328",
                "cardHolder": "Dianne Becker-Smith"
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": {
                "authCode": "",
                "referenceId": "",
                "resultCode": 1,
                "resultText": "Validated",
                "avsResponseText": "Zip code provided",
                "cvvResponseText": "",
                "customerId": 4440
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/validate")
                    .WithHeader("idempotencyKey", "6B29FC40-CA47-1067-B31D-00DD010662DA")
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

        var response = await Client.MoneyIn.ValidateAsync(
            new RequestPaymentValidate
            {
                IdempotencyKey = "6B29FC40-CA47-1067-B31D-00DD010662DA",
                EntryPoint = "8cfec329267",
                PaymentMethod = new RequestPaymentValidatePaymentMethod
                {
                    Method = RequestPaymentValidatePaymentMethodMethod.Card,
                    Cardnumber = "4360000001000005",
                    Cardexp = "12/29",
                    Cardzip = "14602-8328",
                    CardHolder = "Dianne Becker-Smith",
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
