using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyIn;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetpaidTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "paymentDetails": {
                "totalAmount": 1.1
              },
              "paymentMethod": {
                "cardexp": "cardexp",
                "cardnumber": "cardnumber",
                "method": "card"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseText": "responseText",
              "isSuccess": true,
              "pageIdentifier": "pageIdentifier",
              "responseData": {
                "authCode": "authCode",
                "transactionDetails": {
                  "parentOrgName": "parentOrgName",
                  "paypointDbaname": "paypointDbaname",
                  "paypointLegalname": "paypointLegalname",
                  "paypointEntryname": "paypointEntryname",
                  "paymentTransId": "paymentTransId",
                  "connectorName": "connectorName",
                  "externalProcessorInformation": "externalProcessorInformation",
                  "gatewayTransId": "gatewayTransId",
                  "orderId": "orderId",
                  "method": "ach",
                  "batchNumber": "batchNumber",
                  "batchAmount": 1.1,
                  "payorId": 1000000,
                  "paymentData": {
                    "holderName": "holderName",
                    "paymentDetails": {
                      "totalAmount": 1.1,
                      "serviceFee": 1.1,
                      "checkUniqueId": "checkUniqueId",
                      "currency": "currency",
                      "categories": [],
                      "splitFunding": []
                    }
                  },
                  "transStatus": 1,
                  "paypointId": 1000000,
                  "totalAmount": 1.1,
                  "netAmount": 1.1,
                  "feeAmount": 1.1,
                  "settlementStatus": 1,
                  "operation": "operation",
                  "responseData": {
                    "responsetext": "responsetext",
                    "transactionid": "transactionid",
                    "response_code": "response_code",
                    "response_code_text": "response_code_text"
                  },
                  "source": "source",
                  "scheduleReference": 1000000,
                  "orgId": 1000000,
                  "refundId": 1000000,
                  "returnedId": 1000000,
                  "chargebackId": 1000000,
                  "retrievalId": 1000000,
                  "transAdditionalData": {
                    "key": "value"
                  },
                  "invoiceData": {},
                  "entrypageId": 1000000,
                  "externalPaypointID": "externalPaypointID",
                  "isValidatedACH": true,
                  "transactionTime": "transactionTime",
                  "customer": {
                    "firstName": "firstName",
                    "lastName": "lastName",
                    "customerId": 1000000,
                    "customerStatus": 1
                  },
                  "splitFundingInstructions": [
                    {}
                  ],
                  "cfeeTransactions": [
                    {}
                  ],
                  "transactionEvents": [
                    {
                      "transEvent": "transEvent",
                      "eventData": "eventData",
                      "eventTime": "eventTime"
                    }
                  ],
                  "pendingFeeAmount": 1.1,
                  "riskFlagged": true,
                  "riskFlaggedOn": "2024-01-15T09:30:00.000Z",
                  "riskStatus": "riskStatus",
                  "riskReason": "riskReason",
                  "riskAction": "riskAction",
                  "riskActionCode": 1,
                  "deviceId": "deviceId",
                  "achSecCode": "achSecCode",
                  "achHolderType": "personal",
                  "ipAddress": "ipAddress",
                  "isSameDayACH": true,
                  "walletType": "walletType"
                },
                "referenceId": "referenceId",
                "resultCode": 1,
                "resultText": "resultText",
                "avsResponseText": "avsResponseText",
                "cvvResponseText": "cvvResponseText",
                "customerId": 1000000,
                "methodReferenceId": "methodReferenceId"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/getpaid")
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

        var response = await Client.MoneyIn.GetpaidAsync(
            new RequestPayment
            {
                Body = new TransRequestBody
                {
                    PaymentDetails = new PaymentDetail { TotalAmount = 1.1 },
                    PaymentMethod = new PayMethodCredit
                    {
                        Cardexp = "cardexp",
                        Cardnumber = "cardnumber",
                        Method = PayMethodCreditMethod.Card,
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
