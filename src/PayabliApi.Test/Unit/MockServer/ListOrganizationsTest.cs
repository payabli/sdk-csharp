using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ListOrganizationsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Records": [
                {
                  "services": [
                    {}
                  ],
                  "contacts": [
                    {}
                  ],
                  "createdAt": "2022-07-01T15:00:01.000Z",
                  "hasBilling": true,
                  "hasResidual": true,
                  "idOrg": 123,
                  "isRoot": false,
                  "orgAddress": "123 Walnut Street",
                  "orgCity": "Johnson City",
                  "orgCountry": "US",
                  "orgEntryName": "pilgrim-planner",
                  "orgId": "I-123",
                  "orgName": "Pilgrim Planner",
                  "orgParentId": 236,
                  "orgParentName": "PropertyManager Pro",
                  "orgState": "TN",
                  "orgTimezone": -5,
                  "orgType": 0,
                  "orgWebsite": "www.pilgrimageplanner.com",
                  "orgZip": "orgZip",
                  "recipientEmailNotification": true,
                  "replyToEmail": "example@email.com",
                  "resumable": false,
                  "users": [
                    {
                      "createdAt": "2022-07-01T15:00:01.000Z",
                      "UsrMFAMode": 0
                    }
                  ]
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
                    .WithPath("/Query/organizations/123")
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

        var response = await Client.Query.ListOrganizationsAsync(
            123,
            new ListOrganizationsRequest
            {
                FromRecord = 251,
                LimitRecord = 0,
                SortBy = "desc(field_name)",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<ListOrganizationsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
