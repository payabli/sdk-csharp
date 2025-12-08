using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class UpdatePayLinkFromIdTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "notes": {
                "enabled": true,
                "header": "Additional Notes",
                "order": 0,
                "placeholder": "Enter any additional notes here",
                "value": ""
              },
              "paymentButton": {
                "enabled": true,
                "label": "Pay Now",
                "order": 0
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": "332-c277b704-1301",
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PaymentLink/update/332-c277b704-1301")
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

        var response = await Client.PaymentLink.UpdatePayLinkFromIdAsync(
            "332-c277b704-1301",
            new PayLinkUpdateData
            {
                Notes = new NoteElement
                {
                    Enabled = true,
                    Header = "Additional Notes",
                    Order = 0,
                    Placeholder = "Enter any additional notes here",
                    Value = "",
                },
                PaymentButton = new LabelElement
                {
                    Enabled = true,
                    Label = "Pay Now",
                    Order = 0,
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponsePaymentLinks>(mockResponse))
                .UsingDefaults()
        );
    }
}
