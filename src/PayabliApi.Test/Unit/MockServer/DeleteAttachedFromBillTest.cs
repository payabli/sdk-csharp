using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class DeleteAttachedFromBillTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
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
                    .WithPath("/Bill/attachedFileFromBill/285/0_Bill.pdf")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Bill.DeleteAttachedFromBillAsync(
            "0_Bill.pdf",
            285,
            new DeleteAttachedFromBillRequest()
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BillResponse>(mockResponse)).UsingDefaults()
        );
    }
}
