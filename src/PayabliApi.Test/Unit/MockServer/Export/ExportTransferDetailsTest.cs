using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Export;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ExportTransferDetailsTest : BaseMockServerTest
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
                    .WithPath("/Export/transferDetails/csv/8cfec329267/4521")
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

        var response = await Client.Export.ExportTransferDetailsAsync(
            ExportFormat1.Csv,
            "8cfec329267",
            4521,
            new ExportTransferDetailsRequest
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
