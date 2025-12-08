using System.Text.Json;
using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test;

[TestFixture]
public class BillingDataResponseTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
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
            }
            """;
        var expectedObject = new BillingDataResponse
        {
            Id = 123456,
            AccountId = "bank-account-001",
            Nickname = "Main Checking Account",
            BankName = "Example Bank",
            RoutingAccount = "123456789",
            AccountNumber = "9876543210",
            TypeAccount = TypeAccount.Checking,
            BankAccountHolderName = "John Doe",
            BankAccountHolderType = BankAccountHolderType.Business,
            BankAccountFunction = 2,
            Verified = true,
            Status = 1,
            Services = new List<object>() { },
            Default = true,
        };
        var deserializedObject = JsonUtils.Deserialize<BillingDataResponse>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var expectedJson = """
            {
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
            }
            """;
        var actualObj = new BillingDataResponse
        {
            Id = 123456,
            AccountId = "bank-account-001",
            Nickname = "Main Checking Account",
            BankName = "Example Bank",
            RoutingAccount = "123456789",
            AccountNumber = "9876543210",
            TypeAccount = TypeAccount.Checking,
            BankAccountHolderName = "John Doe",
            BankAccountHolderType = BankAccountHolderType.Business,
            BankAccountFunction = 2,
            Verified = true,
            Status = 1,
            Services = new List<object>() { },
            Default = true,
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }
}
