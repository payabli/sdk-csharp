using System.Globalization;
using System.Text.Json;
using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test;

[TestFixture]
public class VendorDataResponseTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "VendorNumber": "1234",
              "Name1": "Herman's Coatings and Masonry",
              "Name2": "",
              "EIN": "XXXX6789",
              "Phone": "5555555555",
              "Email": "contact@hermanscoatings.com",
              "RemitEmail": null,
              "Address1": "123 Ocean Drive",
              "Address2": "Suite 400",
              "City": "Miami",
              "State": "FL",
              "Zip": "33139",
              "Country": "US",
              "Mcc": "7777",
              "LocationCode": "MIA123",
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
                "accountId": null,
                "nickname": "Checking Account",
                "bankName": "Country Bank",
                "routingAccount": "123123123",
                "accountNumber": "1XXXXXX3123",
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
              "VendorId": 1234,
              "EnrollmentStatus": null,
              "Summary": {
                "ActiveBills": 5,
                "PendingBills": 2,
                "InTransitBills": 1,
                "PaidBills": 10,
                "OverdueBills": 0,
                "ApprovedBills": 3,
                "DisapprovedBills": 0,
                "TotalBills": 21,
                "ActiveBillsAmount": 1500,
                "PendingBillsAmount": 500,
                "InTransitBillsAmount": 200,
                "PaidBillsAmount": 3000,
                "OverdueBillsAmount": 0,
                "ApprovedBillsAmount": 800,
                "DisapprovedBillsAmount": 0,
                "TotalBillsAmount": 6000
              },
              "PaypointLegalname": "Gruzya Adventure Outfitters LLC",
              "PaypointDbaname": "Gruzya Adventure Outfitters",
              "PaypointEntryname": "41035afaa7",
              "ParentOrgName": "Pilgrim Planner",
              "ParentOrgId": 1232,
              "CreatedDate": "2022-07-01T15:00:01Z",
              "LastUpdated": "2022-07-01T15:00:01Z",
              "remitAddress1": "123 Walnut Street",
              "remitAddress2": "Suite 900",
              "remitCity": "Miami",
              "remitState": "FL",
              "remitZip": "31113",
              "remitCountry": "US",
              "payeeName1": "Herman Martinez",
              "payeeName2": "",
              "customField1": "",
              "customField2": "",
              "customerVendorAccount": "A-37622",
              "InternalReferenceId": 123,
              "additionalData": {
                "customField": "Custom Value 1",
                "reference": "REF-12345",
                "notes": "Additional vendor information"
              },
              "externalPaypointID": "ext123",
              "StoredMethods": []
            }
            """;
        var expectedObject = new VendorDataResponse
        {
            VendorNumber = "1234",
            Name1 = "Herman's Coatings and Masonry",
            Name2 = "",
            Ein = "XXXX6789",
            Phone = "5555555555",
            Email = "contact@hermanscoatings.com",
            RemitEmail = null,
            Address1 = "123 Ocean Drive",
            Address2 = "Suite 400",
            City = "Miami",
            State = "FL",
            Zip = "33139",
            Country = "US",
            Mcc = "7777",
            LocationCode = "MIA123",
            Contacts = new List<ContactsResponse>()
            {
                new ContactsResponse
                {
                    ContactName = "Herman Martinez",
                    ContactEmail = "herman@hermanscoatings.com",
                    ContactTitle = "Owner",
                    ContactPhone = "3055550000",
                },
            },
            BillingData = new VendorResponseBillingData
            {
                Id = 123,
                AccountId = null,
                Nickname = "Checking Account",
                BankName = "Country Bank",
                RoutingAccount = "123123123",
                AccountNumber = "1XXXXXX3123",
                TypeAccount = "Checking",
                BankAccountHolderName = "Gruzya Adventure Outfitters LLC",
                BankAccountHolderType = "Business",
                BankAccountFunction = 0,
                Verified = true,
                Status = 1,
                Services = new List<object>() { },
                Default = true,
            },
            PaymentMethod = VendorDataResponsePaymentMethod.Vcard,
            VendorStatus = 1,
            VendorId = 1234,
            EnrollmentStatus = null,
            Summary = new VendorResponseSummary
            {
                ActiveBills = 5,
                PendingBills = 2,
                InTransitBills = 1,
                PaidBills = 10,
                OverdueBills = 0,
                ApprovedBills = 3,
                DisapprovedBills = 0,
                TotalBills = 21,
                ActiveBillsAmount = 1500,
                PendingBillsAmount = 500,
                InTransitBillsAmount = 200,
                PaidBillsAmount = 3000,
                OverdueBillsAmount = 0,
                ApprovedBillsAmount = 800,
                DisapprovedBillsAmount = 0,
                TotalBillsAmount = 6000,
            },
            PaypointLegalname = "Gruzya Adventure Outfitters LLC",
            PaypointDbaname = "Gruzya Adventure Outfitters",
            PaypointEntryname = "41035afaa7",
            ParentOrgName = "Pilgrim Planner",
            ParentOrgId = 1232,
            CreatedDate = DateTime.Parse(
                "2022-07-01T15:00:01.000Z",
                null,
                DateTimeStyles.AdjustToUniversal
            ),
            LastUpdated = DateTime.Parse(
                "2022-07-01T15:00:01.000Z",
                null,
                DateTimeStyles.AdjustToUniversal
            ),
            RemitAddress1 = "123 Walnut Street",
            RemitAddress2 = "Suite 900",
            RemitCity = "Miami",
            RemitState = "FL",
            RemitZip = "31113",
            RemitCountry = "US",
            PayeeName1 = "Herman Martinez",
            PayeeName2 = "",
            CustomField1 = "",
            CustomField2 = "",
            CustomerVendorAccount = "A-37622",
            InternalReferenceId = 123,
            AdditionalData = new Dictionary<string, string>()
            {
                { "customField", "Custom Value 1" },
                { "reference", "REF-12345" },
                { "notes", "Additional vendor information" },
            },
            ExternalPaypointId = "ext123",
            StoredMethods = new List<VendorResponseStoredMethod>() { },
        };
        var deserializedObject = JsonUtils.Deserialize<VendorDataResponse>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var expectedJson = """
            {
              "VendorNumber": "1234",
              "Name1": "Herman's Coatings and Masonry",
              "Name2": "",
              "EIN": "XXXX6789",
              "Phone": "5555555555",
              "Email": "contact@hermanscoatings.com",
              "RemitEmail": null,
              "Address1": "123 Ocean Drive",
              "Address2": "Suite 400",
              "City": "Miami",
              "State": "FL",
              "Zip": "33139",
              "Country": "US",
              "Mcc": "7777",
              "LocationCode": "MIA123",
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
                "accountId": null,
                "nickname": "Checking Account",
                "bankName": "Country Bank",
                "routingAccount": "123123123",
                "accountNumber": "1XXXXXX3123",
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
              "VendorId": 1234,
              "EnrollmentStatus": null,
              "Summary": {
                "ActiveBills": 5,
                "PendingBills": 2,
                "InTransitBills": 1,
                "PaidBills": 10,
                "OverdueBills": 0,
                "ApprovedBills": 3,
                "DisapprovedBills": 0,
                "TotalBills": 21,
                "ActiveBillsAmount": 1500,
                "PendingBillsAmount": 500,
                "InTransitBillsAmount": 200,
                "PaidBillsAmount": 3000,
                "OverdueBillsAmount": 0,
                "ApprovedBillsAmount": 800,
                "DisapprovedBillsAmount": 0,
                "TotalBillsAmount": 6000
              },
              "PaypointLegalname": "Gruzya Adventure Outfitters LLC",
              "PaypointDbaname": "Gruzya Adventure Outfitters",
              "PaypointEntryname": "41035afaa7",
              "ParentOrgName": "Pilgrim Planner",
              "ParentOrgId": 1232,
              "CreatedDate": "2022-07-01T15:00:01Z",
              "LastUpdated": "2022-07-01T15:00:01Z",
              "remitAddress1": "123 Walnut Street",
              "remitAddress2": "Suite 900",
              "remitCity": "Miami",
              "remitState": "FL",
              "remitZip": "31113",
              "remitCountry": "US",
              "payeeName1": "Herman Martinez",
              "payeeName2": "",
              "customField1": "",
              "customField2": "",
              "customerVendorAccount": "A-37622",
              "InternalReferenceId": 123,
              "additionalData": {
                "customField": "Custom Value 1",
                "reference": "REF-12345",
                "notes": "Additional vendor information"
              },
              "externalPaypointID": "ext123",
              "StoredMethods": []
            }
            """;
        var actualObj = new VendorDataResponse
        {
            VendorNumber = "1234",
            Name1 = "Herman's Coatings and Masonry",
            Name2 = "",
            Ein = "XXXX6789",
            Phone = "5555555555",
            Email = "contact@hermanscoatings.com",
            RemitEmail = null,
            Address1 = "123 Ocean Drive",
            Address2 = "Suite 400",
            City = "Miami",
            State = "FL",
            Zip = "33139",
            Country = "US",
            Mcc = "7777",
            LocationCode = "MIA123",
            Contacts = new List<ContactsResponse>()
            {
                new ContactsResponse
                {
                    ContactName = "Herman Martinez",
                    ContactEmail = "herman@hermanscoatings.com",
                    ContactTitle = "Owner",
                    ContactPhone = "3055550000",
                },
            },
            BillingData = new VendorResponseBillingData
            {
                Id = 123,
                AccountId = null,
                Nickname = "Checking Account",
                BankName = "Country Bank",
                RoutingAccount = "123123123",
                AccountNumber = "1XXXXXX3123",
                TypeAccount = "Checking",
                BankAccountHolderName = "Gruzya Adventure Outfitters LLC",
                BankAccountHolderType = "Business",
                BankAccountFunction = 0,
                Verified = true,
                Status = 1,
                Services = new List<object>() { },
                Default = true,
            },
            PaymentMethod = VendorDataResponsePaymentMethod.Vcard,
            VendorStatus = 1,
            VendorId = 1234,
            EnrollmentStatus = null,
            Summary = new VendorResponseSummary
            {
                ActiveBills = 5,
                PendingBills = 2,
                InTransitBills = 1,
                PaidBills = 10,
                OverdueBills = 0,
                ApprovedBills = 3,
                DisapprovedBills = 0,
                TotalBills = 21,
                ActiveBillsAmount = 1500,
                PendingBillsAmount = 500,
                InTransitBillsAmount = 200,
                PaidBillsAmount = 3000,
                OverdueBillsAmount = 0,
                ApprovedBillsAmount = 800,
                DisapprovedBillsAmount = 0,
                TotalBillsAmount = 6000,
            },
            PaypointLegalname = "Gruzya Adventure Outfitters LLC",
            PaypointDbaname = "Gruzya Adventure Outfitters",
            PaypointEntryname = "41035afaa7",
            ParentOrgName = "Pilgrim Planner",
            ParentOrgId = 1232,
            CreatedDate = DateTime.Parse(
                "2022-07-01T15:00:01.000Z",
                null,
                DateTimeStyles.AdjustToUniversal
            ),
            LastUpdated = DateTime.Parse(
                "2022-07-01T15:00:01.000Z",
                null,
                DateTimeStyles.AdjustToUniversal
            ),
            RemitAddress1 = "123 Walnut Street",
            RemitAddress2 = "Suite 900",
            RemitCity = "Miami",
            RemitState = "FL",
            RemitZip = "31113",
            RemitCountry = "US",
            PayeeName1 = "Herman Martinez",
            PayeeName2 = "",
            CustomField1 = "",
            CustomField2 = "",
            CustomerVendorAccount = "A-37622",
            InternalReferenceId = 123,
            AdditionalData = new Dictionary<string, string>()
            {
                { "customField", "Custom Value 1" },
                { "reference", "REF-12345" },
                { "notes", "Additional vendor information" },
            },
            ExternalPaypointId = "ext123",
            StoredMethods = new List<VendorResponseStoredMethod>() { },
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }
}
