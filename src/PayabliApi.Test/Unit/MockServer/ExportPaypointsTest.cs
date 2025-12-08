using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ExportPaypointsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "key": "value"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Export/paypoints/csv/123")
                    .WithParam("columnsExport", "BatchDate:Batch_Date,PaypointName:Legal_name")
                    .WithParam("fromRecord", "251")
                    .WithParam("limitRecord", "1000")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Export.ExportPaypointsAsync(
            ExportFormat1.Csv,
            123,
            new ExportPaypointsRequest
            {
                ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
                FromRecord = 251,
                LimitRecord = 1000,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<Dictionary<string, object?>>(mockResponse))
                .UsingDefaults()
        );
    }
}
