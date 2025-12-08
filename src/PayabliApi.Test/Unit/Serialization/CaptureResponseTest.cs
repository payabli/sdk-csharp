using System.Text.Json;
using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test;

[TestFixture]
public class CaptureResponseTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "responseCode": 1,
              "pageIdentifier": null,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "authCode": "123456",
                "referenceId": "10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13",
                "resultCode": 1,
                "resultText": "SUCCESS",
                "avsResponseText": null,
                "cvvResponseText": null,
                "customerId": null,
                "methodReferenceId": null
              }
            }
            """;
        var expectedObject = new CaptureResponse
        {
            ResponseCode = 1,
            PageIdentifier = null,
            RoomId = 0,
            IsSuccess = true,
            ResponseText = "Success",
            ResponseData = new CaptureResponseData
            {
                AuthCode = "123456",
                ReferenceId = "10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13",
                ResultCode = 1,
                ResultText = "SUCCESS",
                AvsResponseText = null,
                CvvResponseText = null,
                CustomerId = null,
                MethodReferenceId = null,
            },
        };
        var deserializedObject = JsonUtils.Deserialize<CaptureResponse>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var expectedJson = """
            {
              "responseCode": 1,
              "pageIdentifier": null,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "authCode": "123456",
                "referenceId": "10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13",
                "resultCode": 1,
                "resultText": "SUCCESS",
                "avsResponseText": null,
                "cvvResponseText": null,
                "customerId": null,
                "methodReferenceId": null
              }
            }
            """;
        var actualObj = new CaptureResponse
        {
            ResponseCode = 1,
            PageIdentifier = null,
            RoomId = 0,
            IsSuccess = true,
            ResponseText = "Success",
            ResponseData = new CaptureResponseData
            {
                AuthCode = "123456",
                ReferenceId = "10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13",
                ResultCode = 1,
                ResultText = "SUCCESS",
                AvsResponseText = null,
                CvvResponseText = null,
                CustomerId = null,
                MethodReferenceId = null,
            },
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }
}
