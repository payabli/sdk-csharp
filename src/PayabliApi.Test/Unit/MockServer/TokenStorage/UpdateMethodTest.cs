using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.TokenStorage;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
              "entryPoint": "8cfec329267",
              "fallbackAuth": true,
              "paymentMethod": {
                "cardcvv": "123",
                "cardexp": "12/29",
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
                "referenceId": "129-219",
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
                    EntryPoint = "8cfec329267",
                    FallbackAuth = true,
                    PaymentMethod = new TokenizeCard
                    {
                        Cardcvv = "123",
                        Cardexp = "12/29",
                        CardHolder = "John Doe",
                        Cardnumber = "4111111111111111",
                        Cardzip = "12345",
                        Method = "card",
                    },
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
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "8cfec329267",
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
                "referenceId": "129-219",
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
                    EntryPoint = "8cfec329267",
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
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "8cfec329267",
              "paymentMethod": {
                "achAccount": "1111111111111",
                "achAccountType": "Checking",
                "achCode": "WEB",
                "achHolder": "John Doe",
                "achHolderType": "personal",
                "achRouting": "123456780",
                "method": "ach"
              },
              "vendorData": {
                "vendorId": 456
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": {
                "referenceId": "129-219",
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
                    EntryPoint = "8cfec329267",
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
                    VendorData = new VendorDataRequest { VendorId = 456 },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
