using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyOut;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class VCardGetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "vcardSent": false,
              "cardToken": "20231206142225226104",
              "cardNumber": "553232XXXXXX3179",
              "cvc": "XXX",
              "expirationDate": "2025-05-01",
              "amount": 120,
              "currentBalance": 120,
              "expenseLimit": 20,
              "maxNumberOfUses": 1,
              "currentNumberOfUses": 0,
              "exactAmount": true,
              "dateCreated": "2023-12-06T20:25:31.077",
              "dateModified": "2023-12-06T00:00:00",
              "associatedVendor": {
                "VendorNumber": "VEN-123",
                "Name1": "Smith Industries",
                "Name2": "John Smith",
                "EIN": "12-3456789",
                "Phone": "555-123-4567",
                "Email": "contact@smithindustries.com",
                "Address1": "1234 Main Street",
                "Address2": "Suite 200",
                "City": "New York",
                "State": "NY",
                "Zip": "10001",
                "Country": "USA",
                "Mcc": "5411",
                "Contacts": [
                  {
                    "ContactName": "Herman Martinez",
                    "ContactEmail": "herman@hermanscoatings.com",
                    "ContactTitle": "Owner",
                    "ContactPhone": "3055550000"
                  }
                ],
                "BillingData": {
                  "id": 123,
                  "nickname": "Checking Account",
                  "bankName": "Chase Bank",
                  "routingAccount": "021000021",
                  "accountNumber": "3XXXXXX8888",
                  "typeAccount": "Checking",
                  "bankAccountHolderName": "Gruzya Adventure Outfitters LLC",
                  "bankAccountHolderType": "Business",
                  "bankAccountFunction": 0,
                  "verified": true,
                  "status": 1,
                  "services": [],
                  "default": true
                },
                "PaymentMethod": "vcard",
                "VendorStatus": 1,
                "VendorId": 456,
                "Summary": {
                  "ActiveBills": 1,
                  "ActiveBillsAmount": 1.1,
                  "ApprovedBills": 1,
                  "ApprovedBillsAmount": 1.1,
                  "DisapprovedBills": 1,
                  "DisapprovedBillsAmount": 1.1,
                  "InTransitBills": 0,
                  "InTransitBillsAmount": 0,
                  "OverdueBills": 1,
                  "OverdueBillsAmount": 100,
                  "PaidBills": 0,
                  "PaidBillsAmount": 0,
                  "PendingBills": 1,
                  "PendingBillsAmount": 100,
                  "TotalBills": 1,
                  "TotalBillsAmount": 100
                },
                "PaypointLegalname": "Athlete Factory LLC",
                "PaypointDbaname": "Athlete Factory LLC",
                "PaypointEntryname": "PaypointEntryname",
                "ParentOrgName": "HOA Manager Pro",
                "ParentOrgId": 1232,
                "CreatedDate": "2022-07-01T15:00:01Z",
                "LastUpdated": "2022-07-01T15:00:01Z",
                "remitAddress1": "123 Walnut Street",
                "remitAddress2": "Suite 900",
                "remitCity": "Miami",
                "remitState": "FL",
                "remitZip": "31113",
                "remitCountry": "US",
                "customField1": "customField1",
                "customField2": "customField2",
                "InternalReferenceId": 27
              },
              "ParentOrgName": "HOA Manager Pro",
              "PaypointDbaname": "Athlete Factory LLC",
              "PaypointLegalname": "Athlete Factory LLC",
              "PaypointEntryname": "47acde49",
              "paypointId": 3040
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyOut/vcard/20230403315245421165")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyOut.VCardGetAsync("20230403315245421165");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
