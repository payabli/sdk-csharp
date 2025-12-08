using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ModifyApprovalBillTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            [
              "string"
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
                    .WithHeader("Content-Type", "application/json")
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
            new List<string>() { "string" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<ModifyApprovalBillResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
