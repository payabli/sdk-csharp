using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.PaymentMethods;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeactivatePaymentMethodTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Payment method deactivated successfully",
              "traceId": "0HNNN6HH5NE2S:0000000A",
              "data": {
                "paymentMethodReference": "019ff142-454b-7721-96a3-c8628b9d568f",
                "type": "bank_account",
                "fingerprint": "2a0c2a64d03492ba45af4d01f329f22b41513411cab7658072739d17ed570675",
                "tokenReference": "deacc32d-81eb-470b-9cff-0ad2fab87096",
                "accountOwner": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "ownerType": "business",
                "nickname": "Primary operating account",
                "financialInstitution": "Bank of Example",
                "accountType": "Checking",
                "accountNumber": "****6789",
                "routingNumber": "*****0021",
                "status": "INACTIVE",
                "usage": [
                  "deposits",
                  "billing"
                ],
                "createdAt": "2026-08-11T14:38:00.011Z",
                "lastUpdated": "2026-08-11T14:40:03.118Z",
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
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PaymentMethods.DeactivatePaymentMethodAsync(
            "019ff142-454b-7721-96a3-c8628b9d568f"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
