using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ExportTransfersTest : BaseMockServerTest
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
                    .WithPath("/Export/transfers/8cfec329267")
                    .WithParam("columnsExport", "BatchDate:Batch_Date,PaypointName:Legal_name")
                    .WithParam("fromRecord", "251")
                    .WithParam("limitRecord", "1000")
                    .WithParam("sortBy", "desc(field_name)")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Export.ExportTransfersAsync(
            "8cfec329267",
            new ExportTransfersRequest
            {
                ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
                FromRecord = 251,
                LimitRecord = 1000,
                SortBy = "desc(field_name)",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<Dictionary<string, object?>>(mockResponse))
                .UsingDefaults()
        );
    }
}
