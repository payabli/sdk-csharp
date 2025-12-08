using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ListApplicationsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Records": [
                {
                  "annualRevenue": 1000,
                  "averageMonthlyVolume": 1000,
                  "averageTicketAmount": 1000,
                  "bAddress1": "123 Walnut Street",
                  "bAddress2": "Suite 103",
                  "bankData": [
                    {
                      "bankAccountFunction": 0,
                      "bankAccountHolderName": "Gruzya Adventure Outfitters LLC",
                      "nickname": "Business Checking 1234"
                    }
                  ],
                  "bCity": "New Vegas",
                  "bCountry": "US",
                  "bFax": "5551234567",
                  "binPerson": 60,
                  "binPhone": 20,
                  "binWeb": 20,
                  "boardingLinkId": 91,
                  "boardingStatus": 1,
                  "boardingSubStatus": 1,
                  "bPhone": "5551234567",
                  "bStartdate": "01/01/1990",
                  "bState": "FL",
                  "bSummary": "Brick and mortar store that sells office supplies",
                  "bZip": "33000",
                  "contactData": [
                    {}
                  ],
                  "createdAt": "2022-07-01T15:00:01.000Z",
                  "dbaName": "Sunshine Gutters",
                  "ein": "123456789",
                  "externalPaypointId": "Paypoint-100",
                  "generalEvents": [
                    {
                      "description": "TransferCreated",
                      "eventTime": "2023-07-05T22:31:06.000Z"
                    }
                  ],
                  "highTicketAmount": 1000,
                  "idApplication": 352,
                  "lastModified": "2022-07-01T15:00:01.000Z",
                  "legalName": "Sunshine Services, LLC",
                  "license": "2222222FFG",
                  "licenseState": "CA",
                  "mAddress1": "123 Walnut Street",
                  "mAddress2": "STE 900",
                  "mccid": "mccid",
                  "mCity": "TN",
                  "mCountry": "US",
                  "mState": "TN",
                  "mZip": "37615",
                  "orgId": 123,
                  "orgParentName": "PropertyManager Pro",
                  "ownerData": [
                    {}
                  ],
                  "ownType": "Limited Liability Company",
                  "pageidentifier": "null",
                  "recipientEmailNotification": true,
                  "resumable": false,
                  "salesCode": "salesCode",
                  "taxfillname": "Sunshine LLC",
                  "templateId": 22,
                  "websiteAddress": "www.example.com",
                  "whencharged": "When Service Provided",
                  "whendelivered": "0-7 Days",
                  "whenProvided": "30 Days or Less",
                  "whenrefund": "Exchange Only"
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
                    .WithPath("/Query/boarding/123")
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

        var response = await Client.Boarding.ListApplicationsAsync(
            123,
            new ListApplicationsRequest
            {
                FromRecord = 251,
                LimitRecord = 0,
                SortBy = "desc(field_name)",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<QueryBoardingAppsListResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
