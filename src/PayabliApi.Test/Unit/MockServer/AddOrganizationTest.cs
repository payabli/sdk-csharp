using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class AddOrganizationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "billingInfo": {
                "achAccount": "123123123",
                "achRouting": "123123123",
                "billingAddress": "123 Walnut Street",
                "billingCity": "Johnson City",
                "billingCountry": "US",
                "billingState": "TN",
                "billingZip": "37615"
              },
              "contacts": [
                {
                  "contactEmail": "herman@hermanscoatings.com",
                  "contactName": "Herman Martinez",
                  "contactPhone": "3055550000",
                  "contactTitle": "Owner"
                }
              ],
              "hasBilling": true,
              "hasResidual": true,
              "orgAddress": "123 Walnut Street",
              "orgCity": "Johnson City",
              "orgCountry": "US",
              "orgEntryName": "pilgrim-planner",
              "orgId": "123",
              "orgLogo": {
                "fContent": "TXkgdGVzdCBmaWxlHJ==...",
                "filename": "my-doc.pdf",
                "ftype": "pdf",
                "furl": "https://mysite.com/my-doc.pdf"
              },
              "orgName": "Pilgrim Planner",
              "orgParentId": 236,
              "orgState": "TN",
              "orgTimezone": -5,
              "orgType": 0,
              "orgWebsite": "www.pilgrimageplanner.com",
              "orgZip": "37615",
              "replyToEmail": "email@example.com"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": 245,
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Organization")
                    .WithHeader("idempotencyKey", "6B29FC40-CA47-1067-B31D-00DD010662DA")
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

        var response = await Client.Organization.AddOrganizationAsync(
            new AddOrganizationRequest
            {
                IdempotencyKey = "6B29FC40-CA47-1067-B31D-00DD010662DA",
                BillingInfo = new Instrument
                {
                    AchAccount = "123123123",
                    AchRouting = "123123123",
                    BillingAddress = "123 Walnut Street",
                    BillingCity = "Johnson City",
                    BillingCountry = "US",
                    BillingState = "TN",
                    BillingZip = "37615",
                },
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
                HasBilling = true,
                HasResidual = true,
                OrgAddress = "123 Walnut Street",
                OrgCity = "Johnson City",
                OrgCountry = "US",
                OrgEntryName = "pilgrim-planner",
                OrgId = "123",
                OrgLogo = new FileContent
                {
                    FContent = "TXkgdGVzdCBmaWxlHJ==...",
                    Filename = "my-doc.pdf",
                    Ftype = FileContentFtype.Pdf,
                    Furl = "https://mysite.com/my-doc.pdf",
                },
                OrgName = "Pilgrim Planner",
                OrgParentId = 236,
                OrgState = "TN",
                OrgTimezone = -5,
                OrgType = 0,
                OrgWebsite = "www.pilgrimageplanner.com",
                OrgZip = "37615",
                ReplyToEmail = "email@example.com",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<AddOrganizationResponse>(mockResponse)).UsingDefaults()
        );
    }
}
