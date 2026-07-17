using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.PaymentLink;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SendPayLinkFromIdTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": "2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234",
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PaymentLink/send/2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234")
                    .WithParam("mail2", "jo@example.com; ceo@example.com")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PaymentLink.SendPayLinkFromIdAsync(
            "2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234",
            new SendPayLinkFromIdRequest { Mail2 = "jo@example.com; ceo@example.com" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
