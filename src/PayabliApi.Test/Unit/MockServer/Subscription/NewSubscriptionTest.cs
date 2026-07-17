using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Subscription;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class NewSubscriptionTest : BaseMockServerTest
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
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100
              },
              "paymentMethod": {
                "cardcvv": "123",
                "cardexp": "12/29",
                "cardHolder": "John Cassian",
                "cardnumber": "4111111111111111",
                "cardzip": "37615",
                "initiator": "payor",
                "method": "card"
              },
              "scheduleDetails": {
                "endDate": "2025-03-20",
                "frequency": "weekly",
                "planId": 1,
                "startDate": "2024-09-20"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "responseData": 396,
              "customerId": 4440
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Subscription/add")
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

        var response = await Client.Subscription.NewSubscriptionAsync(
            new RequestSchedule
            {
                CustomerData = new PayorDataRequest { CustomerId = 4440 },
                EntryPoint = "8cfec329267",
                PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
                PaymentMethod = new PayMethodCredit
                {
                    Cardcvv = "123",
                    Cardexp = "12/29",
                    CardHolder = "John Cassian",
                    Cardnumber = "4111111111111111",
                    Cardzip = "37615",
                    Initiator = "payor",
                    Method = PayMethodCreditMethod.Card,
                },
                ScheduleDetails = new ScheduleDetail
                {
                    EndDate = "2025-03-20",
                    Frequency = Frequency.Weekly,
                    PlanId = 1,
                    StartDate = "2024-09-20",
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
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100
              },
              "paymentMethod": {
                "achAccount": "3453445666",
                "achAccountType": "Checking",
                "achCode": "PPD",
                "achHolder": "John Cassian",
                "achHolderType": "personal",
                "achRouting": "021000021",
                "method": "ach"
              },
              "scheduleDetails": {
                "endDate": "2025-03-20",
                "frequency": "weekly",
                "planId": 1,
                "startDate": "2024-09-20"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "responseData": 396,
              "customerId": 4440
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Subscription/add")
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

        var response = await Client.Subscription.NewSubscriptionAsync(
            new RequestSchedule
            {
                CustomerData = new PayorDataRequest { CustomerId = 4440 },
                EntryPoint = "8cfec329267",
                PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
                PaymentMethod = new PayMethodAch
                {
                    AchAccount = "3453445666",
                    AchAccountType = Achaccounttype.Checking,
                    AchCode = "PPD",
                    AchHolder = "John Cassian",
                    AchHolderType = AchHolderType.Personal,
                    AchRouting = "021000021",
                    Method = PayMethodAchMethod.Ach,
                },
                ScheduleDetails = new ScheduleDetail
                {
                    EndDate = "2025-03-20",
                    Frequency = Frequency.Weekly,
                    PlanId = 1,
                    StartDate = "2024-09-20",
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
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100
              },
              "paymentMethod": {
                "initiator": "merchant",
                "storedMethodId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "storedMethodUsageType": "recurring"
              },
              "scheduleDetails": {
                "endDate": "2025-03-20",
                "frequency": "weekly",
                "planId": 1,
                "startDate": "2024-09-20"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "responseData": 396,
              "customerId": 4440
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Subscription/add")
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

        var response = await Client.Subscription.NewSubscriptionAsync(
            new RequestSchedule
            {
                CustomerData = new PayorDataRequest { CustomerId = 4440 },
                EntryPoint = "8cfec329267",
                PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
                PaymentMethod = new RequestSchedulePaymentMethodInitiator
                {
                    Initiator = "merchant",
                    StoredMethodId = "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                    StoredMethodUsageType = "recurring",
                },
                ScheduleDetails = new ScheduleDetail
                {
                    EndDate = "2025-03-20",
                    Frequency = Frequency.Weekly,
                    PlanId = 1,
                    StartDate = "2024-09-20",
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
              "subscriptionType": "BalanceDriven",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100
              },
              "paymentMethod": {
                "cardcvv": "123",
                "cardexp": "12/29",
                "cardHolder": "John Cassian",
                "cardnumber": "4111111111111111",
                "cardzip": "37615",
                "initiator": "payor",
                "method": "card"
              },
              "scheduleDetails": {
                "frequency": "endofmonth"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "responseData": 396,
              "customerId": 4440
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Subscription/add")
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

        var response = await Client.Subscription.NewSubscriptionAsync(
            new RequestSchedule
            {
                CustomerData = new PayorDataRequest { CustomerId = 4440 },
                EntryPoint = "8cfec329267",
                SubscriptionType = SubscriptionType.BalanceDriven,
                PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
                PaymentMethod = new PayMethodCredit
                {
                    Cardcvv = "123",
                    Cardexp = "12/29",
                    CardHolder = "John Cassian",
                    Cardnumber = "4111111111111111",
                    Cardzip = "37615",
                    Initiator = "payor",
                    Method = PayMethodCreditMethod.Card,
                },
                ScheduleDetails = new ScheduleDetail { Frequency = Frequency.EndOfMonth },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
