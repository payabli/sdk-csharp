using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.GhostCard;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateCardTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "cardToken": "gc_abc123def456",
              "status": "Cancelled"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyOutCard/card/8cfec329267")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.GhostCard.UpdateCardAsync(
            "8cfec329267",
            new UpdateCardRequestBody
            {
                CardToken = "gc_abc123def456",
                Status = CardStatus.Cancelled,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
