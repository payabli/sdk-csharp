using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Businesses;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateBusinessAddressTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "type": "mailing",
              "location": "warehouse",
              "addressLine1": "202 Warehouse Ln",
              "cityLocality": "Austin",
              "stateProvince": "TX",
              "postalCode": "73302",
              "country": "US"
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Address added successfully",
              "traceId": "0HNOF89NNTM7O:00000092",
              "data": {
                "_links": {
                  "self": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55/addresses/019fed1a-67d6-768a-b4cc-29d4299e21d9",
                  "business": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                },
                "businessAddressReference": "019fed1a-67d6-768a-b4cc-29d4299e21d9",
                "type": "mailing",
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
                    .WithPath("/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55/addresses")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
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

        var response = await Client.Businesses.CreateBusinessAddressAsync(
            "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
            new CreateBusinessAddressRequest
            {
                Type = AddressType.Mailing,
                Location = BusinessAddressLocation.Warehouse,
                AddressLine1 = "202 Warehouse Ln",
                CityLocality = "Austin",
                StateProvince = "TX",
                PostalCode = "73302",
                Country = "US",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
