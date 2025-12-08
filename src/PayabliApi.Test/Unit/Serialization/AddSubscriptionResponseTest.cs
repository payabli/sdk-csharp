using System.Text.Json;
using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test;

[TestFixture]
public class AddSubscriptionResponseTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "responseData": 396,
              "customerId": 4440
            }
            """;
        var expectedObject = new AddSubscriptionResponse
        {
            ResponseText = "Success",
            IsSuccess = true,
            ResponseData = 396,
            CustomerId = 4440,
        };
        var deserializedObject = JsonUtils.Deserialize<AddSubscriptionResponse>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var expectedJson = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "responseData": 396,
              "customerId": 4440
            }
            """;
        var actualObj = new AddSubscriptionResponse
        {
            ResponseText = "Success",
            IsSuccess = true,
            ResponseData = 396,
            CustomerId = 4440,
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }
}
