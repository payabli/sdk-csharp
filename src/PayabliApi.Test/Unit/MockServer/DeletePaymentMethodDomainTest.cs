using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class DeletePaymentMethodDomainTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "pageIdentifier": "null",
              "responseData": "pmd_b8237fa45c964d8a9ef27160cd42b8c5",
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PaymentMethodDomain/pmd_b8237fa45c964d8a9ef27160cd42b8c5")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PaymentMethodDomain.DeletePaymentMethodDomainAsync(
            "pmd_b8237fa45c964d8a9ef27160cd42b8c5"
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DeletePaymentMethodDomainResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
