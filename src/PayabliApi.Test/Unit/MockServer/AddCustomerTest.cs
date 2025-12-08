using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class AddCustomerTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "customerNumber": "12356ACB",
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
                "customerId": 17264,
                "customerNumber": "12356ACB",
                "customerUsername": null,
                "customerStatus": 0,
                "Company": null,
                "Firstname": "Irene",
                "Lastname": "Canizales",
                "Phone": null,
                "Email": "irene@canizalesconcrete.com",
                "Address": null,
                "Address1": "123 Bishop's Trail",
                "City": "Mountain City",
                "State": "TN",
                "Zip": "37612",
                "Country": "US",
                "ShippingAddress": null,
                "ShippingAddress1": null,
                "ShippingCity": null,
                "ShippingState": null,
                "ShippingZip": null,
                "ShippingCountry": null,
                "Balance": 0,
                "TimeZone": -5,
                "MFA": false,
                "MFAMode": 0,
                "snProvider": null,
                "snIdentifier": null,
                "snData": null,
                "LastUpdated": "2024-03-13T12:49:56.000Z",
                "Created": "2024-03-13T12:49:56.000Z",
                "AdditionalFields": {
                  "key": "value"
                },
                "IdentifierFields": [
                  "email"
                ],
                "Subscriptions": null,
                "StoredMethods": null,
                "customerSummary": {
                  "numberofTransactions": 30,
                  "recentTransactions": [
                    {
                      "EntrypageId": 0,
                      "FeeAmount": 1,
                      "PayorId": 1551,
                      "PaypointId": 226,
                      "SettlementStatus": 2,
                      "TotalAmount": 30.22,
                      "TransStatus": 1
                    }
                  ],
                  "totalAmountTransactions": 1500,
                  "totalNetAmountTransactions": 1500
                },
                "PaypointLegalname": "Gruzya Adventure Outfitters, LLC",
                "PaypointDbaname": "Gruzya Adventure Outfitters",
                "ParentOrgName": "The Pilgrim Planner",
                "ParentOrgId": 123,
                "PaypointEntryname": "41035afaa7",
                "pageidentifier": "null",
                "externalPaypointID": null,
                "customerConsent": null
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
                    CustomerNumber = "12356ACB",
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
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponseCustomerQuery>(mockResponse))
                .UsingDefaults()
        );
    }
}
