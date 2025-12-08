using System.Text.Json;
using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test;

[TestFixture]
public class VendorSummaryTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
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
            }
            """;
        var expectedObject = new VendorSummary
        {
            ActiveBills = 2,
            PendingBills = 4,
            InTransitBills = 3,
            PaidBills = 18,
            OverdueBills = 1,
            ApprovedBills = 5,
            DisapprovedBills = 1,
            TotalBills = 34,
            ActiveBillsAmount = 1250.75,
            PendingBillsAmount = 2890.5,
            InTransitBillsAmount = 1675.25,
            PaidBillsAmount = 15420.8,
            OverdueBillsAmount = 425,
            ApprovedBillsAmount = 3240.9,
            DisapprovedBillsAmount = 180,
            TotalBillsAmount = 25083.2,
        };
        var deserializedObject = JsonUtils.Deserialize<VendorSummary>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var expectedJson = """
            {
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
            }
            """;
        var actualObj = new VendorSummary
        {
            ActiveBills = 2,
            PendingBills = 4,
            InTransitBills = 3,
            PaidBills = 18,
            OverdueBills = 1,
            ApprovedBills = 5,
            DisapprovedBills = 1,
            TotalBills = 34,
            ActiveBillsAmount = 1250.75,
            PendingBillsAmount = 2890.5,
            InTransitBillsAmount = 1675.25,
            PaidBillsAmount = 15420.8,
            OverdueBillsAmount = 425,
            ApprovedBillsAmount = 3240.9,
            DisapprovedBillsAmount = 180,
            TotalBillsAmount = 25083.2,
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }
}
