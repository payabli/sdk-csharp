using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class EditBillTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "netAmount": 3762.87,
              "billDate": "2025-07-01"
            }
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "pageIdentifier": null,
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
                    .WithPath("/Bill/285")
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

        var response = await Client.Bill.EditBillAsync(
            285,
            new BillOutData { NetAmount = 3762.87, BillDate = new DateOnly(2025, 7, 1) }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<EditBillResponse>(mockResponse)).UsingDefaults()
        );
    }
}
