using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Organization;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetOrganizationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Services": [
                {
                  "description": "description",
                  "enabled": true,
                  "monthlyCost": 1.1,
                  "name": "name",
                  "reseller": true,
                  "setupCost": 1.1,
                  "txCost": 1.1,
                  "txPercentCost": 1.1
                }
              ],
              "BillingInfo": {
                "achAccount": "123123123",
                "achRouting": "123123123",
                "billingAddress": "123 Walnut Street",
                "billingCity": "Johnson City",
                "billingCountry": "US",
                "billingState": "TN",
                "billingZip": "37615"
              },
              "Contacts": [
                {
                  "ContactEmail": "example@email.com",
                  "ContactName": "Herman Martinez",
                  "ContactPhone": "3055550000",
                  "ContactTitle": "Owner"
                }
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
              "OrgLogo": "https://www.pilgrimageplanner.com/logo.png",
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
              "summary": {
                "amountSubs": 1.1,
                "amountTx": 1.1,
                "childOrgs": 1,
                "childPaypoints": 1,
                "countSubs": 1,
                "countTx": 1
              },
              "users": [
                {
                  "Access": [
                    {
                      "roleValue": true
                    }
                  ],
                  "AdditionalData": {
                    "key1": "value1",
                    "key2": "value2"
                  },
                  "createdAt": "2022-07-01T15:00:01.000Z",
                  "Email": "example@email.com",
                  "language": "en",
                  "lastAccess": "2022-07-01T15:00:01.000Z",
                  "Name": "Sean Smith",
                  "Phone": "5555555555",
                  "Scope": [
                    {
                      "orgType": 0
                    }
                  ],
                  "snData": "snData",
                  "snIdentifier": "snIdentifier",
                  "snProvider": "google",
                  "timeZone": -5,
                  "userId": 1000000,
                  "UsrMFA": false,
                  "UsrMFAMode": 0,
                  "UsrStatus": 1
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Organization/read/123")
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

        var response = await Client.Organization.GetOrganizationAsync(123);
        JsonAssert.AreEqual(response, mockResponse);
    }
}
