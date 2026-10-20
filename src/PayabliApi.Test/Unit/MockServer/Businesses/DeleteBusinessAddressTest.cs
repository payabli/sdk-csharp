using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Businesses;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteBusinessAddressTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Address removed successfully",
              "traceId": "0HNOF89NNTM7N:000000DF",
              "data": {
                "_links": {
                  "self": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                },
                "businessUuid": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "businessAddressReference": "019fed1a-67d6-768a-b4cc-29d4299e21d9",
                "deletedAt": "2026-09-10T16:15:44.354Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55/addresses/019fed1a-67d6-768a-b4cc-29d4299e21d9"
                    )
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Businesses.DeleteBusinessAddressAsync(
            "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
            "019fed1a-67d6-768a-b4cc-29d4299e21d9"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
