using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ListCustomersTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Records": [
                {
                  "Address": "1234 Bayou Road",
                  "Address1": "Suite 2",
                  "Balance": 0,
                  "City": "Lafayette",
                  "Company": "Boudreaux's Shop",
                  "Country": "US",
                  "Created": "2023-12-20T13:07:48.000Z",
                  "customerId": 2876,
                  "customerNumber": "425436530000",
                  "customerStatus": 0,
                  "customerSummary": {
                    "numberofTransactions": 30,
                    "totalAmountTransactions": 1500,
                    "totalNetAmountTransactions": 1500
                  },
                  "Email": "thibodeaux.hebert@bayoumail.com",
                  "externalPaypointID": "pay-10",
                  "Firstname": "Thibodeaux",
                  "IdentifierFields": [
                    "email"
                  ],
                  "Lastname": "Hebert",
                  "LastUpdated": "2023-12-20T13:07:48.000Z",
                  "MFA": false,
                  "MFAMode": 0,
                  "ParentOrgName": "SupplyPro",
                  "PaypointDbaname": "Global Factory LLC",
                  "PaypointEntryname": "4872acb376a",
                  "PaypointLegalname": "Global Factory LLC",
                  "Phone": "(504) 823-4566",
                  "ShippingAddress": "1234 Bayou Road",
                  "ShippingAddress1": "Suite 2",
                  "ShippingCity": "Lafayette",
                  "ShippingCountry": "US",
                  "ShippingState": "LA",
                  "ShippingZip": "70501",
                  "State": "LA",
                  "TimeZone": 0,
                  "Zip": "70501"
                }
              ],
              "Summary": {
                "pageIdentifier": "XXXXXXXXXXXXXX",
                "pageSize": 20,
                "totalAmount": 0,
                "totalNetAmount": 0,
                "totalPages": 26,
                "totalRecords": 510
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Query/customers/8cfec329267")
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

        var response = await Client.Query.ListCustomersAsync(
            "8cfec329267",
            new ListCustomersRequest
            {
                FromRecord = 251,
                LimitRecord = 0,
                SortBy = "desc(field_name)",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<QueryCustomerResponse>(mockResponse)).UsingDefaults()
        );
    }
}
