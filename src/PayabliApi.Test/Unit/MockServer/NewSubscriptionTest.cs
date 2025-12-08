using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
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
              "entryPoint": "f743aed24a",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100
              },
              "paymentMethod": {
                "cardcvv": "123",
                "cardexp": "02/25",
                "cardHolder": "John Cassian",
                "cardnumber": "4111111111111111",
                "cardzip": "37615",
                "initiator": "payor",
                "method": "card"
              },
              "scheduleDetails": {
                "endDate": "03-20-2025",
                "frequency": "weekly",
                "planId": 1,
                "startDate": "09-20-2024"
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
                Body = new SubscriptionRequestBody
                {
                    CustomerData = new PayorDataRequest { CustomerId = 4440 },
                    EntryPoint = "f743aed24a",
                    PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
                    PaymentMethod = new PayMethodCredit
                    {
                        Cardcvv = "123",
                        Cardexp = "02/25",
                        CardHolder = "John Cassian",
                        Cardnumber = "4111111111111111",
                        Cardzip = "37615",
                        Initiator = "payor",
                        Method = "card",
                    },
                    ScheduleDetails = new ScheduleDetail
                    {
                        EndDate = "03-20-2025",
                        Frequency = Frequency.Weekly,
                        PlanId = 1,
                        StartDate = "09-20-2024",
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<AddSubscriptionResponse>(mockResponse)).UsingDefaults()
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
                "endDate": "03-20-2025",
                "frequency": "weekly",
                "planId": 1,
                "startDate": "09-20-2024"
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
                Body = new SubscriptionRequestBody
                {
                    CustomerData = new PayorDataRequest { CustomerId = 4440 },
                    EntryPoint = "f743aed24a",
                    PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
                    PaymentMethod = new PayMethodAch
                    {
                        AchAccount = "3453445666",
                        AchAccountType = Achaccounttype.Checking,
                        AchCode = "PPD",
                        AchHolder = "John Cassian",
                        AchHolderType = AchHolderType.Personal,
                        AchRouting = "021000021",
                        Method = "ach",
                    },
                    ScheduleDetails = new ScheduleDetail
                    {
                        EndDate = "03-20-2025",
                        Frequency = Frequency.Weekly,
                        PlanId = 1,
                        StartDate = "09-20-2024",
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<AddSubscriptionResponse>(mockResponse)).UsingDefaults()
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
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100
              },
              "paymentMethod": {
                "initiator": "merchant",
                "storedMethodId": "4000e8c6-3add-4200-8ac2-9b8a4f8b1639-1323",
                "storedMethodUsageType": "recurring"
              },
              "scheduleDetails": {
                "endDate": "03-20-2025",
                "frequency": "weekly",
                "planId": 1,
                "startDate": "09-20-2024"
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
                Body = new SubscriptionRequestBody
                {
                    CustomerData = new PayorDataRequest { CustomerId = 4440 },
                    EntryPoint = "f743aed24a",
                    PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
                    PaymentMethod = new RequestSchedulePaymentMethodInitiator
                    {
                        Initiator = "merchant",
                        StoredMethodId = "4000e8c6-3add-4200-8ac2-9b8a4f8b1639-1323",
                        StoredMethodUsageType = "recurring",
                    },
                    ScheduleDetails = new ScheduleDetail
                    {
                        EndDate = "03-20-2025",
                        Frequency = Frequency.Weekly,
                        PlanId = 1,
                        StartDate = "09-20-2024",
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<AddSubscriptionResponse>(mockResponse)).UsingDefaults()
        );
    }
}
