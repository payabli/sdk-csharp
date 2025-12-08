using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class RefundTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "responseData": {
                "authCode": "A0000",
                "expectedProcessingDateTime": "2025-02-15T10:30:00.000Z",
                "referenceId": "10-3ffa27df-b171-44e0-b251-e95fbfc7a723",
                "resultCode": 10,
                "resultText": "INITIATED",
                "avsResponseText": null,
                "cvvResponseText": null,
                "customerId": null,
                "methodReferenceId": null
              },
              "pageidentifier": null
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/refund/10-3ffa27df-b171-44e0-b251-e95fbfc7a723/0")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyIn.RefundAsync(
            0,
            "10-3ffa27df-b171-44e0-b251-e95fbfc7a723"
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RefundResponse>(mockResponse)).UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "responseData": {
                "authCode": "A0000",
                "referenceId": "10-3ffa27df-b171-44e0-b251-e95fbfc7a723",
                "resultCode": 1,
                "resultText": "CAPTURED",
                "avsResponseText": null,
                "cvvResponseText": null,
                "customerId": null,
                "methodReferenceId": null
              },
              "pageidentifier": null
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/refund/10-3ffa27df-b171-44e0-b251-e95fbfc7a723/100.99")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyIn.RefundAsync(
            100.99,
            "10-3ffa27df-b171-44e0-b251-e95fbfc7a723"
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RefundResponse>(mockResponse)).UsingDefaults()
        );
    }
}
