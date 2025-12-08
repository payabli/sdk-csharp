using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ListTemplatesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "records": [
                {
                  "addPrice": true,
                  "boardingLinks": [
                    {
                      "id": 91
                    }
                  ],
                  "createdAt": "2022-07-01T15:00:01.000Z",
                  "idTemplate": 1000000,
                  "isRoot": false,
                  "orgParentName": "PropertyManager Pro",
                  "recipientEmailNotification": true,
                  "resumable": false,
                  "templateCode": "templateCode",
                  "templateDescription": "templateDescription",
                  "templateTitle": "templateTitle",
                  "usedBy": 1
                }
              ],
              "summary": {
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
                    .WithPath("/Query/templates/123")
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

        var response = await Client.Templates.ListTemplatesAsync(
            123,
            new ListTemplatesRequest
            {
                FromRecord = 251,
                LimitRecord = 0,
                SortBy = "desc(field_name)",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<TemplateQueryResponse>(mockResponse)).UsingDefaults()
        );
    }
}
