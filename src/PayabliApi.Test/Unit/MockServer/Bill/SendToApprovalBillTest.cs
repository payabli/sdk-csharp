using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Bill;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SendToApprovalBillTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            [
              "approver@example.com"
            ]
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": 6101
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Bill/approval/285")
                    .WithHeader("idempotencyKey", "6B29FC40-CA47-1067-B31D-00DD010662DA")
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

        var response = await Client.Bill.SendToApprovalBillAsync(
            285,
            new SendToApprovalBillRequest
            {
                IdempotencyKey = "6B29FC40-CA47-1067-B31D-00DD010662DA",
                Body = new List<string>() { "approver@example.com" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
