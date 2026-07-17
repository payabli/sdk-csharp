using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyIn;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class Voidv2Test : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "code": "A0003",
              "reason": "Canceled",
              "explanation": "Transaction canceled",
              "action": "No action required",
              "data": {
                "parentOrgName": "Mrinal's Pet Supplies",
                "paypointDbaname": "Mrinal's Pet Shop North",
                "paypointLegalname": "Mrinal's Pet Shop North",
                "paypointEntryname": "495147f647",
                "paymentTransId": "3040-96dfa9a7c4ed4f82a3dd4a4a12ad28ae",
                "connectorName": "gp",
                "externalProcessorInformation": "",
                "gatewayTransId": "TRN_Ih68D6UZdip7OEQ2QFXat1yQSLF2nB",
                "method": "card",
                "batchNumber": "3040_combined_20251201_3a50747d-6b5c-40ef-9f69-93a9cc7fcb49",
                "batchAmount": 420,
                "payorId": 4440,
                "paymentData": {
                  "maskedAccount": "4XXXXXXXXXXX5439",
                  "accountType": "visa",
                  "accountExp": "12/25",
                  "holderName": "John Cassian",
                  "orderDescription": "",
                  "binData": {
                    "binMatchedLength": "6",
                    "binCardBrand": "VISA",
                    "binCardType": "CREDIT",
                    "binCardCategory": "CLASSIC",
                    "binCardIssuer": "",
                    "binCardIssuerCountry": "RUSSIAN FEDERATION",
                    "binCardIssuerCountryCodeA2": "RU",
                    "binCardIssuerCountryNumber": "643",
                    "binCardIsRegulated": "",
                    "binCardUseCategory": "",
                    "binCardIssuerCountryCodeA3": ""
                  },
                  "paymentDetails": {
                    "totalAmount": 105,
                    "serviceFee": 5,
                    "checkUniqueId": "",
                    "currency": "USD",
                    "categories": [],
                    "splitFunding": []
                  }
                },
                "transStatus": 5,
                "paypointId": 3040,
                "totalAmount": 105,
                "netAmount": 100,
                "feeAmount": 5,
                "settlementStatus": 0,
                "operation": "Sale",
                "responseData": {
                  "resultCode": "A0000",
                  "resultCodeText": "Approved",
                  "responsetext": "CAPTURED",
                  "authcode": "AXS425",
                  "transactionid": "TRN_Xo4dpKfmx3OxSc9svd2ccI6OOnyB2I",
                  "avsresponse": "N",
                  "avsresponse_text": "No Match, No address or ZIP match",
                  "cvvresponse": "M",
                  "cvvresponse_text": "CVV2/CVC2 match",
                  "response_code": "100",
                  "response_code_text": "Operation successful"
                },
                "source": "api",
                "scheduleReference": 0,
                "orgId": 123,
                "refundId": 0,
                "returnedId": 0,
                "chargebackId": 0,
                "retrievalId": 0,
                "invoiceData": {},
                "entrypageId": 0,
                "externalPaypointID": "",
                "isValidatedACH": false,
                "transactionTime": "2025-12-01T09:50:03.559",
                "customer": {
                  "firstName": "David",
                  "lastName": "Beckham",
                  "companyName": "Driving School LLC",
                  "billingAddress1": "Home Address",
                  "billingAddress2": "",
                  "billingCity": "",
                  "billingState": "",
                  "billingZip": "45157",
                  "billingCountry": "US",
                  "billingPhone": "+15555555555",
                  "billingEmail": "example@payabli.com",
                  "customerNumber": "C-90010",
                  "shippingAddress1": "Home Address",
                  "shippingAddress2": "",
                  "shippingCity": "",
                  "shippingState": "",
                  "shippingZip": "45157",
                  "shippingCountry": "US",
                  "customerId": 4440,
                  "customerStatus": 0
                },
                "cfeeTransactions": [
                  {
                    "cFeeTransid": "3040-96dfa9a7c4ed4f82a3dd4a4a12ad28ae",
                    "transStatus": 1,
                    "feeAmount": 5,
                    "settlementStatus": 0,
                    "operation": "Sale",
                    "responseData": {},
                    "refundId": 0,
                    "transactionTime": "2025-12-01T09:50:03.559Z"
                  }
                ],
                "transactionEvents": [
                  {
                    "transEvent": "Created",
                    "eventData": "0HNHD68HATSUC:00000001",
                    "eventTime": "2025-12-01T09:50:02.558651"
                  },
                  {
                    "transEvent": "Approved",
                    "eventData": "0HNHD68HATSUC:00000001",
                    "eventTime": "2025-12-01T09:50:03.609111"
                  }
                ],
                "pendingFeeAmount": 0,
                "riskFlagged": false,
                "riskFlaggedOn": "2025-12-01T09:50:02.547Z",
                "riskStatus": "PASSED",
                "riskReason": "",
                "riskAction": "",
                "riskActionCode": 0,
                "deviceId": "",
                "achSecCode": "",
                "achHolderType": "personal",
                "ipAddress": "255.255.255.255",
                "isSameDayACH": false
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/MoneyIn/void/10-3ffa27df-b171-44e0-b251-e95fbfc7a723")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyIn.Voidv2Async("10-3ffa27df-b171-44e0-b251-e95fbfc7a723");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
