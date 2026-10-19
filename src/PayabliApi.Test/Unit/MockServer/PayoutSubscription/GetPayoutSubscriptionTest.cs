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
                  "vendorNumber": "VEN-123",
                  "name1": "Herman's Coatings",
                  "name2": "Herman's Coating Supply Company, LLC",
                  "ein": "123456789",
                  "phone": "2125551234",
                  "email": "example@email.com",
                  "address1": "123 Ocean Drive",
                  "address2": "Suite 400",
                  "city": "Bristol",
                  "state": "GA",
                  "zip": "31113",
                  "country": "US",
                  "mcc": "7777",
                  "locationCode": "LOC123",
                  "issue1099": false,
                  "contacts": [
                    {
                      "contactName": "Eric Martinez",
                      "contactEmail": "eric@martinezcoatings.com",
                      "contactTitle": "Owner",
                      "contactPhone": "5555555555"
                    }
                  ],
                  "billingData": {
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
                    "default": true,
                    "country": "US"
                  },
                  "vendorStatus": 1,
                  "vendorId": 456,
                  "paypointLegalname": "Sunshine Services, LLC",
                  "paypointDbaname": "Sunshine Gutters",
                  "paypointEntryname": "d193cf9a46",
                  "parentOrgName": "PropertyManager Pro",
                  "parentOrgId": 1000,
                  "createdDate": "2022-07-01T15:00:01.000Z",
                  "lastUpdated": "2022-07-01T15:00:01.000Z",
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
                  "internalReferenceId": 1000000,
                  "paymentPortalUrl": "https://greenfield-landscaping.com/pay",
                  "cardAccepted": "yes",
                  "achAccepted": "unable to determine",
                  "enrichmentStatus": "fully_enriched",
                  "enrichedBy": "web_search",
                  "enrichedAt": "2026-03-05T14:22:10.000Z",
                  "enrichmentId": "enrich-3890-a1b2c3d4",
                  "externalPaypointID": "Paypoint-100"
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
                "sameDayAch": false,
                "doNotCreateBills": false,
                "allowDuplicatedBills": true,
                "autoConvertSameDayAch": false,
                "method": "ach",
                "paypointId": 3040,
                "totalAmount": 500,
                "netAmount": 500,
                "feeAmount": 0,
                "paymentData": {
                  "maskedAccount": "XXXXXX5666",
                  "accountType": "checking",
                  "holderName": "Herman Coatings",
                  "paymentDetails": {
                    "totalAmount": 500,
                    "serviceFee": 0,
                    "surchargeFee": 0,
                    "checkUniqueId": "",
                    "currency": "USD",
                    "categories": [],
                    "splitFunding": []
                  }
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

        var response = await Client.PayoutSubscription.GetPayoutSubscriptionAsync(42);
        JsonAssert.AreEqual(response, mockResponse);
    }
}
