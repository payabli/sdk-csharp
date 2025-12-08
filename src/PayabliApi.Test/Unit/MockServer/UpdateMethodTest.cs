using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class UpdateMethodTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "f743aed24a",
              "fallbackAuth": true,
              "paymentMethod": {
                "cardcvv": "123",
                "cardexp": "02/25",
                "cardHolder": "John Doe",
                "cardnumber": "4111111111111111",
                "cardzip": "12345",
                "method": "card"
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": {
                "referenceId": "1b502b79-e319-4159-8c29-a9f8d9f105c8-1323",
                "resultCode": 1,
                "resultText": "Updated"
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/TokenStorage/32-8877drt00045632-678")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.TokenStorage.UpdateMethodAsync(
            "32-8877drt00045632-678",
            new UpdateMethodRequest
            {
                Body = new RequestTokenStorage
                {
                    CustomerData = new PayorDataRequest { CustomerId = 4440 },
                    EntryPoint = "f743aed24a",
                    FallbackAuth = true,
                    PaymentMethod = new TokenizeCard
                    {
                        Cardcvv = "123",
                        Cardexp = "02/25",
                        CardHolder = "John Doe",
                        Cardnumber = "4111111111111111",
                        Cardzip = "12345",
                        Method = "card",
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponsePaymethodDelete>(mockResponse))
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "f743aed24a",
              "paymentMethod": {
                "achAccount": "1111111111111",
                "achAccountType": "Checking",
                "achCode": "WEB",
                "achHolder": "John Doe",
                "achHolderType": "personal",
                "achRouting": "123456780",
                "method": "ach"
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": {
                "referenceId": "1b502b79-e319-4159-8c29-a9f8d9f105c8-1323",
                "resultCode": 1,
                "resultText": "Updated"
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/TokenStorage/32-8877drt00045632-678")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.TokenStorage.UpdateMethodAsync(
            "32-8877drt00045632-678",
            new UpdateMethodRequest
            {
                Body = new RequestTokenStorage
                {
                    CustomerData = new PayorDataRequest { CustomerId = 4440 },
                    EntryPoint = "f743aed24a",
                    PaymentMethod = new TokenizeAch
                    {
                        AchAccount = "1111111111111",
                        AchAccountType = Achaccounttype.Checking,
                        AchCode = "WEB",
                        AchHolder = "John Doe",
                        AchHolderType = AchHolderType.Personal,
                        AchRouting = "123456780",
                        Method = "ach",
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponsePaymethodDelete>(mockResponse))
                .UsingDefaults()
        );
    }
}
