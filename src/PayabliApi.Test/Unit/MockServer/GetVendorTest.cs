using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class GetVendorTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "VendorNumber": "1234",
              "Name1": "Herman's Coatings",
              "Name2": "Herman's Coating Supply Company, LLC",
              "EIN": "123456789",
              "Phone": "212-555-1234",
              "Email": "example@email.com",
              "RemitEmail": null,
              "Address1": "123 Ocean Drive",
              "Address2": "Suite 400",
              "City": "Bristol",
              "State": "GA",
              "Zip": "31113",
              "Country": "US",
              "Mcc": "7777",
              "LocationCode": "LOC123",
              "Contacts": {
                "ContactEmail": "eric@martinezcoatings.com",
                "ContactName": "Eric Martinez",
                "ContactPhone": "5555555555",
                "ContactTitle": "Owner"
              },
              "BillingData": {
                "id": 123456,
                "accountId": "bank-account-001",
                "nickname": "Main Checking Account",
                "bankName": "Example Bank",
                "routingAccount": "123456789",
                "accountNumber": "9876543210",
                "typeAccount": "Checking",
                "bankAccountHolderName": "John Doe",
                "bankAccountHolderType": "Business",
                "bankAccountFunction": 2,
                "verified": true,
                "status": 1,
                "services": [],
                "default": true
              },
              "PaymentMethod": null,
              "VendorStatus": 1,
              "VendorId": 1,
              "EnrollmentStatus": null,
              "Summary": {
                "ActiveBills": 2,
                "PendingBills": 4,
                "InTransitBills": 3,
                "PaidBills": 18,
                "OverdueBills": 1,
                "ApprovedBills": 5,
                "DisapprovedBills": 1,
                "TotalBills": 34,
                "ActiveBillsAmount": 1250.75,
                "PendingBillsAmount": 2890.5,
                "InTransitBillsAmount": 1675.25,
                "PaidBillsAmount": 15420.8,
                "OverdueBillsAmount": 425,
                "ApprovedBillsAmount": 3240.9,
                "DisapprovedBillsAmount": 180,
                "TotalBillsAmount": 25083.2
              },
              "PaypointLegalname": "Sunshine Services, LLC",
              "PaypointDbaname": "Sunshine Gutters",
              "PaypointEntryname": "d193cf9a46",
              "ParentOrgName": "PropertyManager Pro",
              "ParentOrgId": 1000,
              "CreatedDate": "2022-07-01T15:00:01.000Z",
              "LastUpdated": "2022-07-01T15:00:01.000Z",
              "remitAddress1": "123 Walnut Street",
              "remitAddress2": "Suite 900",
              "remitCity": "Miami",
              "remitState": "FL",
              "remitZip": "31113",
              "remitCountry": "US",
              "payeeName1": "payeeName1",
              "payeeName2": "payeeName2",
              "customField1": "",
              "customField2": "",
              "customerVendorAccount": "123-456",
              "InternalReferenceId": 1000000,
              "additionalData": null,
              "externalPaypointID": "Paypoint-100",
              "StoredMethods": []
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/Vendor/1").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Vendor.GetVendorAsync(1);
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<VendorQueryRecord>(mockResponse)).UsingDefaults()
        );
    }
}
