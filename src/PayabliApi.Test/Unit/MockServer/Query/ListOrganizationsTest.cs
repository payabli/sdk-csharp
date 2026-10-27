using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Query;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListOrganizationsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Records": [
                {
                  "Services": [
                    {}
                  ],
                  "Contacts": [
                    {}
                  ],
                  "createdAt": "2022-07-01T15:00:01.000Z",
                  "HasBilling": true,
                  "HasResidual": true,
                  "idOrg": 123,
                  "isRoot": false,
                  "OrgAddress": "123 Walnut Street",
                  "OrgCity": "Johnson City",
                  "OrgCountry": "US",
                  "OrgEntryName": "pilgrim-planner",
                  "OrgFavicon": "https://www.pilgrimageplanner.com/favicon.png",
                  "OrgId": "123",
                  "OrgName": "Pilgrim Planner",
                  "OrgParentId": 236,
                  "OrgParentName": "PropertyManager Pro",
                  "OrgState": "TN",
                  "OrgTimezone": -5,
                  "OrgType": 0,
                  "OrgWebsite": "www.pilgrimageplanner.com",
                  "OrgZip": "orgZip",
                  "recipientEmailNotification": true,
                  "ReplyToEmail": "example@email.com",
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
                "pageidentifier": "null",
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
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
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
        JsonAssert.AreEqual(response, mockResponse);
    }
}
