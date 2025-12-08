using System.Text.Json;
using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test;

[TestFixture]
public class TransferSummaryTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "totalPages": 1,
              "totalRecords": 2,
              "pageSize": 20
            }
            """;
        var expectedObject = new TransferSummary
        {
            TotalPages = 1,
            TotalRecords = 2,
            PageSize = 20,
        };
        var deserializedObject = JsonUtils.Deserialize<TransferSummary>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var expectedJson = """
            {
              "totalPages": 1,
              "totalRecords": 2,
              "pageSize": 20
            }
            """;
        var actualObj = new TransferSummary
        {
            TotalPages = 1,
            TotalRecords = 2,
            PageSize = 20,
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }
}
