using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Export;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
                    .WithParam("columnsExport", "BatchDate:Batch_Date", "PaypointName:Legal_name")
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
        JsonAssert.AreEqual(response, mockResponse);
    }
}
