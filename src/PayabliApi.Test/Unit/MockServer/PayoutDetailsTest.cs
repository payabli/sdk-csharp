using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class PayoutDetailsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "Bills": [
                {
                  "invoiceNumber": "123B",
                  "netAmount": "8800.00"
                }
              ],
              "CheckData": null,
              "CheckNumber": null,
              "Comments": "testing",
              "CreatedDate": "2022-07-01T15:00:01.000Z",
              "Events": [
                {
                  "EventTime": "2023-04-24T09:17:49.000Z",
                  "TransEvent": "Authorized"
                }
              ],
              "FeeAmount": 0,
              "Gateway": "TSYS",
              "IdOut": 350,
              "LastUpdated": "2023-04-23T17:00:00.000Z",
              "NetAmount": 8800,
              "ParentOrgName": "PropertyManager Pro",
              "PaymentData": {
                "AccountType": "",
                "binData": {
                  "binMatchedLength": "6",
                  "binCardBrand": "Visa",
                  "binCardType": "Credit",
                  "binCardCategory": "PLATINUM",
                  "binCardIssuer": "Bank of Example",
                  "binCardIssuerCountry": "United States",
                  "binCardIssuerCountryCodeA2": "US",
                  "binCardIssuerCountryNumber": "840",
                  "binCardIsRegulated": "false",
                  "binCardUseCategory": "Consumer",
                  "binCardIssuerCountryCodeA3": "USA"
                },
                "HolderName": "",
                "Initiator": "payor",
                "MaskedAccount": "",
                "Sequence": "subsequent",
                "SignatureData": "SignatureData",
                "StoredMethodUsageType": "subscription"
              },
              "PaymentGroup": "2345667-ddd-fff",
              "PaymentId": "12345678910",
              "PaymentMethod": "managed",
              "PaymentStatus": "Authorized",
              "PaypointDbaname": "Sunshine Gutters",
              "PaypointLegalname": "Sunshine Services, LLC",
              "Source": "api",
              "Status": 11,
              "StatusText": "Captured",
              "TotalAmount": 8800,
              "Vendor": {
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
              },
              "CreatedAt": null,
              "ParentOrgId": null,
              "externalPaypointID": null,
              "EntryName": null,
              "BatchId": null,
              "HasVcardTransactions": false,
              "IsSameDayACH": false,
              "ScheduleId": null,
              "SettlementStatus": null,
              "RiskFlagged": false,
              "RiskFlaggedOn": null,
              "RiskStatus": null,
              "RiskReason": null,
              "RiskAction": null,
              "RiskActionCode": null
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyOut/details/45-as456777hhhhhhhhhh77777777-324")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyOut.PayoutDetailsAsync(
            "45-as456777hhhhhhhhhh77777777-324"
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BillDetailResponse>(mockResponse)).UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "Bills": [
                {
                  "invoiceNumber": "123B",
                  "netAmount": "8800.00"
                }
              ],
              "CheckData": null,
              "CheckNumber": null,
              "Comments": "testing",
              "CreatedDate": "2022-07-01T15:00:01.000Z",
              "Events": [
                {
                  "EventTime": "2023-04-24T09:00:33.000Z",
                  "TransEvent": "Authorized"
                },
                {
                  "EventData": {
                    "custId": "PAYABLITST",
                    "dateCreated": "2023-04-24T16:14:28.000Z",
                    "dateModified": "2023-04-24T16:14:28.000Z",
                    "group": {
                      "approved": false,
                      "custId": "PAYABLITST",
                      "dateCreated": "2023-04-24T16:14:28.000Z",
                      "dateModified": "2023-04-24T16:14:28.000Z",
                      "id": "acd5ddd9-42be-4822-bc02-46e7c560d8a4",
                      "links": [
                        {
                          "href": "https://cert-api.cpayplus.com/payments/groups/acd5ddd9-42be-4822-bc02-46e7c560d8a4",
                          "rel": "cancel",
                          "type": "DELETE"
                        },
                        {
                          "href": "https://cert-api.cpayplus.com/payments/groups/acd5ddd9-42be-4822-bc02-46e7c560d8a4/approve",
                          "rel": "approve",
                          "type": "POST"
                        },
                        {
                          "href": "https://cert-api.cpayplus.com/payments/groups/acd5ddd9-42be-4822-bc02-46e7c560d8a4",
                          "rel": "self",
                          "type": "GET"
                        }
                      ],
                      "name": "187-20230424-PAYABLITST",
                      "status": "Waiting Funds",
                      "totalAmount": "8800.00"
                    },
                    "id": "1ede3eb2-a564-43b5-b2d2-7195f6d9fded",
                    "invoices": [
                      {
                        "invoiceNumber": "123B",
                        "netAmount": "8800.00"
                      }
                    ],
                    "links": [
                      {
                        "href": "https://cert-api.cpayplus.com/payments/1ede3eb2-a564-43b5-b2d2-7195f6d9fded/resendRemit",
                        "rel": "resendRemit",
                        "type": "POST"
                      },
                      {
                        "href": "https://cert-api.cpayplus.com/payments/1ede3eb2-a564-43b5-b2d2-7195f6d9fded",
                        "rel": "cancel",
                        "type": "DELETE"
                      },
                      {
                        "href": "https://cert-api.cpayplus.com/payments/1ede3eb2-a564-43b5-b2d2-7195f6d9fded",
                        "rel": "self",
                        "type": "GET"
                      },
                      {
                        "href": "https://cert-api.cpayplus.com/payments/1ede3eb2-a564-43b5-b2d2-7195f6d9fded/reissue",
                        "rel": "reissue",
                        "type": "POST"
                      }
                    ],
                    "paymentNumber": "187-349",
                    "paymentStatus": "Awaiting Funds",
                    "paymentType": "VCard",
                    "remitAddress": {
                      "address1": "5724 daughtery downs Loop",
                      "address2": "",
                      "city": "Lakeland",
                      "countryCode": "US",
                      "state": "FL",
                      "zip": "33809"
                    },
                    "vendor": {
                      "address": {
                        "address1": "5724 DAUGHTERY DOWNS LOOP",
                        "address2": "",
                        "city": "LAKELAND",
                        "countryCode": "US",
                        "state": "FL",
                        "zip": "33809"
                      },
                      "contactEmail": "paul@payabli.com",
                      "custId": "PAYABLITST",
                      "dateCreated": "2023-04-07T15:10:13.000Z",
                      "dateModified": "2023-04-17T15:39:33.000Z",
                      "email": "paul@payabli.com",
                      "id": "d7d92fac-fd8a-4ce9-8f92-62ee979b43fe",
                      "links": [
                        {
                          "href": "https://cert-api.cpayplus.com/payments/d7d92fac-fd8a-4ce9-8f92-62ee979b43fe",
                          "rel": "self",
                          "type": "GET"
                        }
                      ],
                      "paymentType": "VCard",
                      "status": "Enrolled",
                      "statusReason": "Customer Enrolled",
                      "vendorName1": "PAUL'S",
                      "vendorNumber": "54321",
                      "vendorPhone": "19706188888",
                      "vendorTaxId": "123456789"
                    }
                  },
                  "EventTime": "2023-04-24T09:14:28.000Z",
                  "TransEvent": "Captured"
                }
              ],
              "FeeAmount": 0,
              "Gateway": "TSYS",
              "IdOut": 349,
              "LastUpdated": "2023-04-23T17:00:00.000Z",
              "NetAmount": 8800,
              "ParentOrgName": "PropertyManager Pro",
              "PaymentData": {
                "AccountType": "",
                "binData": {
                  "binMatchedLength": "6",
                  "binCardBrand": "Visa",
                  "binCardType": "Credit",
                  "binCardCategory": "PLATINUM",
                  "binCardIssuer": "Bank of Example",
                  "binCardIssuerCountry": "United States",
                  "binCardIssuerCountryCodeA2": "US",
                  "binCardIssuerCountryNumber": "840",
                  "binCardIsRegulated": "false",
                  "binCardUseCategory": "Consumer",
                  "binCardIssuerCountryCodeA3": "USA"
                },
                "HolderName": "",
                "Initiator": "payor",
                "MaskedAccount": "",
                "Sequence": "subsequent",
                "SignatureData": "SignatureData",
                "StoredMethodUsageType": "subscription"
              },
              "PaymentGroup": "2345667-ddd-fff",
              "PaymentId": "1234567890",
              "PaymentMethod": "managed",
              "PaymentStatus": "Captured",
              "PaypointDbaname": "Sunshine Gutters",
              "PaypointLegalname": "Sunshine Services, LLC",
              "Source": "api",
              "Status": 1,
              "StatusText": "Captured",
              "TotalAmount": 8800,
              "Vendor": {
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
              },
              "CreatedAt": null,
              "ParentOrgId": null,
              "externalPaypointID": null,
              "EntryName": null,
              "BatchId": null,
              "HasVcardTransactions": false,
              "IsSameDayACH": false,
              "ScheduleId": null,
              "SettlementStatus": null,
              "RiskFlagged": false,
              "RiskFlaggedOn": null,
              "RiskStatus": null,
              "RiskReason": null,
              "RiskAction": null,
              "RiskActionCode": null
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyOut/details/45-as456777hhhhhhhhhh77777777-324")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyOut.PayoutDetailsAsync(
            "45-as456777hhhhhhhhhh77777777-324"
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BillDetailResponse>(mockResponse)).UsingDefaults()
        );
    }
}
