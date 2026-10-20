using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Applications;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SubmitApplicationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "signer": {
                "personReference": "01a0014d-ce1a-7110-9bac-c4c59647a88d",
                "signature": "Marcus J Delgado",
                "signatureType": "type",
                "acceptance": true,
                "pciAttestation": true,
                "reportedSignerIp": "203.0.113.7"
              }
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Application submitted",
              "traceId": "0HNONVRI1SMEU:0000068E",
              "data": {
                "requestsReference": "3f3caa7b-bdfe-4bf1-814b-30d54859247c",
                "applicationStatus": "submitted",
                "allowedActions": [
                  "startVerification",
                  "withdraw",
                  "abandon",
                  "markError"
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/requests/3f3caa7b-bdfe-4bf1-814b-30d54859247c/submit")
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

        var response = await Client.Applications.SubmitApplicationAsync(
            "3f3caa7b-bdfe-4bf1-814b-30d54859247c",
            new SubmitApplicationRequest
            {
                Signer = new SubmitSigner
                {
                    PersonReference = "01a0014d-ce1a-7110-9bac-c4c59647a88d",
                    Signature = "Marcus J Delgado",
                    SignatureType = SignatureType.Type,
                    Acceptance = true,
                    PciAttestation = true,
                    ReportedSignerIp = "203.0.113.7",
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "signer": {
                "personReference": "01a0014d-ce1a-7110-9bac-c4c59647a88d",
                "signature": "Marcus J Delgado",
                "signatureType": "type",
                "acceptance": true,
                "pciAttestation": true,
                "reportedSignerIp": "203.0.113.7"
              }
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Application submitted",
              "traceId": "0HNP8M4GTH3IP:0000001B",
              "data": {
                "requestsReference": "b7e2c915-4f0a-4d6b-a3c8-91e5d2f7c406",
                "applicationStatus": "submitted",
                "allowedActions": [
                  "startVerification",
                  "withdraw",
                  "abandon",
                  "markError"
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/requests/b7e2c915-4f0a-4d6b-a3c8-91e5d2f7c406/submit")
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

        var response = await Client.Applications.SubmitApplicationAsync(
            "b7e2c915-4f0a-4d6b-a3c8-91e5d2f7c406",
            new SubmitApplicationRequest
            {
                Signer = new SubmitSigner
                {
                    PersonReference = "01a0014d-ce1a-7110-9bac-c4c59647a88d",
                    Signature = "Marcus J Delgado",
                    SignatureType = SignatureType.Type,
                    Acceptance = true,
                    PciAttestation = true,
                    ReportedSignerIp = "203.0.113.7",
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
