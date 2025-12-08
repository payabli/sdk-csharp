using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class UpdateCustomerTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "firstname": "Irene",
              "lastname": "Canizales",
              "address1": "145 Bishop's Trail",
              "city": "Mountain City",
              "state": "TN",
              "zip": "37612",
              "country": "US"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseData": " ",
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Customer/998")
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

        var response = await Client.Customer.UpdateCustomerAsync(
            998,
            new CustomerData
            {
                Firstname = "Irene",
                Lastname = "Canizales",
                Address1 = "145 Bishop's Trail",
                City = "Mountain City",
                State = "TN",
                Zip = "37612",
                Country = "US",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<PayabliApiResponse00Responsedatanonobject>(mockResponse)
                )
                .UsingDefaults()
        );
    }
}
