using System.Globalization;
using System.Text.Json;
using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test;

[TestFixture]
public class VCardRecordTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "vcardSent": true,
              "cardToken": "vcrd_5Ty8NrBzXjKuqHm9DwElfP",
              "cardNumber": "44XX XXXX XXXX 1234",
              "cvc": "XXX",
              "expirationDate": "2025-12",
              "status": "Active",
              "amount": 500,
              "currentBalance": 375.25,
              "expenseLimit": 100,
              "expenseLimitPeriod": "monthly",
              "maxNumberOfUses": 10,
              "currentNumberOfUses": 3,
              "exactAmount": false,
              "mcc": "5812",
              "tcc": "T01",
              "misc1": "Invoice #12345",
              "misc2": "Project: Office Supplies",
              "dateCreated": "2023-01-15T09:30:00Z",
              "dateModified": "2023-02-20T14:15:22Z",
              "associatedVendor": {
                "VendorNumber": "V-12345",
                "Name1": "Office Supply Co.",
                "EIN": "XXXXX6789",
                "Email": "billing@officesupply.example.com",
                "VendorId": 1542
              },
              "associatedCustomer": {
                "firstname": "Acme",
                "lastname": "Corporation"
              },
              "PaypointDbaname": "Global Factory LLC",
              "PaypointLegalname": "Global Factory LLC",
              "PaypointEntryname": "4872acb376a",
              "externalPaypointID": "pay-10",
              "ParentOrgName": "SupplyPro",
              "paypointId": 236
            }
            """;
        var expectedObject = new VCardRecord
        {
            VcardSent = true,
            CardToken = "vcrd_5Ty8NrBzXjKuqHm9DwElfP",
            CardNumber = "44XX XXXX XXXX 1234",
            Cvc = "XXX",
            ExpirationDate = "2025-12",
            Status = "Active",
            Amount = 500,
            CurrentBalance = 375.25,
            ExpenseLimit = 100,
            ExpenseLimitPeriod = "monthly",
            MaxNumberOfUses = 10,
            CurrentNumberOfUses = 3,
            ExactAmount = false,
            Mcc = "5812",
            Tcc = "T01",
            Misc1 = "Invoice #12345",
            Misc2 = "Project: Office Supplies",
            DateCreated = DateTime.Parse(
                "2023-01-15T09:30:00.000Z",
                null,
                DateTimeStyles.AdjustToUniversal
            ),
            DateModified = DateTime.Parse(
                "2023-02-20T14:15:22.000Z",
                null,
                DateTimeStyles.AdjustToUniversal
            ),
            AssociatedVendor = new AssociatedVendor
            {
                VendorNumber = "V-12345",
                Name1 = "Office Supply Co.",
                Ein = "XXXXX6789",
                Email = "billing@officesupply.example.com",
                VendorId = 1542,
            },
            AssociatedCustomer = new CustomerData { Firstname = "Acme", Lastname = "Corporation" },
            PaypointDbaname = "Global Factory LLC",
            PaypointLegalname = "Global Factory LLC",
            PaypointEntryname = "4872acb376a",
            ExternalPaypointId = "pay-10",
            ParentOrgName = "SupplyPro",
            PaypointId = 236,
        };
        var deserializedObject = JsonUtils.Deserialize<VCardRecord>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var expectedJson = """
            {
              "vcardSent": true,
              "cardToken": "vcrd_5Ty8NrBzXjKuqHm9DwElfP",
              "cardNumber": "44XX XXXX XXXX 1234",
              "cvc": "XXX",
              "expirationDate": "2025-12",
              "status": "Active",
              "amount": 500,
              "currentBalance": 375.25,
              "expenseLimit": 100,
              "expenseLimitPeriod": "monthly",
              "maxNumberOfUses": 10,
              "currentNumberOfUses": 3,
              "exactAmount": false,
              "mcc": "5812",
              "tcc": "T01",
              "misc1": "Invoice #12345",
              "misc2": "Project: Office Supplies",
              "dateCreated": "2023-01-15T09:30:00Z",
              "dateModified": "2023-02-20T14:15:22Z",
              "associatedVendor": {
                "VendorNumber": "V-12345",
                "Name1": "Office Supply Co.",
                "EIN": "XXXXX6789",
                "Email": "billing@officesupply.example.com",
                "VendorId": 1542
              },
              "associatedCustomer": {
                "firstname": "Acme",
                "lastname": "Corporation"
              },
              "PaypointDbaname": "Global Factory LLC",
              "PaypointLegalname": "Global Factory LLC",
              "PaypointEntryname": "4872acb376a",
              "externalPaypointID": "pay-10",
              "ParentOrgName": "SupplyPro",
              "paypointId": 236
            }
            """;
        var actualObj = new VCardRecord
        {
            VcardSent = true,
            CardToken = "vcrd_5Ty8NrBzXjKuqHm9DwElfP",
            CardNumber = "44XX XXXX XXXX 1234",
            Cvc = "XXX",
            ExpirationDate = "2025-12",
            Status = "Active",
            Amount = 500,
            CurrentBalance = 375.25,
            ExpenseLimit = 100,
            ExpenseLimitPeriod = "monthly",
            MaxNumberOfUses = 10,
            CurrentNumberOfUses = 3,
            ExactAmount = false,
            Mcc = "5812",
            Tcc = "T01",
            Misc1 = "Invoice #12345",
            Misc2 = "Project: Office Supplies",
            DateCreated = DateTime.Parse(
                "2023-01-15T09:30:00.000Z",
                null,
                DateTimeStyles.AdjustToUniversal
            ),
            DateModified = DateTime.Parse(
                "2023-02-20T14:15:22.000Z",
                null,
                DateTimeStyles.AdjustToUniversal
            ),
            AssociatedVendor = new AssociatedVendor
            {
                VendorNumber = "V-12345",
                Name1 = "Office Supply Co.",
                Ein = "XXXXX6789",
                Email = "billing@officesupply.example.com",
                VendorId = 1542,
            },
            AssociatedCustomer = new CustomerData { Firstname = "Acme", Lastname = "Corporation" },
            PaypointDbaname = "Global Factory LLC",
            PaypointLegalname = "Global Factory LLC",
            PaypointEntryname = "4872acb376a",
            ExternalPaypointId = "pay-10",
            ParentOrgName = "SupplyPro",
            PaypointId = 236,
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }
}
