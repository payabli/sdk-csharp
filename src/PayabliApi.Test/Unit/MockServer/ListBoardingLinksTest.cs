using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ListBoardingLinksTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Records": [
                {
                  "AcceptOauth": false,
                  "AcceptRegister": false,
                  "EntryAttributes": "EntryAttributes",
                  "Id": 1,
                  "LastUpdated": "2022-07-01T15:00:01.000Z",
                  "OrgParentName": "PropertyManager Pro",
                  "ReferenceName": "payabli-00710",
                  "ReferenceTemplateId": 1830,
                  "TemplateCode": "TemplateCode",
                  "TemplateName": "SMB"
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
                    .WithPath("/Query/boardinglinks/123")
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

        var response = await Client.Boarding.ListBoardingLinksAsync(
            123,
            new ListBoardingLinksRequest
            {
                FromRecord = 251,
                LimitRecord = 0,
                SortBy = "desc(field_name)",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<QueryBoardingLinksResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
