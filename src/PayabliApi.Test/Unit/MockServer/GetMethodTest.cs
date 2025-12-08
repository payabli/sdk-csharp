using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class GetMethodTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": {
                "aba": "",
                "achHolderType": "personal",
                "achSecCode": "achSecCode",
                "bin": "401288",
                "binData": {
                  "binMatchedLength": "6",
                  "binCardBrand": "Visa",
                  "binCardType": "Credit",
                  "binCardCategory": "PLATINUM",
                  "binCardIssuer": "Bank of Example",
                  "binCardIssuerCountry": "United States",
                  "binCardIssuerCountryCodeA2": "US",
                  "binCardIssuerCountryNumber": "840",
                  "binCardIsRegulated": "false",
                  "binCardUseCategory": "Consumer",
                  "binCardIssuerCountryCodeA3": "USA"
                },
                "customers": [
                  {
                    "additionalData": {
                      "key1": {
                        "key": "value"
                      },
                      "key2": {
                        "key": "value"
                      },
                      "key3": {
                        "key": "value"
                      }
                    },
                    "balance": 250,
                    "billingPhone": "1234567890",
                    "company": "Bluesky Tech Inc",
                    "created": "2023-06-01T14:30:00.000Z",
                    "customerId": 1456,
                    "customerNumber": "CS789",
                    "customerStatus": 1,
                    "customerUsername": "Marcus",
                    "identifierFields": [
                      "firstname",
                      "email"
                    ],
                    "lastUpdated": "2024-12-15T09:45:32.000Z",
                    "mfa": true,
                    "mfaMode": 1,
                    "parentOrgId": 5,
                    "parentOrgName": "TechCorp",
                    "paypointDbaname": "Bluesky Tech",
                    "paypointEntryname": "45782932fcc",
                    "paypointLegalname": "Bluesky Technologies LLC",
                    "shippingAddress1": "Suite 500",
                    "shippingCity": "San Francisco",
                    "shippingCountry": "US",
                    "shippingState": "CA",
                    "shippingZip": "94105",
                    "timeZone": -8
                  }
                ],
                "descriptor": "visa",
                "expDate": "0926",
                "holderName": "Marcus Chen",
                "idPmethod": "81f7fde1-dd8b-4892-b2e1-cd60dd91f6b4-XXXC",
                "lastUpdated": "2025-01-15T16:30:22.000Z",
                "maskedAccount": "4XXXXXXX2345",
                "method": "card",
                "methodType": "Single Merchant",
                "postalCode": "94105"
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/TokenStorage/32-8877drt00045632-678")
                    .WithParam("cardExpirationFormat", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.TokenStorage.GetMethodAsync(
            "32-8877drt00045632-678",
            new GetMethodRequest { CardExpirationFormat = 1, IncludeTemporary = false }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetMethodResponse>(mockResponse)).UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": {
                "aba": "021000021",
                "achHolderType": "personal",
                "achSecCode": "PPD",
                "bin": "",
                "customers": [
                  {
                    "additionalData": {
                      "key1": {
                        "key": "value"
                      },
                      "key2": {
                        "key": "value"
                      },
                      "key3": {
                        "key": "value"
                      }
                    },
                    "balance": 250,
                    "billingPhone": "1234567890",
                    "company": "Bluesky Tech Inc",
                    "created": "2023-06-01T14:30:00.000Z",
                    "customerId": 1456,
                    "customerNumber": "CS789",
                    "customerStatus": 1,
                    "customerUsername": "Marcus",
                    "identifierFields": [
                      "firstname",
                      "email"
                    ],
                    "lastUpdated": "2024-12-15T09:45:32.000Z",
                    "mfa": true,
                    "mfaMode": 1,
                    "parentOrgId": 5,
                    "parentOrgName": "TechCorp",
                    "paypointDbaname": "Bluesky Tech",
                    "paypointEntryname": "45782932fcc",
                    "paypointLegalname": "Bluesky Technologies LLC",
                    "shippingAddress1": "Suite 500",
                    "shippingCity": "San Francisco",
                    "shippingCountry": "US",
                    "shippingState": "CA",
                    "shippingZip": "94105",
                    "snIdentifier": "null",
                    "snProvider": "google",
                    "timeZone": -8
                  }
                ],
                "descriptor": "Checking",
                "expDate": "",
                "holderName": "Marcus Chen",
                "idPmethod": "81f7fde1-dd8b-4892-b2e1-cd60dd91f6b4-XXXX",
                "lastUpdated": "2025-01-15T16:30:22.000Z",
                "maskedAccount": "8XXXXXX8654",
                "method": "ach",
                "methodType": "Single Merchant",
                "postalCode": ""
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/TokenStorage/32-8877drt00045632-678")
                    .WithParam("cardExpirationFormat", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.TokenStorage.GetMethodAsync(
            "32-8877drt00045632-678",
            new GetMethodRequest { CardExpirationFormat = 1, IncludeTemporary = false }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetMethodResponse>(mockResponse)).UsingDefaults()
        );
    }
}
