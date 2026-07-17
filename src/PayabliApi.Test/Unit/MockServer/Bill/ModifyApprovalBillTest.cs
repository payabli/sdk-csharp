using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Bill;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ModifyApprovalBillTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            [
              "approver1@example.com",
              "approver2@example.com"
            ]
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": 6101,
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Bill/approval/285")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Bill.ModifyApprovalBillAsync(
            285,
            new List<string>() { "approver1@example.com", "approver2@example.com" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
