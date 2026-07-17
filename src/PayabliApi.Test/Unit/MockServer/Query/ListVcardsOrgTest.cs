using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Query;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListVcardsOrgTest : BaseMockServerTest
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
                    "EIN": "XXXXX6789",
                    "Email": "billing@officesupply.example.com",
                    "VendorId": 456
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
                    .WithPath("/Query/vcards/org/123")
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

        var response = await Client.Query.ListVcardsOrgAsync(
            123,
            new ListVcardsOrgRequest
            {
                FromRecord = 251,
                LimitRecord = 0,
                SortBy = "desc(field_name)",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
