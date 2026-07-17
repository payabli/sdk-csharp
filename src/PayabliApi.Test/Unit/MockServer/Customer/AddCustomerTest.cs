using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Customer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AddCustomerTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "customerNumber": "C-90010",
              "firstname": "Irene",
              "lastname": "Canizales",
              "address1": "123 Bishop's Trail",
              "city": "Mountain City",
              "state": "TN",
              "zip": "37612",
              "country": "US",
              "email": "irene@canizalesconcrete.com",
              "identifierFields": [
                "email"
              ],
              "timeZone": -5
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": {
                "customerId": 4440,
                "customerNumber": "C-90010",
                "customerStatus": 0,
                "Firstname": "Irene",
                "Lastname": "Canizales",
                "Email": "irene@canizalesconcrete.com",
                "Address1": "123 Bishop's Trail",
                "City": "Mountain City",
                "State": "TN",
                "Zip": "37612",
                "Country": "US",
                "Balance": 0,
                "TimeZone": -5,
                "MFA": false,
                "MFAMode": 0,
                "LastUpdated": "2024-03-13T12:49:56.000Z",
                "Created": "2024-03-13T12:49:56.000Z",
                "AdditionalFields": {
                  "key": "value"
                },
                "IdentifierFields": [
                  "email"
                ],
                "customerSummary": {
                  "NumberofTransactions": 30,
                  "RecentTransactions": [
                    {
                      "EntrypageId": 0,
                      "FeeAmount": 1,
                      "PayorId": 1551,
                      "PaypointId": 3040,
                      "SettlementStatus": 2,
                      "splitCount": 0,
                      "TotalAmount": 30.22,
                      "TransStatus": 1
                    }
                  ],
                  "TotalAmountTransactions": 1500,
                  "TotalNetAmountTransactions": 1500
                },
                "PaypointLegalname": "Gruzya Adventure Outfitters, LLC",
                "PaypointDbaname": "Gruzya Adventure Outfitters",
                "ParentOrgName": "The Pilgrim Planner",
                "ParentOrgId": 123,
                "PaypointEntryname": "41035afaa7",
                "pageidentifier": "null"
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Customer/single/8cfec329267")
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

        var response = await Client.Customer.AddCustomerAsync(
            "8cfec329267",
            new AddCustomerRequest
            {
                Body = new CustomerData
                {
                    CustomerNumber = "C-90010",
                    Firstname = "Irene",
                    Lastname = "Canizales",
                    Address1 = "123 Bishop's Trail",
                    City = "Mountain City",
                    State = "TN",
                    Zip = "37612",
                    Country = "US",
                    Email = "irene@canizalesconcrete.com",
                    IdentifierFields = new List<string>() { "email" },
                    TimeZone = -5,
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
