using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyIn;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
                "authCode": "VTLMC1",
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Approved",
                "avsResponseText": "Exact match, Street address and 5-digit ZIP code both match",
                "cvvResponseText": "Not processed. Indicates that the expiration date was not provided with the request, or that the card does not have a valid CVV2 code. If the expiration date was not included with the request, resubmit the request with the expiration date.",
                "customerId": 4440
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

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
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
              "responseData": {
                "authCode": "AuthCode",
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Approved",
                "avsResponseText": "No address or ZIP match only",
                "cvvResponseText": "CVV2/CVC2 no match",
                "customerId": 4440,
                "methodReferenceId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440"
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
                    EntryPoint = "8cfec329267",
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
              "responseData": {
                "authCode": "AuthCode",
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Approved",
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
                    EntryPoint = "8cfec329267",
                    Ipaddress = "255.255.255.255",
                    PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
                    PaymentMethod = new PayMethodCloud
                    {
                        Device = "6c361c7d-674c-44cc-b790-382b75d1xxx",
                        Method = PayMethodCloudMethod.Cloud,
                        SaveIfSuccess = true,
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
              "responseData": {
                "authCode": "123456",
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Approved",
                "avsResponseText": "",
                "cvvResponseText": "",
                "customerId": 4440
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
                    EntryPoint = "8cfec329267",
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
                        Method = PayMethodAchMethod.Ach,
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
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "8cfec329267",
              "ipaddress": "255.255.255.255",
              "paymentDetails": {
                "checkUniqueId": "abc123def456",
                "serviceFee": 0,
                "totalAmount": 125.5
              },
              "paymentMethod": {
                "achAccount": "123456",
                "achAccountType": "Checking",
                "achCode": "BOC",
                "achHolder": "John Doe",
                "achRouting": "123456789",
                "method": "ach"
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
                "resultText": "Approved",
                "avsResponseText": "",
                "cvvResponseText": "",
                "customerId": 4440
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
                    EntryPoint = "8cfec329267",
                    Ipaddress = "255.255.255.255",
                    PaymentDetails = new PaymentDetail
                    {
                        CheckUniqueId = "abc123def456",
                        ServiceFee = 0,
                        TotalAmount = 125.5,
                    },
                    PaymentMethod = new PayMethodAch
                    {
                        AchAccount = "123456",
                        AchAccountType = Achaccounttype.Checking,
                        AchCode = "BOC",
                        AchHolder = "John Doe",
                        AchRouting = "123456789",
                        Method = PayMethodAchMethod.Ach,
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_6()
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
                "customerNumber": "C-90010",
                "firstName": "John",
                "lastName": "Cassian"
              },
              "entryPoint": "8cfec329267",
              "ipaddress": "255.255.255.255",
              "orderDescription": "New customer package",
              "orderId": "982-102",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 1000
              },
              "paymentMethod": {
                "cardcvv": "123",
                "cardexp": "12/29",
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
              "responseData": {
                "authCode": "AuthCode",
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Approved",
                "avsResponseText": "Exact match, Street address and 5-digit ZIP code both match",
                "cvvResponseText": "CVV2/CVC2 match",
                "customerId": 4440,
                "methodReferenceId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440"
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
                        CustomerNumber = "C-90010",
                        FirstName = "John",
                        LastName = "Cassian",
                    },
                    EntryPoint = "8cfec329267",
                    Ipaddress = "255.255.255.255",
                    OrderDescription = "New customer package",
                    OrderId = "982-102",
                    PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 1000 },
                    PaymentMethod = new PayMethodCredit
                    {
                        Cardcvv = "123",
                        Cardexp = "12/29",
                        CardHolder = "John Cassian",
                        Cardnumber = "4111111111111111",
                        Cardzip = "12345",
                        Initiator = "payor",
                        Method = PayMethodCreditMethod.Card,
                        SaveIfSuccess = true,
                    },
                    Source = "web",
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_7()
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
              "responseData": {
                "authCode": "VTLMC1",
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Approved",
                "avsResponseText": " ",
                "cvvResponseText": "CVV2/CVC2 match",
                "customerId": 4440
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
                    EntryPoint = "8cfec329267",
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
                        Method = PayMethodCreditMethod.Card,
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_8()
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
              "responseText": "Declined",
              "isSuccess": false,
              "responseData": {
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "200: Transaction was declined by processor.. DECLINE",
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
