using System.Globalization;
using System.Text.Json;
using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test;

[TestFixture]
public class TransferTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "transferId": 79851,
              "paypointId": 705,
              "batchNumber": "split_705_gp_11-16-2024",
              "batchCurrency": "USD",
              "batchRecords": 1,
              "transferIdentifier": "bbcbfed7-e535-45fe-8d62-000000",
              "batchId": 111430,
              "paypointEntryName": "47ae3de37",
              "paypointLegalName": "Gruzya Outdoor Outfitters LLC",
              "paypointDbaName": "Gruzya Outdoor Outfitters",
              "paypointLogo": "https://example.com/logo.png",
              "parentOrgName": "Pilgrim Planner",
              "parentOrgId": 12345,
              "parentOrgEntryName": "43aebc000",
              "parentOrgLogo": "https://example.com/parent-logo.png",
              "externalPaypointID": "ext-12345",
              "bankAccount": {
                "accountNumber": "****1234",
                "routingNumber": "123456789"
              },
              "transferDate": "2024-11-17T08:20:07.288+00:00",
              "processor": "gp",
              "transferStatus": 2,
              "grossAmount": 1029,
              "chargeBackAmount": 25,
              "returnedAmount": 0,
              "holdAmount": 0,
              "releasedAmount": 0,
              "billingFeesAmount": 0,
              "thirdPartyPaidAmount": 0,
              "adjustmentsAmount": 0,
              "netTransferAmount": 1004,
              "splitAmount": 650.22,
              "eventsData": [
                {
                  "description": "Transfer Created",
                  "eventTime": "2024-11-16T08:15:33.4364067Z",
                  "refData": null,
                  "extraData": null,
                  "source": "worker"
                }
              ],
              "messages": []
            }
            """;
        var expectedObject = new Transfer
        {
            TransferId = 79851,
            PaypointId = 705,
            BatchNumber = "split_705_gp_11-16-2024",
            BatchCurrency = "USD",
            BatchRecords = 1,
            TransferIdentifier = "bbcbfed7-e535-45fe-8d62-000000",
            BatchId = 111430,
            PaypointEntryName = "47ae3de37",
            PaypointLegalName = "Gruzya Outdoor Outfitters LLC",
            PaypointDbaName = "Gruzya Outdoor Outfitters",
            PaypointLogo = "https://example.com/logo.png",
            ParentOrgName = "Pilgrim Planner",
            ParentOrgId = 12345,
            ParentOrgEntryName = "43aebc000",
            ParentOrgLogo = "https://example.com/parent-logo.png",
            ExternalPaypointId = "ext-12345",
            BankAccount = new TransferBankAccount
            {
                AccountNumber = "****1234",
                RoutingNumber = "123456789",
            },
            TransferDate = "2024-11-17T08:20:07.288+00:00",
            Processor = "gp",
            TransferStatus = 2,
            GrossAmount = 1029,
            ChargeBackAmount = 25,
            ReturnedAmount = 0,
            HoldAmount = 0,
            ReleasedAmount = 0,
            BillingFeesAmount = 0,
            ThirdPartyPaidAmount = 0,
            AdjustmentsAmount = 0,
            NetTransferAmount = 1004,
            SplitAmount = 650.22,
            EventsData = new List<GeneralEvents>()
            {
                new GeneralEvents
                {
                    Description = "Transfer Created",
                    EventTime = DateTime.Parse(
                        "2024-11-16T08:15:33.436Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    RefData = null,
                    ExtraData = null,
                    Source = "worker",
                },
            },
            Messages = new List<TransferMessage>() { },
        };
        var deserializedObject = JsonUtils.Deserialize<Transfer>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var expectedJson = """
            {
              "transferId": 79851,
              "paypointId": 705,
              "batchNumber": "split_705_gp_11-16-2024",
              "batchCurrency": "USD",
              "batchRecords": 1,
              "transferIdentifier": "bbcbfed7-e535-45fe-8d62-000000",
              "batchId": 111430,
              "paypointEntryName": "47ae3de37",
              "paypointLegalName": "Gruzya Outdoor Outfitters LLC",
              "paypointDbaName": "Gruzya Outdoor Outfitters",
              "paypointLogo": "https://example.com/logo.png",
              "parentOrgName": "Pilgrim Planner",
              "parentOrgId": 12345,
              "parentOrgEntryName": "43aebc000",
              "parentOrgLogo": "https://example.com/parent-logo.png",
              "externalPaypointID": "ext-12345",
              "bankAccount": {
                "accountNumber": "****1234",
                "routingNumber": "123456789"
              },
              "transferDate": "2024-11-17T08:20:07.288+00:00",
              "processor": "gp",
              "transferStatus": 2,
              "grossAmount": 1029,
              "chargeBackAmount": 25,
              "returnedAmount": 0,
              "holdAmount": 0,
              "releasedAmount": 0,
              "billingFeesAmount": 0,
              "thirdPartyPaidAmount": 0,
              "adjustmentsAmount": 0,
              "netTransferAmount": 1004,
              "splitAmount": 650.22,
              "eventsData": [
                {
                  "description": "Transfer Created",
                  "eventTime": "2024-11-16T08:15:33.4364067Z",
                  "refData": null,
                  "extraData": null,
                  "source": "worker"
                }
              ],
              "messages": []
            }
            """;
        var actualObj = new Transfer
        {
            TransferId = 79851,
            PaypointId = 705,
            BatchNumber = "split_705_gp_11-16-2024",
            BatchCurrency = "USD",
            BatchRecords = 1,
            TransferIdentifier = "bbcbfed7-e535-45fe-8d62-000000",
            BatchId = 111430,
            PaypointEntryName = "47ae3de37",
            PaypointLegalName = "Gruzya Outdoor Outfitters LLC",
            PaypointDbaName = "Gruzya Outdoor Outfitters",
            PaypointLogo = "https://example.com/logo.png",
            ParentOrgName = "Pilgrim Planner",
            ParentOrgId = 12345,
            ParentOrgEntryName = "43aebc000",
            ParentOrgLogo = "https://example.com/parent-logo.png",
            ExternalPaypointId = "ext-12345",
            BankAccount = new TransferBankAccount
            {
                AccountNumber = "****1234",
                RoutingNumber = "123456789",
            },
            TransferDate = "2024-11-17T08:20:07.288+00:00",
            Processor = "gp",
            TransferStatus = 2,
            GrossAmount = 1029,
            ChargeBackAmount = 25,
            ReturnedAmount = 0,
            HoldAmount = 0,
            ReleasedAmount = 0,
            BillingFeesAmount = 0,
            ThirdPartyPaidAmount = 0,
            AdjustmentsAmount = 0,
            NetTransferAmount = 1004,
            SplitAmount = 650.22,
            EventsData = new List<GeneralEvents>()
            {
                new GeneralEvents
                {
                    Description = "Transfer Created",
                    EventTime = DateTime.Parse(
                        "2024-11-16T08:15:33.436Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    RefData = null,
                    ExtraData = null,
                    Source = "worker",
                },
            },
            Messages = new List<TransferMessage>() { },
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }
}
