using System.Text.Json;
using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test;

[TestFixture]
public class ContactsResponseTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "ContactEmail": "eric@martinezcoatings.com",
              "ContactName": "Eric Martinez",
              "ContactPhone": "5555555555",
              "ContactTitle": "Owner"
            }
            """;
        var expectedObject = new ContactsResponse
        {
            ContactEmail = "eric@martinezcoatings.com",
            ContactName = "Eric Martinez",
            ContactPhone = "5555555555",
            ContactTitle = "Owner",
        };
        var deserializedObject = JsonUtils.Deserialize<ContactsResponse>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var expectedJson = """
            {
              "ContactEmail": "eric@martinezcoatings.com",
              "ContactName": "Eric Martinez",
              "ContactPhone": "5555555555",
              "ContactTitle": "Owner"
            }
            """;
        var actualObj = new ContactsResponse
        {
            ContactEmail = "eric@martinezcoatings.com",
            ContactName = "Eric Martinez",
            ContactPhone = "5555555555",
            ContactTitle = "Owner",
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }
}
