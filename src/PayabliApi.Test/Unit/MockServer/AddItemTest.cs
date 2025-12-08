using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
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
                    .WithPath("/LineItem/47cae3d74")
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
            "47cae3d74",
            new AddItemRequest
            {
                Body = new LineItem
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
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponse6>(mockResponse)).UsingDefaults()
        );
    }
}
