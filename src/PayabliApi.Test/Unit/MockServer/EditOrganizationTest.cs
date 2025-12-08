using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class EditOrganizationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "contacts": [
                {
                  "contactEmail": "herman@hermanscoatings.com",
                  "contactName": "Herman Martinez",
                  "contactPhone": "3055550000",
                  "contactTitle": "Owner"
                }
              ],
              "orgAddress": "123 Walnut Street",
              "orgCity": "Johnson City",
              "orgCountry": "US",
              "orgEntryName": "pilgrim-planner",
              "orgId": "123",
              "orgName": "Pilgrim Planner",
              "orgState": "TN",
              "orgTimezone": -5,
              "orgType": 0,
              "orgWebsite": "www.pilgrimageplanner.com",
              "orgZip": "37615"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseData": 2442,
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Organization/123")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organization.EditOrganizationAsync(
            123,
            new OrganizationData
            {
                Contacts = new List<Contacts>()
                {
                    new Contacts
                    {
                        ContactEmail = "herman@hermanscoatings.com",
                        ContactName = "Herman Martinez",
                        ContactPhone = "3055550000",
                        ContactTitle = "Owner",
                    },
                },
                OrgAddress = "123 Walnut Street",
                OrgCity = "Johnson City",
                OrgCountry = "US",
                OrgEntryName = "pilgrim-planner",
                OrganizationDataOrgId = "123",
                OrgName = "Pilgrim Planner",
                OrgState = "TN",
                OrgTimezone = -5,
                OrgType = 0,
                OrgWebsite = "www.pilgrimageplanner.com",
                OrgZip = "37615",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<EditOrganizationResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
