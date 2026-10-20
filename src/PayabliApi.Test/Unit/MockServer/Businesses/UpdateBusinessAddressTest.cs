using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Businesses;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateBusinessAddressTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "type": "billing"
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Address updated successfully",
              "traceId": "0HNOF89NNTM7O:000000C9",
              "data": {
                "_links": {
                  "self": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55/addresses/019fed1a-67d6-768a-b4cc-29d4299e21d9",
                  "business": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                },
                "businessAddressReference": "019fed1a-67d6-768a-b4cc-29d4299e21d9",
                "type": "billing",
                "location": "warehouse",
                "addressLine1": "202 Warehouse Ln",
                "cityLocality": "Austin",
                "stateProvince": "TX",
                "postalCode": "73302",
                "country": "US"
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
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Businesses.UpdateBusinessAddressAsync(
            "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
            "019fed1a-67d6-768a-b4cc-29d4299e21d9",
            new UpdateBusinessAddressRequest { Type = AddressType.Billing }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
