using System.Text.Json;
using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test;

[TestFixture]
public class TransRequestBodyTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization_1()
    {
        var json = """
            {
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "f743aed24a",
              "ipaddress": "255.255.255.255",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100
              },
              "paymentMethod": {
                "cardcvv": "999",
                "cardexp": "02/27",
                "cardHolder": "John Cassian",
                "cardnumber": "4111111111111111",
                "cardzip": "12345",
                "initiator": "payor",
                "method": "card"
              }
            }
            """;
        var expectedObject = new TransRequestBody
        {
            CustomerData = new PayorDataRequest { CustomerId = 4440 },
            EntryPoint = "f743aed24a",
            Ipaddress = "255.255.255.255",
            PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
            PaymentMethod = new PayMethodCredit
            {
                Cardcvv = "999",
                Cardexp = "02/27",
                CardHolder = "John Cassian",
                Cardnumber = "4111111111111111",
                Cardzip = "12345",
                Initiator = "payor",
                Method = "card",
            },
        };
        var deserializedObject = JsonUtils.Deserialize<TransRequestBody>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_1()
    {
        var expectedJson = """
            {
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "f743aed24a",
              "ipaddress": "255.255.255.255",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100
              },
              "paymentMethod": {
                "cardcvv": "999",
                "cardexp": "02/27",
                "cardHolder": "John Cassian",
                "cardnumber": "4111111111111111",
                "cardzip": "12345",
                "initiator": "payor",
                "method": "card"
              }
            }
            """;
        var actualObj = new TransRequestBody
        {
            CustomerData = new PayorDataRequest { CustomerId = 4440 },
            EntryPoint = "f743aed24a",
            Ipaddress = "255.255.255.255",
            PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
            PaymentMethod = new PayMethodCredit
            {
                Cardcvv = "999",
                Cardexp = "02/27",
                CardHolder = "John Cassian",
                Cardnumber = "4111111111111111",
                Cardzip = "12345",
                Initiator = "payor",
                Method = "card",
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
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "f743aed24a",
              "ipaddress": "255.255.255.255",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100,
                "currency": "CAD"
              },
              "paymentMethod": {
                "cardcvv": "999",
                "cardexp": "02/27",
                "cardHolder": "John Cassian",
                "cardnumber": "4111111111111111",
                "cardzip": "12345",
                "initiator": "payor",
                "method": "card"
              }
            }
            """;
        var expectedObject = new TransRequestBody
        {
            CustomerData = new PayorDataRequest { CustomerId = 4440 },
            EntryPoint = "f743aed24a",
            Ipaddress = "255.255.255.255",
            PaymentDetails = new PaymentDetail
            {
                ServiceFee = 0,
                TotalAmount = 100,
                Currency = "CAD",
            },
            PaymentMethod = new PayMethodCredit
            {
                Cardcvv = "999",
                Cardexp = "02/27",
                CardHolder = "John Cassian",
                Cardnumber = "4111111111111111",
                Cardzip = "12345",
                Initiator = "payor",
                Method = "card",
            },
        };
        var deserializedObject = JsonUtils.Deserialize<TransRequestBody>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_2()
    {
        var expectedJson = """
            {
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "f743aed24a",
              "ipaddress": "255.255.255.255",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100,
                "currency": "CAD"
              },
              "paymentMethod": {
                "cardcvv": "999",
                "cardexp": "02/27",
                "cardHolder": "John Cassian",
                "cardnumber": "4111111111111111",
                "cardzip": "12345",
                "initiator": "payor",
                "method": "card"
              }
            }
            """;
        var actualObj = new TransRequestBody
        {
            CustomerData = new PayorDataRequest { CustomerId = 4440 },
            EntryPoint = "f743aed24a",
            Ipaddress = "255.255.255.255",
            PaymentDetails = new PaymentDetail
            {
                ServiceFee = 0,
                TotalAmount = 100,
                Currency = "CAD",
            },
            PaymentMethod = new PayMethodCredit
            {
                Cardcvv = "999",
                Cardexp = "02/27",
                CardHolder = "John Cassian",
                Cardnumber = "4111111111111111",
                Cardzip = "12345",
                Initiator = "payor",
                Method = "card",
            },
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_3()
    {
        var json = """
            {
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "f743aed24a",
              "ipaddress": "255.255.255.255",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100
              },
              "paymentMethod": {
                "initiator": "payor",
                "method": "card",
                "storedMethodId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "storedMethodUsageType": "unscheduled"
              }
            }
            """;
        var expectedObject = new TransRequestBody
        {
            CustomerData = new PayorDataRequest { CustomerId = 4440 },
            EntryPoint = "f743aed24a",
            Ipaddress = "255.255.255.255",
            PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
            PaymentMethod = new PayMethodStoredMethod
            {
                Initiator = "payor",
                Method = PayMethodStoredMethodMethod.Card,
                StoredMethodId = "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                StoredMethodUsageType = "unscheduled",
            },
        };
        var deserializedObject = JsonUtils.Deserialize<TransRequestBody>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_3()
    {
        var expectedJson = """
            {
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "f743aed24a",
              "ipaddress": "255.255.255.255",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100
              },
              "paymentMethod": {
                "initiator": "payor",
                "method": "card",
                "storedMethodId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "storedMethodUsageType": "unscheduled"
              }
            }
            """;
        var actualObj = new TransRequestBody
        {
            CustomerData = new PayorDataRequest { CustomerId = 4440 },
            EntryPoint = "f743aed24a",
            Ipaddress = "255.255.255.255",
            PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
            PaymentMethod = new PayMethodStoredMethod
            {
                Initiator = "payor",
                Method = PayMethodStoredMethodMethod.Card,
                StoredMethodId = "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                StoredMethodUsageType = "unscheduled",
            },
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }
}
