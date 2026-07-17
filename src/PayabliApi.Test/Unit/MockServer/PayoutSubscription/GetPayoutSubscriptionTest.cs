using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.PayoutSubscription;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetPayoutSubscriptionTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "responseData": {
                "idOutSubscription": 42,
                "status": 1,
                "events": [
                  {
                    "description": "TransferCreated",
                    "eventTime": "2025-09-01T06:00:00.000Z",
                    "refData": "refData",
                    "source": "api"
                  }
                ],
                "vendor": {
                  "VendorNumber": "VEN-123",
                  "Name1": "Herman's Coatings",
                  "Name2": "Herman's Coating Supply Company, LLC",
                  "EIN": "123456789",
                  "Phone": "2125551234",
                  "Email": "example@email.com",
                  "Address1": "123 Ocean Drive",
                  "Address2": "Suite 400",
                  "City": "Bristol",
                  "State": "GA",
                  "Zip": "31113",
                  "Country": "US",
                  "Mcc": "7777",
                  "LocationCode": "LOC123",
                  "Contacts": [
                    {
                      "ContactEmail": "eric@martinezcoatings.com",
                      "ContactName": "Eric Martinez",
                      "ContactPhone": "5555555555",
                      "ContactTitle": "Owner"
                    }
                  ],
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
                  "VendorStatus": 1,
                  "VendorId": 456,
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
                  "PaymentPortalUrl": "https://greenfield-landscaping.com/pay",
                  "CardAccepted": "yes",
                  "AchAccepted": "unable to determine",
                  "EnrichmentStatus": "fully_enriched",
                  "EnrichedBy": "web_search",
                  "EnrichedAt": "2026-03-05T14:22:10.000Z",
                  "EnrichmentId": "enrich-3890-a1b2c3d4",
                  "externalPaypointID": "Paypoint-100",
                  "StoredMethods": []
                },
                "billData": [
                  {
                    "billId": 54323,
                    "invoiceNumber": "INV-2345",
                    "netAmount": "500",
                    "invoiceDate": "2025-08-01",
                    "dueDate": "2025-08-15"
                  }
                ],
                "externalPaypointID": "d193cf9a46-10",
                "method": "ach",
                "paypointId": 3040,
                "totalAmount": 500,
                "netAmount": 500,
                "feeAmount": 0,
                "paymentData": {
                  "AccountType": "checking",
                  "HolderName": "Herman Coatings",
                  "Initiator": "merchant",
                  "MaskedAccount": "XXXXXX5666",
                  "paymentDetails": {
                    "currency": "USD",
                    "serviceFee": 0,
                    "totalAmount": 500
                  },
                  "Sequence": "subsequent",
                  "StoredMethodUsageType": "recurring"
                },
                "startDate": "2025-09-01T00:00:00.000Z",
                "endDate": "2026-09-01T00:00:00.000Z",
                "nextDate": "2025-10-01T00:00:00.000Z",
                "frequency": "monthly",
                "totalCycles": 12,
                "leftCycles": 11,
                "lastRun": "2025-09-01T06:00:00.000Z",
                "entrypageId": 0,
                "untilCancelled": false,
                "lastUpdated": "2025-08-01T12:00:00.000Z",
                "createdAt": "2025-08-01T12:00:00.000Z",
                "paypointLegalname": "Sunshine Services, LLC",
                "paypointDbaname": "Sunshine Gutters",
                "paypointEntryname": "d193cf9a46",
                "parentOrgName": "PropertyManager Pro",
                "parentOrgId": 236,
                "source": "api"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PayoutSubscription/42")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PayoutSubscription.GetPayoutSubscriptionAsync(42);
        JsonAssert.AreEqual(response, mockResponse);
    }
}
