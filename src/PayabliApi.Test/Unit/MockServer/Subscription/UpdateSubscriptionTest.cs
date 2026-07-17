using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Subscription;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateSubscriptionTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "setPause": true
            }
            """;

        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "responseData": "396 paused",
              "customerId": 4440
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Subscription/231")
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

        var response = await Client.Subscription.UpdateSubscriptionAsync(
            231,
            new RequestUpdateSchedule { SetPause = true }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "setPause": false
            }
            """;

        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "responseData": "396 unpaused",
              "customerId": 4440
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Subscription/231")
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

        var response = await Client.Subscription.UpdateSubscriptionAsync(
            231,
            new RequestUpdateSchedule { SetPause = false }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100
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
              "responseData": "396 updated",
              "customerId": 4440
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Subscription/231")
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

        var response = await Client.Subscription.UpdateSubscriptionAsync(
            231,
            new RequestUpdateSchedule
            {
                PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
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
}
