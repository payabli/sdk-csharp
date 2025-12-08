using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class CreditTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "customerData": {
                "billingAddress1": "5127 Linkwood ave",
                "customerNumber": "100"
              },
              "entrypoint": "my-entrypoint",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 1
              },
              "paymentMethod": {
                "achAccount": "88354454",
                "achAccountType": "Checking",
                "achHolder": "John Smith",
                "achRouting": "021000021",
                "method": "ach"
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "pageIdentifier": "null",
              "responseData": {
                "AuthCode": "AuthCode",
                "CustomerId": 4440,
                "methodReferenceId": null,
                "ReferenceId": "45-erre-324",
                "ResultCode": 1,
                "ResultText": "Approved"
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/makecredit")
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

        var response = await Client.MoneyIn.CreditAsync(
            new RequestCredit
            {
                IdempotencyKey = "6B29FC40-CA47-1067-B31D-00DD010662DA",
                CustomerData = new PayorDataRequest
                {
                    BillingAddress1 = "5127 Linkwood ave",
                    CustomerNumber = "100",
                },
                Entrypoint = "my-entrypoint",
                PaymentDetails = new PaymentDetailCredit { ServiceFee = 0, TotalAmount = 1 },
                PaymentMethod = new RequestCreditPaymentMethod
                {
                    AchAccount = "88354454",
                    AchAccountType = Achaccounttype.Checking,
                    AchHolder = "John Smith",
                    AchRouting = "021000021",
                    Method = "ach",
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponse0>(mockResponse)).UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "customerData": {
                "billingAddress1": "125 Main Street",
                "billingCity": "Kingsport",
                "billingEmail": "johnnyp@email.com",
                "company": "Acme, Inc",
                "customerNumber": "100",
                "firstName": "Johnny",
                "lastName": "Poulsbo"
              },
              "entrypoint": "my-entrypoint",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 1
              },
              "paymentMethod": {
                "achAccount": "88354554",
                "achAccountType": "Checking",
                "achHolder": "John Poulsbo",
                "achRouting": "029000021",
                "method": "ach"
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "pageIdentifier": "null",
              "responseData": {
                "AuthCode": "AuthCode",
                "CustomerId": 4440,
                "methodReferenceId": null,
                "ReferenceId": "45-erre-324",
                "ResultCode": 1,
                "ResultText": "Approved"
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/makecredit")
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

        var response = await Client.MoneyIn.CreditAsync(
            new RequestCredit
            {
                IdempotencyKey = "6B29FC40-CA47-1067-B31D-00DD010662DA",
                CustomerData = new PayorDataRequest
                {
                    BillingAddress1 = "125 Main Street",
                    BillingCity = "Kingsport",
                    BillingEmail = "johnnyp@email.com",
                    Company = "Acme, Inc",
                    CustomerNumber = "100",
                    FirstName = "Johnny",
                    LastName = "Poulsbo",
                },
                Entrypoint = "my-entrypoint",
                PaymentDetails = new PaymentDetailCredit { ServiceFee = 0, TotalAmount = 1 },
                PaymentMethod = new RequestCreditPaymentMethod
                {
                    AchAccount = "88354554",
                    AchAccountType = Achaccounttype.Checking,
                    AchHolder = "John Poulsbo",
                    AchRouting = "029000021",
                    Method = "ach",
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponse0>(mockResponse)).UsingDefaults()
        );
    }
}
