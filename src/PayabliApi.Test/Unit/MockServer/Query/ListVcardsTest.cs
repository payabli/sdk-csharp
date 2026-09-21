using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Query;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListVcardsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Records": [
                {
                  "vcardSent": true,
                  "cardType": 0,
                  "cardToken": "vcrd_5Ty8NrBzXjKuqHm9DwElfP",
                  "cardNumber": "44XX XXXX XXXX 1234",
                  "cvc": "XXX",
                  "expirationDate": "2025-12",
                  "status": "Active",
                  "amount": 500,
                  "currentBalance": 375.25,
                  "expenseLimit": 100,
                  "expenseLimitPeriod": "monthly",
                  "maxNumberOfUses": 10,
                  "currentNumberOfUses": 3,
                  "exactAmount": false,
                  "mcc": "5812",
                  "tcc": "T01",
                  "misc1": "Invoice #12345",
                  "misc2": "Project: Office Supplies",
                  "dateCreated": "2023-01-15T09:30:00.000Z",
                  "dateModified": "2023-02-20T14:15:22.000Z",
                  "associatedVendor": {
                    "VendorNumber": "VEN-123",
                    "Name1": "Office Supply Co.",
                    "Name2": "Office Supply Wholesale",
                    "EIN": "XXXXX6789",
                    "Phone": "(305) 555-1234",
                    "Email": "billing@officesupply.example.com",
                    "Address1": "123 Main St",
                    "Address2": "Suite 400",
                    "City": "Anytown",
                    "State": "CA",
                    "Zip": "12345",
                    "Country": "US",
                    "Mcc": "5111",
                    "LocationCode": "LOC-01",
                    "VendorStatus": 1,
                    "VendorId": 456,
                    "PaypointLegalname": "Global Factory LLC",
                    "PaypointDbaname": "Global Factory LLC",
                    "PaypointEntryname": "4872acb376a",
                    "ParentOrgName": "SupplyPro",
                    "CreatedDate": "2023-01-15T09:30:00.000Z",
                    "LastUpdated": "2023-02-20T14:15:22.000Z",
                    "remitAddress1": "456 Remit Ave",
                    "remitAddress2": "Dock 7",
                    "remitCity": "Billtown",
                    "remitState": "NY",
                    "remitZip": "67890",
                    "remitCountry": "US",
                    "payeeName1": "Office Supply Co.",
                    "payeeName2": "Office Supply Wholesale",
                    "customField1": "CF1",
                    "customField2": "CF2",
                    "customerVendorAccount": "CVA-001",
                    "InternalReferenceId": 1001
                  },
                  "associatedCustomer": {
                    "firstname": "Acme",
                    "lastname": "Corporation"
                  },
                  "PaypointDbaname": "Global Factory LLC",
                  "PaypointLegalname": "Global Factory LLC",
                  "PaypointEntryname": "4872acb376a",
                  "externalPaypointID": "pay-10",
                  "ParentOrgName": "SupplyPro",
                  "paypointId": 3040
                }
              ],
              "Summary": {
                "pageidentifier": "XXXXXXXXXXXXXX",
                "pageSize": 20,
                "totalAmount": 2500,
                "totalNetAmount": 0,
                "totalactive": 5,
                "totalamountactive": 2500,
                "totalbalanceactive": 1875.25,
                "totalPages": 1,
                "totalRecords": 5
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Query/vcards/8cfec329267")
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

        var response = await Client.Query.ListVcardsAsync(
            "8cfec329267",
            new ListVcardsRequest
            {
                FromRecord = 251,
                LimitRecord = 0,
                SortBy = "desc(field_name)",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
