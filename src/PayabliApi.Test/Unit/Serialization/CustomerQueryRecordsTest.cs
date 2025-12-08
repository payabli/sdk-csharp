using System.Globalization;
using System.Text.Json;
using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test;

[TestFixture]
public class CustomerQueryRecordsTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization_1()
    {
        var json = """
            {
              "customerId": 4440,
              "customerNumber": "3456-7645A",
              "customerUsername": "myusername",
              "customerStatus": 1,
              "Company": "AA LLC",
              "Firstname": "John",
              "Lastname": "Smith",
              "Phone": "1234567890",
              "Email": "example@email.com",
              "Address": "3245 Main St",
              "Address1": "STE 900",
              "City": "Miami",
              "State": "FL",
              "Zip": "77777",
              "Country": "US",
              "ShippingAddress": "123 Walnut St",
              "ShippingAddress1": "STE 900",
              "ShippingCity": "Johnson City",
              "ShippingState": "TN",
              "ShippingZip": "37619",
              "ShippingCountry": "US",
              "Balance": 1.1,
              "TimeZone": -5,
              "MFA": false,
              "MFAMode": 0,
              "snProvider": "facebook",
              "snIdentifier": "6677fgttyudd999",
              "snData": "",
              "LastUpdated": "2021-06-16T05:00:00Z",
              "Created": "2021-06-10T05:00:00Z",
              "AdditionalFields": {
                "property1": "string",
                "property2": "string"
              },
              "IdentifierFields": [
                "email"
              ],
              "Subscriptions": [
                {
                  "CreatedAt": "2022-07-01T15:00:01Z",
                  "EndDate": "2025-10-19T00:00:00Z",
                  "EntrypageId": 0,
                  "ExternalPaypointID": "Paypoint-100",
                  "FeeAmount": 3,
                  "Frequency": "monthly",
                  "IdSub": 396,
                  "LastRun": "2025-10-19T00:00:00Z",
                  "LastUpdated": "2022-07-01T15:00:01Z",
                  "LeftCycles": 15,
                  "Method": "card",
                  "NetAmount": 3762.87,
                  "NextDate": "2025-10-19T00:00:00Z",
                  "ParentOrgName": "PropertyManager Pro",
                  "PaymentData": {
                    "paymentDetails": {
                      "totalAmount": 100
                    }
                  },
                  "PaypointDbaname": "Sunshine Gutters",
                  "PaypointEntryname": "d193cf9a46",
                  "PaypointId": 255,
                  "PaypointLegalname": "Sunshine Services, LLC",
                  "PlanId": 0,
                  "Source": "api",
                  "StartDate": "2025-10-19T00:00:00Z",
                  "SubEvents": [
                    {
                      "description": "TransferCreated",
                      "eventTime": "2023-07-05T22:31:06Z"
                    }
                  ],
                  "SubStatus": 1,
                  "TotalAmount": 103,
                  "TotalCycles": 24,
                  "UntilCancelled": true
                }
              ],
              "StoredMethods": [
                {
                  "bin": "411111",
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
                  "descriptor": "visa",
                  "expDate": "1227",
                  "holderName": "Chad Mercia",
                  "idPmethod": "6edcbb56-9c0e-4003-b3d1-99abf149ba0e",
                  "lastUpdated": "2022-07-01T15:00:01Z",
                  "maskedAccount": "4XXXXXXXX1111",
                  "method": "card"
                }
              ],
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
              "PaypointLegalname": "Sunshine Services, LLC",
              "PaypointDbaname": "Sunshine Gutters",
              "ParentOrgName": "PropertyManager Pro",
              "ParentOrgId": 123,
              "PaypointEntryname": "d193cf9a46",
              "pageidentifier": "null",
              "externalPaypointID": "Paypoint-100",
              "customerConsent": {
                "eCommunication": {
                  "status": 1,
                  "updatedAt": "2022-07-01T15:00:01Z"
                },
                "sms": {
                  "status": 1,
                  "updatedAt": "2022-07-01T15:00:01Z"
                }
              }
            }
            """;
        var expectedObject = new CustomerQueryRecords
        {
            CustomerId = 4440,
            CustomerNumber = "3456-7645A",
            CustomerUsername = "myusername",
            CustomerStatus = 1,
            Company = "AA LLC",
            Firstname = "John",
            Lastname = "Smith",
            Phone = "1234567890",
            Email = "example@email.com",
            Address = "3245 Main St",
            Address1 = "STE 900",
            City = "Miami",
            State = "FL",
            Zip = "77777",
            Country = "US",
            ShippingAddress = "123 Walnut St",
            ShippingAddress1 = "STE 900",
            ShippingCity = "Johnson City",
            ShippingState = "TN",
            ShippingZip = "37619",
            ShippingCountry = "US",
            Balance = 1.1,
            TimeZone = -5,
            Mfa = false,
            MfaMode = 0,
            SnProvider = "facebook",
            SnIdentifier = "6677fgttyudd999",
            SnData = "",
            LastUpdated = DateTime.Parse(
                "2021-06-16T05:00:00.000Z",
                null,
                DateTimeStyles.AdjustToUniversal
            ),
            Created = DateTime.Parse(
                "2021-06-10T05:00:00.000Z",
                null,
                DateTimeStyles.AdjustToUniversal
            ),
            AdditionalFields = new Dictionary<string, string?>()
            {
                { "property1", "string" },
                { "property2", "string" },
            },
            IdentifierFields = new List<string>() { "email" },
            Subscriptions = new List<SubscriptionQueryRecords>()
            {
                new SubscriptionQueryRecords
                {
                    CreatedAt = DateTime.Parse(
                        "2022-07-01T15:00:01.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    EndDate = DateTime.Parse(
                        "2025-10-19T00:00:00.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    EntrypageId = 0,
                    ExternalPaypointId = "Paypoint-100",
                    FeeAmount = 3,
                    Frequency = "monthly",
                    IdSub = 396,
                    LastRun = DateTime.Parse(
                        "2025-10-19T00:00:00.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    LastUpdated = DateTime.Parse(
                        "2022-07-01T15:00:01.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    LeftCycles = 15,
                    Method = "card",
                    NetAmount = 3762.87,
                    NextDate = DateTime.Parse(
                        "2025-10-19T00:00:00.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    ParentOrgName = "PropertyManager Pro",
                    PaymentData = new QueryPaymentData
                    {
                        PaymentDetails = new PaymentDetail { TotalAmount = 100 },
                    },
                    PaypointDbaname = "Sunshine Gutters",
                    PaypointEntryname = "d193cf9a46",
                    PaypointId = 255,
                    PaypointLegalname = "Sunshine Services, LLC",
                    PlanId = 0,
                    Source = "api",
                    StartDate = DateTime.Parse(
                        "2025-10-19T00:00:00.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    SubEvents = new List<GeneralEvents>()
                    {
                        new GeneralEvents
                        {
                            Description = "TransferCreated",
                            EventTime = DateTime.Parse(
                                "2023-07-05T22:31:06.000Z",
                                null,
                                DateTimeStyles.AdjustToUniversal
                            ),
                        },
                    },
                    SubStatus = 1,
                    TotalAmount = 103,
                    TotalCycles = 24,
                    UntilCancelled = true,
                },
            },
            StoredMethods = new List<MethodQueryRecords>()
            {
                new MethodQueryRecords
                {
                    Bin = "411111",
                    BinData = new BinData
                    {
                        BinMatchedLength = "6",
                        BinCardBrand = "Visa",
                        BinCardType = "Credit",
                        BinCardCategory = "PLATINUM",
                        BinCardIssuer = "Bank of Example",
                        BinCardIssuerCountry = "United States",
                        BinCardIssuerCountryCodeA2 = "US",
                        BinCardIssuerCountryNumber = "840",
                        BinCardIsRegulated = "false",
                        BinCardUseCategory = "Consumer",
                        BinCardIssuerCountryCodeA3 = "USA",
                    },
                    Descriptor = "visa",
                    ExpDate = "1227",
                    HolderName = "Chad Mercia",
                    IdPmethod = "6edcbb56-9c0e-4003-b3d1-99abf149ba0e",
                    LastUpdated = DateTime.Parse(
                        "2022-07-01T15:00:01.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    MaskedAccount = "4XXXXXXXX1111",
                    Method = "card",
                },
            },
            CustomerSummary = new CustomerSummaryRecord
            {
                NumberofTransactions = 30,
                RecentTransactions = new List<TransactionQueryRecords>()
                {
                    new TransactionQueryRecords
                    {
                        EntrypageId = 0,
                        FeeAmount = 1,
                        PayorId = 1551,
                        PaypointId = 226,
                        SettlementStatus = 2,
                        TotalAmount = 30.22,
                        TransStatus = 1,
                    },
                },
                TotalAmountTransactions = 1500,
                TotalNetAmountTransactions = 1500,
            },
            PaypointLegalname = "Sunshine Services, LLC",
            PaypointDbaname = "Sunshine Gutters",
            ParentOrgName = "PropertyManager Pro",
            ParentOrgId = 123,
            PaypointEntryname = "d193cf9a46",
            Pageidentifier = "null",
            ExternalPaypointId = "Paypoint-100",
            CustomerConsent = new CustomerQueryRecordsCustomerConsent
            {
                ECommunication = new CustomerQueryRecordsCustomerConsentECommunication
                {
                    Status = 1,
                    UpdatedAt = DateTime.Parse(
                        "2022-07-01T15:00:01.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                },
                Sms = new CustomerQueryRecordsCustomerConsentSms
                {
                    Status = 1,
                    UpdatedAt = DateTime.Parse(
                        "2022-07-01T15:00:01.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                },
            },
        };
        var deserializedObject = JsonUtils.Deserialize<CustomerQueryRecords>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_1()
    {
        var expectedJson = """
            {
              "customerId": 4440,
              "customerNumber": "3456-7645A",
              "customerUsername": "myusername",
              "customerStatus": 1,
              "Company": "AA LLC",
              "Firstname": "John",
              "Lastname": "Smith",
              "Phone": "1234567890",
              "Email": "example@email.com",
              "Address": "3245 Main St",
              "Address1": "STE 900",
              "City": "Miami",
              "State": "FL",
              "Zip": "77777",
              "Country": "US",
              "ShippingAddress": "123 Walnut St",
              "ShippingAddress1": "STE 900",
              "ShippingCity": "Johnson City",
              "ShippingState": "TN",
              "ShippingZip": "37619",
              "ShippingCountry": "US",
              "Balance": 1.1,
              "TimeZone": -5,
              "MFA": false,
              "MFAMode": 0,
              "snProvider": "facebook",
              "snIdentifier": "6677fgttyudd999",
              "snData": "",
              "LastUpdated": "2021-06-16T05:00:00Z",
              "Created": "2021-06-10T05:00:00Z",
              "AdditionalFields": {
                "property1": "string",
                "property2": "string"
              },
              "IdentifierFields": [
                "email"
              ],
              "Subscriptions": [
                {
                  "CreatedAt": "2022-07-01T15:00:01Z",
                  "EndDate": "2025-10-19T00:00:00Z",
                  "EntrypageId": 0,
                  "ExternalPaypointID": "Paypoint-100",
                  "FeeAmount": 3,
                  "Frequency": "monthly",
                  "IdSub": 396,
                  "LastRun": "2025-10-19T00:00:00Z",
                  "LastUpdated": "2022-07-01T15:00:01Z",
                  "LeftCycles": 15,
                  "Method": "card",
                  "NetAmount": 3762.87,
                  "NextDate": "2025-10-19T00:00:00Z",
                  "ParentOrgName": "PropertyManager Pro",
                  "PaymentData": {
                    "paymentDetails": {
                      "totalAmount": 100
                    }
                  },
                  "PaypointDbaname": "Sunshine Gutters",
                  "PaypointEntryname": "d193cf9a46",
                  "PaypointId": 255,
                  "PaypointLegalname": "Sunshine Services, LLC",
                  "PlanId": 0,
                  "Source": "api",
                  "StartDate": "2025-10-19T00:00:00Z",
                  "SubEvents": [
                    {
                      "description": "TransferCreated",
                      "eventTime": "2023-07-05T22:31:06Z"
                    }
                  ],
                  "SubStatus": 1,
                  "TotalAmount": 103,
                  "TotalCycles": 24,
                  "UntilCancelled": true
                }
              ],
              "StoredMethods": [
                {
                  "bin": "411111",
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
                  "descriptor": "visa",
                  "expDate": "1227",
                  "holderName": "Chad Mercia",
                  "idPmethod": "6edcbb56-9c0e-4003-b3d1-99abf149ba0e",
                  "lastUpdated": "2022-07-01T15:00:01Z",
                  "maskedAccount": "4XXXXXXXX1111",
                  "method": "card"
                }
              ],
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
              "PaypointLegalname": "Sunshine Services, LLC",
              "PaypointDbaname": "Sunshine Gutters",
              "ParentOrgName": "PropertyManager Pro",
              "ParentOrgId": 123,
              "PaypointEntryname": "d193cf9a46",
              "pageidentifier": "null",
              "externalPaypointID": "Paypoint-100",
              "customerConsent": {
                "eCommunication": {
                  "status": 1,
                  "updatedAt": "2022-07-01T15:00:01Z"
                },
                "sms": {
                  "status": 1,
                  "updatedAt": "2022-07-01T15:00:01Z"
                }
              }
            }
            """;
        var actualObj = new CustomerQueryRecords
        {
            CustomerId = 4440,
            CustomerNumber = "3456-7645A",
            CustomerUsername = "myusername",
            CustomerStatus = 1,
            Company = "AA LLC",
            Firstname = "John",
            Lastname = "Smith",
            Phone = "1234567890",
            Email = "example@email.com",
            Address = "3245 Main St",
            Address1 = "STE 900",
            City = "Miami",
            State = "FL",
            Zip = "77777",
            Country = "US",
            ShippingAddress = "123 Walnut St",
            ShippingAddress1 = "STE 900",
            ShippingCity = "Johnson City",
            ShippingState = "TN",
            ShippingZip = "37619",
            ShippingCountry = "US",
            Balance = 1.1,
            TimeZone = -5,
            Mfa = false,
            MfaMode = 0,
            SnProvider = "facebook",
            SnIdentifier = "6677fgttyudd999",
            SnData = "",
            LastUpdated = DateTime.Parse(
                "2021-06-16T05:00:00.000Z",
                null,
                DateTimeStyles.AdjustToUniversal
            ),
            Created = DateTime.Parse(
                "2021-06-10T05:00:00.000Z",
                null,
                DateTimeStyles.AdjustToUniversal
            ),
            AdditionalFields = new Dictionary<string, string?>()
            {
                { "property1", "string" },
                { "property2", "string" },
            },
            IdentifierFields = new List<string>() { "email" },
            Subscriptions = new List<SubscriptionQueryRecords>()
            {
                new SubscriptionQueryRecords
                {
                    CreatedAt = DateTime.Parse(
                        "2022-07-01T15:00:01.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    EndDate = DateTime.Parse(
                        "2025-10-19T00:00:00.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    EntrypageId = 0,
                    ExternalPaypointId = "Paypoint-100",
                    FeeAmount = 3,
                    Frequency = "monthly",
                    IdSub = 396,
                    LastRun = DateTime.Parse(
                        "2025-10-19T00:00:00.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    LastUpdated = DateTime.Parse(
                        "2022-07-01T15:00:01.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    LeftCycles = 15,
                    Method = "card",
                    NetAmount = 3762.87,
                    NextDate = DateTime.Parse(
                        "2025-10-19T00:00:00.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    ParentOrgName = "PropertyManager Pro",
                    PaymentData = new QueryPaymentData
                    {
                        PaymentDetails = new PaymentDetail { TotalAmount = 100 },
                    },
                    PaypointDbaname = "Sunshine Gutters",
                    PaypointEntryname = "d193cf9a46",
                    PaypointId = 255,
                    PaypointLegalname = "Sunshine Services, LLC",
                    PlanId = 0,
                    Source = "api",
                    StartDate = DateTime.Parse(
                        "2025-10-19T00:00:00.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    SubEvents = new List<GeneralEvents>()
                    {
                        new GeneralEvents
                        {
                            Description = "TransferCreated",
                            EventTime = DateTime.Parse(
                                "2023-07-05T22:31:06.000Z",
                                null,
                                DateTimeStyles.AdjustToUniversal
                            ),
                        },
                    },
                    SubStatus = 1,
                    TotalAmount = 103,
                    TotalCycles = 24,
                    UntilCancelled = true,
                },
            },
            StoredMethods = new List<MethodQueryRecords>()
            {
                new MethodQueryRecords
                {
                    Bin = "411111",
                    BinData = new BinData
                    {
                        BinMatchedLength = "6",
                        BinCardBrand = "Visa",
                        BinCardType = "Credit",
                        BinCardCategory = "PLATINUM",
                        BinCardIssuer = "Bank of Example",
                        BinCardIssuerCountry = "United States",
                        BinCardIssuerCountryCodeA2 = "US",
                        BinCardIssuerCountryNumber = "840",
                        BinCardIsRegulated = "false",
                        BinCardUseCategory = "Consumer",
                        BinCardIssuerCountryCodeA3 = "USA",
                    },
                    Descriptor = "visa",
                    ExpDate = "1227",
                    HolderName = "Chad Mercia",
                    IdPmethod = "6edcbb56-9c0e-4003-b3d1-99abf149ba0e",
                    LastUpdated = DateTime.Parse(
                        "2022-07-01T15:00:01.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    MaskedAccount = "4XXXXXXXX1111",
                    Method = "card",
                },
            },
            CustomerSummary = new CustomerSummaryRecord
            {
                NumberofTransactions = 30,
                RecentTransactions = new List<TransactionQueryRecords>()
                {
                    new TransactionQueryRecords
                    {
                        EntrypageId = 0,
                        FeeAmount = 1,
                        PayorId = 1551,
                        PaypointId = 226,
                        SettlementStatus = 2,
                        TotalAmount = 30.22,
                        TransStatus = 1,
                    },
                },
                TotalAmountTransactions = 1500,
                TotalNetAmountTransactions = 1500,
            },
            PaypointLegalname = "Sunshine Services, LLC",
            PaypointDbaname = "Sunshine Gutters",
            ParentOrgName = "PropertyManager Pro",
            ParentOrgId = 123,
            PaypointEntryname = "d193cf9a46",
            Pageidentifier = "null",
            ExternalPaypointId = "Paypoint-100",
            CustomerConsent = new CustomerQueryRecordsCustomerConsent
            {
                ECommunication = new CustomerQueryRecordsCustomerConsentECommunication
                {
                    Status = 1,
                    UpdatedAt = DateTime.Parse(
                        "2022-07-01T15:00:01.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                },
                Sms = new CustomerQueryRecordsCustomerConsentSms
                {
                    Status = 1,
                    UpdatedAt = DateTime.Parse(
                        "2022-07-01T15:00:01.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                },
            },
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_2()
    {
        var json = """
            {
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
              "LastUpdated": "2024-03-13T12:49:56Z",
              "Created": "2024-03-13T12:49:56Z",
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
            }
            """;
        var expectedObject = new CustomerQueryRecords
        {
            CustomerId = 17264,
            CustomerNumber = "12356ACB",
            CustomerUsername = null,
            CustomerStatus = 0,
            Company = null,
            Firstname = "Irene",
            Lastname = "Canizales",
            Phone = null,
            Email = "irene@canizalesconcrete.com",
            Address = null,
            Address1 = "123 Bishop's Trail",
            City = "Mountain City",
            State = "TN",
            Zip = "37612",
            Country = "US",
            ShippingAddress = null,
            ShippingAddress1 = null,
            ShippingCity = null,
            ShippingState = null,
            ShippingZip = null,
            ShippingCountry = null,
            Balance = 0,
            TimeZone = -5,
            Mfa = false,
            MfaMode = 0,
            SnProvider = null,
            SnIdentifier = null,
            SnData = null,
            LastUpdated = DateTime.Parse(
                "2024-03-13T12:49:56.000Z",
                null,
                DateTimeStyles.AdjustToUniversal
            ),
            Created = DateTime.Parse(
                "2024-03-13T12:49:56.000Z",
                null,
                DateTimeStyles.AdjustToUniversal
            ),
            AdditionalFields = new Dictionary<string, string?>() { { "key", "value" } },
            IdentifierFields = new List<string>() { "email" },
            Subscriptions = null,
            StoredMethods = null,
            CustomerSummary = new CustomerSummaryRecord
            {
                NumberofTransactions = 30,
                RecentTransactions = new List<TransactionQueryRecords>()
                {
                    new TransactionQueryRecords
                    {
                        EntrypageId = 0,
                        FeeAmount = 1,
                        PayorId = 1551,
                        PaypointId = 226,
                        SettlementStatus = 2,
                        TotalAmount = 30.22,
                        TransStatus = 1,
                    },
                },
                TotalAmountTransactions = 1500,
                TotalNetAmountTransactions = 1500,
            },
            PaypointLegalname = "Gruzya Adventure Outfitters, LLC",
            PaypointDbaname = "Gruzya Adventure Outfitters",
            ParentOrgName = "The Pilgrim Planner",
            ParentOrgId = 123,
            PaypointEntryname = "41035afaa7",
            Pageidentifier = "null",
            ExternalPaypointId = null,
            CustomerConsent = null,
        };
        var deserializedObject = JsonUtils.Deserialize<CustomerQueryRecords>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_2()
    {
        var expectedJson = """
            {
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
              "LastUpdated": "2024-03-13T12:49:56Z",
              "Created": "2024-03-13T12:49:56Z",
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
            }
            """;
        var actualObj = new CustomerQueryRecords
        {
            CustomerId = 17264,
            CustomerNumber = "12356ACB",
            CustomerUsername = null,
            CustomerStatus = 0,
            Company = null,
            Firstname = "Irene",
            Lastname = "Canizales",
            Phone = null,
            Email = "irene@canizalesconcrete.com",
            Address = null,
            Address1 = "123 Bishop's Trail",
            City = "Mountain City",
            State = "TN",
            Zip = "37612",
            Country = "US",
            ShippingAddress = null,
            ShippingAddress1 = null,
            ShippingCity = null,
            ShippingState = null,
            ShippingZip = null,
            ShippingCountry = null,
            Balance = 0,
            TimeZone = -5,
            Mfa = false,
            MfaMode = 0,
            SnProvider = null,
            SnIdentifier = null,
            SnData = null,
            LastUpdated = DateTime.Parse(
                "2024-03-13T12:49:56.000Z",
                null,
                DateTimeStyles.AdjustToUniversal
            ),
            Created = DateTime.Parse(
                "2024-03-13T12:49:56.000Z",
                null,
                DateTimeStyles.AdjustToUniversal
            ),
            AdditionalFields = new Dictionary<string, string?>() { { "key", "value" } },
            IdentifierFields = new List<string>() { "email" },
            Subscriptions = null,
            StoredMethods = null,
            CustomerSummary = new CustomerSummaryRecord
            {
                NumberofTransactions = 30,
                RecentTransactions = new List<TransactionQueryRecords>()
                {
                    new TransactionQueryRecords
                    {
                        EntrypageId = 0,
                        FeeAmount = 1,
                        PayorId = 1551,
                        PaypointId = 226,
                        SettlementStatus = 2,
                        TotalAmount = 30.22,
                        TransStatus = 1,
                    },
                },
                TotalAmountTransactions = 1500,
                TotalNetAmountTransactions = 1500,
            },
            PaypointLegalname = "Gruzya Adventure Outfitters, LLC",
            PaypointDbaname = "Gruzya Adventure Outfitters",
            ParentOrgName = "The Pilgrim Planner",
            ParentOrgId = 123,
            PaypointEntryname = "41035afaa7",
            Pageidentifier = "null",
            ExternalPaypointId = null,
            CustomerConsent = null,
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }
}
