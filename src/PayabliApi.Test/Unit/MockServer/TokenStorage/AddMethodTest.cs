using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.TokenStorage;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
              "entryPoint": "8cfec329267",
              "fallbackAuth": true,
              "fallbackAuthAmount": 100,
              "methodDescription": "Primary Visa card",
              "paymentMethod": {
                "cardcvv": "123",
                "cardexp": "12/29",
                "cardHolder": "John Doe",
                "cardnumber": "4111111111111111",
                "cardzip": "12345",
                "method": "card"
              },
              "source": "api"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": {
                "customerId": 4440,
                "methodReferenceId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "referenceId": "129-219",
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
                    EntryPoint = "8cfec329267",
                    FallbackAuth = true,
                    FallbackAuthAmount = 100,
                    MethodDescription = "Primary Visa card",
                    PaymentMethod = new TokenizeCard
                    {
                        Cardcvv = "123",
                        Cardexp = "12/29",
                        CardHolder = "John Doe",
                        Cardnumber = "4111111111111111",
                        Cardzip = "12345",
                        Method = "card",
                    },
                    Source = "api",
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
                "methodReferenceId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "referenceId": "129-219",
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
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "8cfec329267",
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
                "referenceId": "129-219",
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
                    EntryPoint = "8cfec329267",
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
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
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
                "customerId": 4440,
                "methodReferenceId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "referenceId": "129-219",
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
    public async Task MockServerTest_5()
    {
        const string requestJson = """
            {
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
                "customerId": 4440,
                "methodReferenceId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "referenceId": "129-219",
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
