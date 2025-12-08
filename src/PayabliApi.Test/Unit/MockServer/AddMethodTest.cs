using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class AddMethodTest : BaseMockServerTest
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
                "customerId": 4400,
                "methodReferenceId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "referenceId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "resultCode": 1,
                "resultText": "Approved"
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/TokenStorage/add")
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

        var response = await Client.TokenStorage.AddMethodAsync(
            new AddMethodRequest
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
            Is.EqualTo(JsonUtils.Deserialize<AddMethodResponse>(mockResponse)).UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
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
                "customerId": null,
                "methodReferenceId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "referenceId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "resultCode": 1,
                "resultText": "Approved"
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/TokenStorage/add")
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

        var response = await Client.TokenStorage.AddMethodAsync(
            new AddMethodRequest
            {
                CreateAnonymous = true,
                Body = new RequestTokenStorage
                {
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
            Is.EqualTo(JsonUtils.Deserialize<AddMethodResponse>(mockResponse)).UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "f743aed24a",
              "fallbackAuth": true,
              "methodDescription": "Main card",
              "paymentMethod": {
                "method": "card",
                "tokenId": "c9700e93-b2ed-4b75-b1e4-ca4fb04fbe45-224"
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": {
                "customerId": 4440,
                "methodReferenceId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "referenceId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "resultCode": 1,
                "resultText": "Approved"
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/TokenStorage/add")
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

        var response = await Client.TokenStorage.AddMethodAsync(
            new AddMethodRequest
            {
                Body = new RequestTokenStorage
                {
                    CustomerData = new PayorDataRequest { CustomerId = 4440 },
                    EntryPoint = "f743aed24a",
                    FallbackAuth = true,
                    MethodDescription = "Main card",
                    PaymentMethod = new ConvertToken
                    {
                        Method = "card",
                        TokenId = "c9700e93-b2ed-4b75-b1e4-ca4fb04fbe45-224",
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<AddMethodResponse>(mockResponse)).UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
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
                "customerId": 4440,
                "methodReferenceId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "referenceId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "resultCode": 1,
                "resultText": "Approved"
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/TokenStorage/add")
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

        var response = await Client.TokenStorage.AddMethodAsync(
            new AddMethodRequest
            {
                AchValidation = true,
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
            Is.EqualTo(JsonUtils.Deserialize<AddMethodResponse>(mockResponse)).UsingDefaults()
        );
    }
}
