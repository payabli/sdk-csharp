using System.Text.Json;
using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test;

[TestFixture]
public class BatchSummaryTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "pageidentifier": null,
              "pageSize": 20,
              "totalAmount": 0,
              "totalNetAmount": 0,
              "totalPages": 411,
              "totalRecords": 8203
            }
            """;
        var expectedObject = new BatchSummary
        {
            Pageidentifier = null,
            PageSize = 20,
            TotalAmount = 0,
            TotalNetAmount = 0,
            TotalPages = 411,
            TotalRecords = 8203,
        };
        var deserializedObject = JsonUtils.Deserialize<BatchSummary>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var expectedJson = """
            {
              "pageidentifier": null,
              "pageSize": 20,
              "totalAmount": 0,
              "totalNetAmount": 0,
              "totalPages": 411,
              "totalRecords": 8203
            }
            """;
        var actualObj = new BatchSummary
        {
            Pageidentifier = null,
            PageSize = 20,
            TotalAmount = 0,
            TotalNetAmount = 0,
            TotalPages = 411,
            TotalRecords = 8203,
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }
}
