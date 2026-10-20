using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Businesses;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetBusinessTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Business retrieved successfully",
              "traceId": "0HNNKQIN7BJO3:00000008",
              "data": {
                "_links": {
                  "self": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                },
                "businessUuid": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "taxReference": "****8993",
                "businessStatus": "Draft",
                "parentReference": "8cfec329267",
                "externalId": "rg-001",
                "legalName": "Rose Gardens LLC",
                "legalStructure": "LimitedLiabilityCompany",
                "incorporationState": "GA",
                "taxIdCountry": "US",
                "website": "https://example.com",
                "merchantCatCode": "5814",
                "phone": [
                  "3055551212"
                ],
                "emails": [
                  "ops@example.com"
                ],
                "addressDetails": [],
                "paymentMethods": [
                  {
                    "type": "bank_account",
                    "name": "Operating account",
                    "financialInstitution": "Bank of Example",
                    "ownerType": "business",
                    "accountType": "checking",
                    "accountNumber": "****6789",
                    "routingNumber": "****0021",
                    "usage": [
                      "deposits",
                      "billing"
                    ],
                    "isDefault": true
                  },
                  {
                    "type": "bank_account",
                    "name": "Payout account",
                    "financialInstitution": "Bank of Example",
                    "ownerType": "business",
                    "accountType": "checking",
                    "accountNumber": "****4321",
                    "routingNumber": "****0021",
                    "usage": [
                      "payOutFunding"
                    ],
                    "isDefault": false
                  }
                ],
                "certificationDetails": [],
                "isTaxExempt": false,
                "license": "LIC-48213",
                "licenseState": "GA",
                "createdAt": "2026-08-10T19:15:47.694Z",
                "lastUpdated": "2026-08-10T19:15:47.694Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55")
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

        var response = await Client.Businesses.GetBusinessAsync(
            "019fed1a-3d6e-75d3-a81e-cba3874b0a55"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
