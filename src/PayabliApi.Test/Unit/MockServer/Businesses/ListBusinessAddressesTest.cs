using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Businesses;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListBusinessAddressesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Addresses retrieved successfully",
              "traceId": "0HNOF89NNTM7O:00000026",
              "data": [
                {
                  "_links": {
                    "self": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55/addresses/019fed1a-849f-729f-be21-d6395f155ccd",
                    "business": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                  },
                  "businessAddressReference": "019fed1a-849f-729f-be21-d6395f155ccd",
                  "type": "legal",
                  "location": "office",
                  "addressLine1": "200 Sesame Blvd",
                  "addressLine2": "Suite 150",
                  "cityLocality": "New York",
                  "stateProvince": "NY",
                  "postalCode": "10001",
                  "country": "US"
                },
                {
                  "_links": {
                    "self": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55/addresses/019fed1a-84a6-7043-a6c0-e8aa2d4bec36",
                    "business": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                  },
                  "businessAddressReference": "019fed1a-84a6-7043-a6c0-e8aa2d4bec36",
                  "type": "shipping",
                  "location": "warehouse",
                  "addressLine1": "201 Warehouse Ln",
                  "cityLocality": "Austin",
                  "stateProvince": "TX",
                  "postalCode": "73302",
                  "country": "US"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55/addresses")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Businesses.ListBusinessAddressesAsync(
            "019fed1a-3d6e-75d3-a81e-cba3874b0a55"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
