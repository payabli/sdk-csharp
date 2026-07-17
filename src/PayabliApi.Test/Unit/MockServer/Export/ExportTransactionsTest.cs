using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Export;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ExportTransactionsTest : BaseMockServerTest
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
                    .WithPath("/Export/transactions/csv/8cfec329267")
                    .WithParam("columnsExport", "BatchDate:Batch_Date", "PaypointName:Legal_name")
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

        var response = await Client.Export.ExportTransactionsAsync(
            ExportFormat1.Csv,
            "8cfec329267",
            new ExportTransactionsRequest
            {
                ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
                FromRecord = 251,
                LimitRecord = 1000,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
