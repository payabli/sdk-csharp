using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.PaymentLink;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
                    .WithPath("/PaymentLink/update/2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234")
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
            "2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234",
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
        JsonAssert.AreEqual(response, mockResponse);
    }
}
