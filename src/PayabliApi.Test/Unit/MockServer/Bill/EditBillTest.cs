using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Bill;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
        JsonAssert.AreEqual(response, mockResponse);
    }
}
