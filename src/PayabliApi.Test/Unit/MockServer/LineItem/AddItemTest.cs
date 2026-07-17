using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.LineItem;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AddItemTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "itemProductCode": "M-DEPOSIT",
              "itemProductName": "Materials deposit",
              "itemDescription": "Deposit for materials",
              "itemCommodityCode": "010",
              "itemUnitOfMeasure": "SqFt",
              "itemCost": 12.45,
              "itemQty": 1,
              "itemMode": 0
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
                    .WithPath("/LineItem/8cfec329267")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.LineItem.AddItemAsync(
            "8cfec329267",
            new AddItemRequest
            {
                Body = new PayabliApi.LineItem
                {
                    ItemProductCode = "M-DEPOSIT",
                    ItemProductName = "Materials deposit",
                    ItemDescription = "Deposit for materials",
                    ItemCommodityCode = "010",
                    ItemUnitOfMeasure = "SqFt",
                    ItemCost = 12.45,
                    ItemQty = 1,
                    ItemMode = 0,
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
