using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class GetpaidTest : BaseMockServerTest
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
              "pageIdentifier": null,
              "responseData": {
                "authCode": "VTLMC1",
                "referenceId": "575-c490247af7ed403d86ba583507be61b0",
                "resultCode": 1,
                "resultText": "Approved",
                "avsResponseText": "Exact match, Street address and 5-digit ZIP code both match",
                "cvvResponseText": "Not processed. Indicates that the expiration date was not provided with the request, or that the card does not have a valid CVV2 code. If the expiration date was not included with the request, resubmit the request with the expiration date.",
                "customerId": 41892,
                "methodReferenceId": null
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/getpaid")
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

        var response = await Client.MoneyIn.GetpaidAsync(
            new RequestPayment
            {
                Body = new TransRequestBody
                {
                    CustomerData = new PayorDataRequest { CustomerId = 4440 },
                    EntryPoint = "f743aed24a",
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
                        Method = "card",
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponseGetPaid>(mockResponse))
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
              "ipaddress": "255.255.255.255",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100
              },
              "paymentMethod": {
                "initiator": "payor",
                "method": "card",
                "storedMethodId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "storedMethodUsageType": "unscheduled"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "pageIdentifier": null,
              "responseData": {
                "authCode": "AuthCode",
                "referenceId": "45-erre-324",
                "resultCode": 1,
                "resultText": "Approved",
                "avsResponseText": "No address or ZIP match only",
                "cvvResponseText": "CVV2/CVC2 no match",
                "customerId": 4440,
                "methodReferenceId": "1ed73d3c67-4076-8f8c-9f26317762ef"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/getpaid")
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

        var response = await Client.MoneyIn.GetpaidAsync(
            new RequestPayment
            {
                Body = new TransRequestBody
                {
                    CustomerData = new PayorDataRequest { CustomerId = 4440 },
                    EntryPoint = "f743aed24a",
                    Ipaddress = "255.255.255.255",
                    PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
                    PaymentMethod = new PayMethodStoredMethod
                    {
                        Initiator = "payor",
                        Method = PayMethodStoredMethodMethod.Card,
                        StoredMethodId = "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                        StoredMethodUsageType = "unscheduled",
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponseGetPaid>(mockResponse))
                .UsingDefaults()
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
              "ipaddress": "255.255.255.255",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100
              },
              "paymentMethod": {
                "device": "6c361c7d-674c-44cc-b790-382b75d1xxx",
                "method": "cloud",
                "saveIfSuccess": true
              }
            }
            """;

        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "pageIdentifier": null,
              "responseData": {
                "authCode": "AuthCode",
                "referenceId": "45-erre-324",
                "resultCode": 1,
                "resultText": "Approved",
                "avsResponseText": "No address or ZIP match only",
                "cvvResponseText": "CVV2/CVC2 no match",
                "customerId": 4440,
                "methodReferenceId": null
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/getpaid")
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

        var response = await Client.MoneyIn.GetpaidAsync(
            new RequestPayment
            {
                Body = new TransRequestBody
                {
                    CustomerData = new PayorDataRequest { CustomerId = 4440 },
                    EntryPoint = "f743aed24a",
                    Ipaddress = "255.255.255.255",
                    PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
                    PaymentMethod = new PayMethodCloud
                    {
                        Device = "6c361c7d-674c-44cc-b790-382b75d1xxx",
                        Method = "cloud",
                        SaveIfSuccess = true,
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponseGetPaid>(mockResponse))
                .UsingDefaults()
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
              "ipaddress": "255.255.255.255",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100
              },
              "paymentMethod": {
                "achAccount": "123123123",
                "achAccountType": "Checking",
                "achCode": "WEB",
                "achHolder": "John Cassian",
                "achHolderType": "personal",
                "achRouting": "123123123",
                "method": "ach"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "pageIdentifier": null,
              "responseData": {
                "authCode": "123456",
                "referenceId": "132-d9719a411918429cb7ca465927969900",
                "resultCode": 1,
                "resultText": "Approved",
                "avsResponseText": "",
                "cvvResponseText": "",
                "customerId": 545,
                "methodReferenceId": null
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/getpaid")
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

        var response = await Client.MoneyIn.GetpaidAsync(
            new RequestPayment
            {
                Body = new TransRequestBody
                {
                    CustomerData = new PayorDataRequest { CustomerId = 4440 },
                    EntryPoint = "f743aed24a",
                    Ipaddress = "255.255.255.255",
                    PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
                    PaymentMethod = new PayMethodAch
                    {
                        AchAccount = "123123123",
                        AchAccountType = Achaccounttype.Checking,
                        AchCode = "WEB",
                        AchHolder = "John Cassian",
                        AchHolderType = AchHolderType.Personal,
                        AchRouting = "123123123",
                        Method = "ach",
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponseGetPaid>(mockResponse))
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_5()
    {
        const string requestJson = """
            {
              "customerData": {
                "billingAddress1": "123 Walnut Street",
                "billingCity": "Johnson City",
                "billingCountry": "US",
                "billingEmail": "john@email.com",
                "billingPhone": "1234567890",
                "billingState": "Johnson City",
                "billingZip": "37615",
                "customerNumber": "3456-7645A",
                "firstName": "John",
                "lastName": "Cassian"
              },
              "entryPoint": "f743aed24a",
              "ipaddress": "255.255.255.255",
              "orderDescription": "New customer package",
              "orderId": "982-102",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 1000
              },
              "paymentMethod": {
                "cardcvv": "123",
                "cardexp": "02/25",
                "cardHolder": "John Cassian",
                "cardnumber": "4111111111111111",
                "cardzip": "12345",
                "initiator": "payor",
                "method": "card",
                "saveIfSuccess": true
              },
              "source": "web"
            }
            """;

        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "pageIdentifier": null,
              "responseData": {
                "authCode": "AuthCode",
                "referenceId": "45-erre-324",
                "resultCode": 1,
                "resultText": "Approved",
                "avsResponseText": "Exact match, Street address and 5-digit ZIP code both match",
                "cvvResponseText": "CVV2/CVC2 match",
                "customerId": 4440,
                "methodReferenceId": "1ed73d3c67-4076-8f8c-9f26317762ef"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/getpaid")
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

        var response = await Client.MoneyIn.GetpaidAsync(
            new RequestPayment
            {
                Body = new TransRequestBody
                {
                    CustomerData = new PayorDataRequest
                    {
                        BillingAddress1 = "123 Walnut Street",
                        BillingCity = "Johnson City",
                        BillingCountry = "US",
                        BillingEmail = "john@email.com",
                        BillingPhone = "1234567890",
                        BillingState = "Johnson City",
                        BillingZip = "37615",
                        CustomerNumber = "3456-7645A",
                        FirstName = "John",
                        LastName = "Cassian",
                    },
                    EntryPoint = "f743aed24a",
                    Ipaddress = "255.255.255.255",
                    OrderDescription = "New customer package",
                    OrderId = "982-102",
                    PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 1000 },
                    PaymentMethod = new PayMethodCredit
                    {
                        Cardcvv = "123",
                        Cardexp = "02/25",
                        CardHolder = "John Cassian",
                        Cardnumber = "4111111111111111",
                        Cardzip = "12345",
                        Initiator = "payor",
                        Method = "card",
                        SaveIfSuccess = true,
                    },
                    Source = "web",
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponseGetPaid>(mockResponse))
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_6()
    {
        const string requestJson = """
            {
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "f743aed24a",
              "ipaddress": "255.255.255.255",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100,
                "currency": "CAD"
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
              "pageIdentifier": null,
              "responseData": {
                "authCode": "VTLMC1",
                "referenceId": "575-c490247af7ed403d86ba583507be61b0",
                "resultCode": 1,
                "resultText": "Approved",
                "avsResponseText": " ",
                "cvvResponseText": "CVV2/CVC2 match",
                "customerId": 41892,
                "methodReferenceId": null
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/getpaid")
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

        var response = await Client.MoneyIn.GetpaidAsync(
            new RequestPayment
            {
                Body = new TransRequestBody
                {
                    CustomerData = new PayorDataRequest { CustomerId = 4440 },
                    EntryPoint = "f743aed24a",
                    Ipaddress = "255.255.255.255",
                    PaymentDetails = new PaymentDetail
                    {
                        ServiceFee = 0,
                        TotalAmount = 100,
                        Currency = "CAD",
                    },
                    PaymentMethod = new PayMethodCredit
                    {
                        Cardcvv = "999",
                        Cardexp = "02/27",
                        CardHolder = "John Cassian",
                        Cardnumber = "4111111111111111",
                        Cardzip = "12345",
                        Initiator = "payor",
                        Method = "card",
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponseGetPaid>(mockResponse))
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_7()
    {
        const string requestJson = """
            {
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "f743aed24a",
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
              "responseText": "Declined",
              "isSuccess": false,
              "pageIdentifier": null,
              "responseData": {
                "authCode": null,
                "referenceId": "45-erre-324",
                "resultCode": 1,
                "resultText": "200: Transaction was declined by processor.. DECLINE",
                "avsResponseText": "No address or ZIP match only",
                "cvvResponseText": "CVV2/CVC2 no match",
                "customerId": 4440,
                "methodReferenceId": null
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/getpaid")
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

        var response = await Client.MoneyIn.GetpaidAsync(
            new RequestPayment
            {
                Body = new TransRequestBody
                {
                    CustomerData = new PayorDataRequest { CustomerId = 4440 },
                    EntryPoint = "f743aed24a",
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
                        Method = "card",
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponseGetPaid>(mockResponse))
                .UsingDefaults()
        );
    }
}
