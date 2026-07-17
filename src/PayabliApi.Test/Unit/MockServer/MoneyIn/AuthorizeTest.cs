using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyIn;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AuthorizeTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "8cfec329267",
              "ipaddress": "255.255.255.255",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100
              },
              "paymentMethod": {
                "cardcvv": "999",
                "cardexp": "02/27",
                "cardHolder": "John Cassian",
                "cardnumber": "4111111111111111",
                "cardzip": "12345",
                "initiator": "payor",
                "method": "card"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "responseData": {
                "authCode": "123456",
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Authorized",
                "avsResponseText": "No address or ZIP match only",
                "cvvResponseText": "CVV2/CVC2 no match",
                "customerId": 4440
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/authorize")
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

        var response = await Client.MoneyIn.AuthorizeAsync(
            new RequestPaymentAuthorize
            {
                Body = new TransRequestBody
                {
                    CustomerData = new PayorDataRequest { CustomerId = 4440 },
                    EntryPoint = "8cfec329267",
                    Ipaddress = "255.255.255.255",
                    PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
                    PaymentMethod = new PayMethodCredit
                    {
                        Cardcvv = "999",
                        Cardexp = "02/27",
                        CardHolder = "John Cassian",
                        Cardnumber = "4111111111111111",
                        Cardzip = "12345",
                        Initiator = "payor",
                        Method = PayMethodCreditMethod.Card,
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
