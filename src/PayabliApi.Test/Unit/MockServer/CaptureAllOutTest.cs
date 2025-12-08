using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class CaptureAllOutTest : BaseMockServerTest
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
              "pageIdentifier": "null",
              "responseCode": 1,
              "responseData": [
                {
                  "CustomerId": 1000000,
                  "ReferenceId": "129-230",
                  "ResultCode": 1,
                  "ResultText": "Captured"
                },
                {
                  "CustomerId": 1000000,
                  "ReferenceId": "129-219",
                  "ResultCode": 1,
                  "ResultText": "Captured"
                }
              ],
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyOut/captureAll")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyOut.CaptureAllOutAsync(
            new CaptureAllOutRequest
            {
                Body = new List<string>() { "2-29", "2-28", "2-27" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CaptureAllOutResponse>(mockResponse)).UsingDefaults()
        );
    }
}
