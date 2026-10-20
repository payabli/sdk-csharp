using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.People;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetPersonUnmaskedTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Person retrieved successfully",
              "traceId": "0HNNQ4R2OT26Q:0000001E",
              "data": {
                "personReference": "01a0014d-ce1a-7110-9bac-c4c59647a88d",
                "externalId": "person-001",
                "firstName": "Marcus",
                "middleName": "James",
                "lastName": "Delgado",
                "primaryEmail": "marcus.delgado@example.com",
                "secondaryEmail": "m.delgado@example.net",
                "primaryPhoneNumber": "3055551212",
                "secondaryPhoneNumber": "3055559876",
                "dateOfBirth": "1985-03-14",
                "ssn": "412-55-9021",
                "nationality": "US",
                "driversLicenseNumber": "D1234567",
                "driversLicenseState": "FL",
                "customData": {
                  "department": "finance"
                },
                "verificationStatus": "not_started",
                "addresses": [
                  {
                    "addressLine1": "123 Main Street",
                    "addressLine2": "Suite 400",
                    "cityLocality": "Miami",
                    "stateProvince": "FL",
                    "postalCode": "33101",
                    "country": "US",
                    "type": "legal"
                  }
                ],
                "identificationDocuments": [
                  {
                    "type": "passport",
                    "number": "X1234567",
                    "issuingCountry": "US",
                    "expirationDate": "2030-06-30"
                  }
                ],
                "createdAt": "2026-08-14T17:24:31.387Z",
                "lastUpdated": "2026-08-14T17:24:31.387Z",
                "_links": {
                  "self": "/v2/people/01a0014d-ce1a-7110-9bac-c4c59647a88d"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/people/01a0014d-ce1a-7110-9bac-c4c59647a88d/unmasked")
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

        var response = await Client.People.GetPersonUnmaskedAsync(
            "01a0014d-ce1a-7110-9bac-c4c59647a88d"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
