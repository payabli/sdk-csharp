using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.PaymentMethods;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetPaymentMethodTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Payment method retrieved successfully",
              "traceId": "0HNNN6HH5NE0R:00000015",
              "data": {
                "paymentMethodReference": "019ff142-454b-7721-96a3-c8628b9d568f",
                "type": "bank_account",
                "accountOwner": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "ownerType": "business",
                "nickname": "Operating account",
                "financialInstitution": "Bank of Example",
                "accountType": "Checking",
                "accountNumber": "****6789",
                "routingNumber": "*****0021",
                "status": "PENDING",
                "usage": [
                  "deposits",
                  "billing"
                ],
                "createdAt": "2026-08-11T14:38:00.011776",
                "lastUpdated": "2026-08-11T14:38:00.011776",
                "_links": {
                  "self": "/api/v2/payment-methods/019ff142-454b-7721-96a3-c8628b9d568f",
                  "owner": "/api/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/payment-methods/019ff142-454b-7721-96a3-c8628b9d568f")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PaymentMethods.GetPaymentMethodAsync(
            "019ff142-454b-7721-96a3-c8628b9d568f"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
