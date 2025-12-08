using System.Text.Json;
using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test;

[TestFixture]
public class BinDataTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization_1()
    {
        var json = """
            {
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
            }
            """;
        var expectedObject = new BinData
        {
            BinMatchedLength = "6",
            BinCardBrand = "Visa",
            BinCardType = "Credit",
            BinCardCategory = "PLATINUM",
            BinCardIssuer = "Bank of Example",
            BinCardIssuerCountry = "United States",
            BinCardIssuerCountryCodeA2 = "US",
            BinCardIssuerCountryNumber = "840",
            BinCardIsRegulated = "false",
            BinCardUseCategory = "Consumer",
            BinCardIssuerCountryCodeA3 = "USA",
        };
        var deserializedObject = JsonUtils.Deserialize<BinData>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_1()
    {
        var expectedJson = """
            {
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
            }
            """;
        var actualObj = new BinData
        {
            BinMatchedLength = "6",
            BinCardBrand = "Visa",
            BinCardType = "Credit",
            BinCardCategory = "PLATINUM",
            BinCardIssuer = "Bank of Example",
            BinCardIssuerCountry = "United States",
            BinCardIssuerCountryCodeA2 = "US",
            BinCardIssuerCountryNumber = "840",
            BinCardIsRegulated = "false",
            BinCardUseCategory = "Consumer",
            BinCardIssuerCountryCodeA3 = "USA",
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_2()
    {
        var json = """
            {
              "binMatchedLength": "6",
              "binCardBrand": "VISA",
              "binCardType": "DEBIT",
              "binCardCategory": "CLASSIC",
              "binCardIssuer": "CONOTOXIA SP. Z O.O",
              "binCardIssuerCountry": "POLAND",
              "binCardIssuerCountryCodeA2": "PL",
              "binCardIssuerCountryNumber": "616",
              "binCardIsRegulated": "true",
              "binCardUseCategory": "Consumer",
              "binCardIssuerCountryCodeA3": "POL"
            }
            """;
        var expectedObject = new BinData
        {
            BinMatchedLength = "6",
            BinCardBrand = "VISA",
            BinCardType = "DEBIT",
            BinCardCategory = "CLASSIC",
            BinCardIssuer = "CONOTOXIA SP. Z O.O",
            BinCardIssuerCountry = "POLAND",
            BinCardIssuerCountryCodeA2 = "PL",
            BinCardIssuerCountryNumber = "616",
            BinCardIsRegulated = "true",
            BinCardUseCategory = "Consumer",
            BinCardIssuerCountryCodeA3 = "POL",
        };
        var deserializedObject = JsonUtils.Deserialize<BinData>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_2()
    {
        var expectedJson = """
            {
              "binMatchedLength": "6",
              "binCardBrand": "VISA",
              "binCardType": "DEBIT",
              "binCardCategory": "CLASSIC",
              "binCardIssuer": "CONOTOXIA SP. Z O.O",
              "binCardIssuerCountry": "POLAND",
              "binCardIssuerCountryCodeA2": "PL",
              "binCardIssuerCountryNumber": "616",
              "binCardIsRegulated": "true",
              "binCardUseCategory": "Consumer",
              "binCardIssuerCountryCodeA3": "POL"
            }
            """;
        var actualObj = new BinData
        {
            BinMatchedLength = "6",
            BinCardBrand = "VISA",
            BinCardType = "DEBIT",
            BinCardCategory = "CLASSIC",
            BinCardIssuer = "CONOTOXIA SP. Z O.O",
            BinCardIssuerCountry = "POLAND",
            BinCardIssuerCountryCodeA2 = "PL",
            BinCardIssuerCountryNumber = "616",
            BinCardIsRegulated = "true",
            BinCardUseCategory = "Consumer",
            BinCardIssuerCountryCodeA3 = "POL",
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }
}
