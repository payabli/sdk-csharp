using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ListLineItemsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Records": [
                {
                  "LineItem": {
                    "itemCost": 12.45,
                    "itemProductName": "Materials deposit",
                    "itemQty": 1
                  },
                  "ParentOrgName": "PropertyManager Pro",
                  "PaypointDbaname": "Sunshine Gutters",
                  "PaypointEntryname": "d193cf9a46",
                  "PaypointLegalname": "Sunshine Services, LLC"
                }
              ],
              "Summary": {
                "pageIdentifier": "null",
                "pageSize": 20,
                "totalAmount": 77.22,
                "totalNetAmount": 77.22,
                "totalPages": 2,
                "totalRecords": 2
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Query/lineitems/8cfec329267")
                    .WithParam("fromRecord", "251")
                    .WithParam("limitRecord", "0")
                    .WithParam("sortBy", "desc(field_name)")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.LineItem.ListLineItemsAsync(
            "8cfec329267",
            new ListLineItemsRequest
            {
                FromRecord = 251,
                LimitRecord = 0,
                SortBy = "desc(field_name)",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<QueryResponseItems>(mockResponse)).UsingDefaults()
        );
    }
}
