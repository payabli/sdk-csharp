using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class GetItemTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "createdAt": "2022-07-01T15:00:01.000Z",
              "id": 45,
              "itemCategories": [
                "itemCategories"
              ],
              "itemCommodityCode": "010",
              "itemCost": 5,
              "itemDescription": "Deposit for materials.",
              "itemMode": 0,
              "itemProductCode": "M-DEPOSIT",
              "itemProductName": "Materials deposit",
              "itemQty": 1,
              "itemUnitOfMeasure": "SqFt",
              "lastUpdated": "2022-07-01T15:00:01.000Z",
              "pageidentifier": "null",
              "ParentOrgName": "PropertyManager Pro",
              "PaypointDbaname": "Sunshine Gutters",
              "PaypointEntryname": "d193cf9a46",
              "PaypointLegalname": "Sunshine Services, LLC"
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/LineItem/700").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.LineItem.GetItemAsync(700);
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<LineItemQueryRecord>(mockResponse)).UsingDefaults()
        );
    }
}
