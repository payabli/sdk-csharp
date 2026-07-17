using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.PayoutSubscription;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdatePayoutSubscriptionTest : BaseMockServerTest
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
              "responseData": "42 paused",
              "customerId": 4440
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PayoutSubscription/42")
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

        var response = await Client.PayoutSubscription.UpdatePayoutSubscriptionAsync(
            42,
            new UpdatePayoutSubscriptionBody { SetPause = true }
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
              "responseData": "42",
              "customerId": 4440
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PayoutSubscription/42")
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

        var response = await Client.PayoutSubscription.UpdatePayoutSubscriptionAsync(
            42,
            new UpdatePayoutSubscriptionBody { SetPause = false }
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
                "totalAmount": 750
              },
              "scheduleDetails": {
                "endDate": "12/31/2027",
                "frequency": "monthly",
                "startDate": "01/01/2027"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "responseData": "42",
              "customerId": 4440
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PayoutSubscription/42")
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

        var response = await Client.PayoutSubscription.UpdatePayoutSubscriptionAsync(
            42,
            new UpdatePayoutSubscriptionBody
            {
                PaymentDetails = new PayoutPaymentDetail { ServiceFee = 0, TotalAmount = 750 },
                ScheduleDetails = new PayoutScheduleDetail
                {
                    EndDate = "12/31/2027",
                    Frequency = Frequency.Monthly,
                    StartDate = "01/01/2027",
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
