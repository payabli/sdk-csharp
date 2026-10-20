using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Businesses;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateBusinessTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "legalName": "Rose Gardens LLC",
              "legalStructure": "llc",
              "externalId": "rg-001",
              "website": "https://example.com",
              "phone": [
                "3055551212"
              ],
              "emails": [
                "ops@example.com"
              ],
              "merchantCatCode": "5814",
              "paymentMethods": [
                {
                  "type": "bank_account",
                  "name": "Operating account",
                  "financialInstitution": "Bank of Example",
                  "ownerType": "business",
                  "accountType": "checking",
                  "accountNumber": "123456789",
                  "routingNumber": "021000021",
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
                  "accountNumber": "987654321",
                  "routingNumber": "021000021",
                  "usage": [
                    "payOutFunding"
                  ],
                  "isDefault": false
                }
              ],
              "taxReference": "477498993",
              "parentReference": "8cfec329267"
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Business created successfully",
              "traceId": "0HNNKQIN7BJO1:00000015",
              "data": {
                "_links": {
                  "self": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                },
                "businessUuid": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "businessStatus": "Draft",
                "createdAt": "2026-08-10T19:15:47.694Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/businesses")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Businesses.CreateBusinessAsync(
            new CreateBusinessRequest
            {
                LegalName = "Rose Gardens LLC",
                LegalStructure = CreateBusinessRequestLegalStructure.Llc,
                ExternalId = "rg-001",
                Website = "https://example.com",
                Phone = new List<string>() { "3055551212" },
                Emails = new List<string>() { "ops@example.com" },
                MerchantCatCode = "5814",
                PaymentMethods = new List<BusinessPaymentMethod>()
                {
                    new BusinessPaymentMethod
                    {
                        Type = "bank_account",
                        Name = "Operating account",
                        FinancialInstitution = "Bank of Example",
                        OwnerType = "business",
                        AccountType = "checking",
                        AccountNumber = "123456789",
                        RoutingNumber = "021000021",
                        Usage = new List<string>() { "deposits", "billing" },
                        IsDefault = true,
                    },
                    new BusinessPaymentMethod
                    {
                        Type = "bank_account",
                        Name = "Payout account",
                        FinancialInstitution = "Bank of Example",
                        OwnerType = "business",
                        AccountType = "checking",
                        AccountNumber = "987654321",
                        RoutingNumber = "021000021",
                        Usage = new List<string>() { "payOutFunding" },
                        IsDefault = false,
                    },
                },
                TaxReference = "477498993",
                ParentReference = "8cfec329267",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
