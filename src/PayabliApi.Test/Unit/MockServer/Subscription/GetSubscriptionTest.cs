using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Subscription;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetSubscriptionTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "CreatedAt": "2022-07-01T15:00:01.000Z",
              "Customer": {
                "BillingAddress1": "1111 West 1st Street",
                "BillingAddress2": "Suite 200",
                "BillingCity": "Miami",
                "BillingCountry": "US",
                "BillingEmail": "example@email.com",
                "BillingPhone": "5555555555",
                "BillingState": "FL",
                "BillingZip": "45567",
                "CompanyName": "Sunshine LLC",
                "customerId": 4440,
                "CustomerNumber": "C-90010",
                "customerStatus": 1,
                "FirstName": "John",
                "Identifiers": [
                  "\\\"firstname\\\"",
                  "\\\"lastname\\\"",
                  "\\\"email\\\"",
                  "\\\"customId\\\""
                ],
                "LastName": "Doe",
                "ShippingAddress1": "123 Walnut St",
                "ShippingAddress2": "STE 900",
                "ShippingCity": "Johnson City",
                "ShippingCountry": "US",
                "ShippingState": "TN",
                "ShippingZip": "37619"
              },
              "EndDate": "2025-10-19T00:00:00.000Z",
              "EntrypageId": 0,
              "ExternalPaypointID": "Paypoint-100",
              "FeeAmount": 3,
              "Frequency": "monthly",
              "IdSub": 396,
              "invoiceData": {
                "attachments": [
                  {}
                ],
                "company": "ACME, INC",
                "discount": 10,
                "dutyAmount": 0,
                "firstName": "Chad",
                "freightAmount": 10,
                "frequency": "onetime",
                "invoiceAmount": 105,
                "invoiceDate": "2025-07-01",
                "invoiceDueDate": "2025-07-01",
                "invoiceEndDate": "2025-07-01",
                "invoiceNumber": "INV-2345",
                "invoiceStatus": 1,
                "invoiceType": 0,
                "items": [
                  {
                    "itemCost": 5,
                    "itemProductName": "Materials deposit",
                    "itemQty": 1
                  }
                ],
                "lastName": "Mercia",
                "notes": "Example notes.",
                "paymentTerms": "PIA",
                "purchaseOrder": "PO-345",
                "shippingAddress1": "123 Walnut St",
                "shippingAddress2": "STE 900",
                "shippingCity": "Johnson City",
                "shippingCountry": "US",
                "shippingEmail": "example@email.com",
                "shippingFromZip": "30040",
                "shippingPhone": "5555555555",
                "shippingState": "TN",
                "shippingZip": "37619",
                "summaryCommodityCode": "501718",
                "tax": 2.05,
                "termsConditions": "Must be paid before work scheduled."
              },
              "LastRun": "2025-10-19T00:00:00.000Z",
              "LastUpdated": "2022-07-01T15:00:01.000Z",
              "LeftCycles": 15,
              "Method": "card",
              "NetAmount": 3762.87,
              "NextDate": "2025-10-19T00:00:00.000Z",
              "ParentOrgName": "PropertyManager Pro",
              "PaymentData": {
                "AccountExp": "11/29",
                "accountId": "accountId",
                "AccountType": "visa",
                "AccountZip": "90210",
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
                "HolderName": "Chad Mercia",
                "Initiator": "payor",
                "MaskedAccount": "4XXXXXXXX1111",
                "orderDescription": "Depost for materials for 123 Walnut St",
                "paymentDetails": {
                  "categories": [
                    {
                      "amount": 1000,
                      "label": "Deposit"
                    }
                  ],
                  "checkImage": {
                    "key": "value"
                  },
                  "checkNumber": "107",
                  "currency": "USD",
                  "serviceFee": 0,
                  "splitFunding": [
                    {}
                  ],
                  "totalAmount": 100
                },
                "Sequence": "subsequent",
                "SignatureData": "SignatureData",
                "StoredId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "StoredMethodUsageType": "subscription"
              },
              "PaypointDbaname": "Sunshine Gutters",
              "PaypointEntryname": "d193cf9a46",
              "PaypointId": 3040,
              "PaypointLegalname": "Sunshine Services, LLC",
              "PlanId": 0,
              "Source": "api",
              "StartDate": "2025-10-19T00:00:00.000Z",
              "SubEvents": [
                {
                  "description": "TransferCreated",
                  "eventTime": "2023-07-05T22:31:06.000Z",
                  "refData": "refData",
                  "source": "api"
                }
              ],
              "SubStatus": 1,
              "SubscriptionType": "Regular",
              "TotalAmount": 103,
              "TotalCycles": 24,
              "UntilCancelled": true
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/Subscription/231").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Subscription.GetSubscriptionAsync(231);
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "CreatedAt": "2026-05-12T15:25:28.000Z",
              "Customer": {
                "BillingAddress1": "1111 West 1st Street",
                "BillingAddress2": "Suite 200",
                "BillingCity": "Miami",
                "BillingCountry": "US",
                "BillingEmail": "example@email.com",
                "BillingPhone": "5555555555",
                "BillingState": "FL",
                "BillingZip": "45567",
                "CompanyName": "Sunshine LLC",
                "customerId": 4440,
                "CustomerNumber": "C-90010",
                "customerStatus": 1,
                "FirstName": "John",
                "Identifiers": [
                  "\\\"firstname\\\"",
                  "\\\"lastname\\\""
                ],
                "LastName": "Doe",
                "ShippingAddress1": "123 Walnut St",
                "ShippingAddress2": "STE 900",
                "ShippingCity": "Johnson City",
                "ShippingCountry": "US",
                "ShippingState": "TN",
                "ShippingZip": "37619"
              },
              "EndDate": "2046-05-01T00:00:00.000Z",
              "EntrypageId": 0,
              "ExternalPaypointID": "Paypoint-100",
              "FeeAmount": 0,
              "Frequency": "firstofmonth",
              "IdSub": 50317,
              "LastRun": "2026-05-13T14:14:22.000Z",
              "LastUpdated": "2026-05-12T15:25:28.000Z",
              "LeftCycles": 238,
              "Method": "card",
              "NetAmount": 0,
              "NextDate": "2026-06-01T00:00:00.000Z",
              "ParentOrgName": "PropertyManager Pro",
              "PaymentData": {
                "AccountExp": "11/29",
                "accountId": "accountId",
                "AccountType": "visa",
                "AccountZip": "90210",
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
                "HolderName": "Chad Mercia",
                "Initiator": "payor",
                "MaskedAccount": "4XXXXXXXX1111",
                "paymentDetails": {
                  "categories": [],
                  "currency": "USD",
                  "serviceFee": 0,
                  "splitFunding": [],
                  "totalAmount": 0
                },
                "Sequence": "subsequent",
                "StoredId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "StoredMethodUsageType": "subscription"
              },
              "PaypointDbaname": "Sunshine Gutters",
              "PaypointEntryname": "d193cf9a46",
              "PaypointId": 3040,
              "PaypointLegalname": "Sunshine Services, LLC",
              "PlanId": 0,
              "Source": "api",
              "StartDate": "2026-05-01T00:00:00.000Z",
              "StoredMethod": {
                "IdPmethod": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "Method": "card",
                "Descriptor": "visa",
                "MaskedAccount": "4XXXXXXXX1111",
                "ExpDate": "1129",
                "HolderName": "Chad Mercia",
                "IsValidatedACH": false,
                "BIN": "",
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
                "ABA": "",
                "PostalCode": "37619",
                "MethodType": "Single Merchant",
                "LastUpdated": "2026-05-12T15:25:28.000Z",
                "CardUpdatedOn": "1970-01-01T00:00:00.000Z"
              },
              "SubEvents": [
                {
                  "description": "created",
                  "eventTime": "2026-05-12T15:25:27.000Z",
                  "refData": "0HNLG6L6JNIP5:00000001"
                },
                {
                  "description": "executed",
                  "eventTime": "2026-05-13T14:14:27.000Z",
                  "extraData": "{\"totalAmount\":13.5,\"serviceFee\":1.5}",
                  "refData": "autopay worker"
                }
              ],
              "SubStatus": 1,
              "SubscriptionType": "BalanceDriven",
              "TotalAmount": 0,
              "TotalCycles": 239,
              "UntilCancelled": true
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/Subscription/231").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Subscription.GetSubscriptionAsync(231);
        JsonAssert.AreEqual(response, mockResponse);
    }
}
