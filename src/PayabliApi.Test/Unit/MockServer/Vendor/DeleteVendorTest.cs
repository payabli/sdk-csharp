using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Vendor;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteVendorTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseData": 3890,
              "responseText": "Success"
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/Vendor/1").UsingDelete())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Vendor.DeleteVendorAsync(1);
        JsonAssert.AreEqual(response, mockResponse);
    }
}
