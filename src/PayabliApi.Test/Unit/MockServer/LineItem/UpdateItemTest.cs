using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.LineItem;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateItemTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "itemCost": 12.45,
              "itemQty": 1
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": 700,
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/LineItem/700")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.LineItem.UpdateItemAsync(
            700,
            new PayabliApi.LineItem { ItemCost = 12.45, ItemQty = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
