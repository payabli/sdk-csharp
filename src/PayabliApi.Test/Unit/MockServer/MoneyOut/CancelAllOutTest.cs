using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyOut;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CancelAllOutTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            [
              "2-29",
              "2-28",
              "2-27"
            ]
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseData": [
                {
                  "CustomerId": 456,
                  "VendorId": 456,
                  "ReferenceId": "129-230",
                  "ResultCode": 1,
                  "ResultText": "Cancelled"
                },
                {
                  "CustomerId": 456,
                  "VendorId": 456,
                  "ReferenceId": "129-219",
                  "ResultCode": 1,
                  "ResultText": "Cancelled"
                }
              ],
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyOut/cancelAll")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyOut.CancelAllOutAsync(
            new List<string>() { "2-29", "2-28", "2-27" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
