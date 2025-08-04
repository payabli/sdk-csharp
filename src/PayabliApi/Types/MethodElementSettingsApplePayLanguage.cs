using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<MethodElementSettingsApplePayLanguage>))]
[Serializable]
public readonly record struct MethodElementSettingsApplePayLanguage : IStringEnum
{
    public static readonly MethodElementSettingsApplePayLanguage EnUs = new(Values.EnUs);

    public static readonly MethodElementSettingsApplePayLanguage ArAb = new(Values.ArAb);

    public static readonly MethodElementSettingsApplePayLanguage CaEs = new(Values.CaEs);

    public static readonly MethodElementSettingsApplePayLanguage ZhCn = new(Values.ZhCn);

    public static readonly MethodElementSettingsApplePayLanguage ZhHk = new(Values.ZhHk);

    public static readonly MethodElementSettingsApplePayLanguage ZhTw = new(Values.ZhTw);

    public static readonly MethodElementSettingsApplePayLanguage HrHr = new(Values.HrHr);

    public static readonly MethodElementSettingsApplePayLanguage CsCz = new(Values.CsCz);

    public static readonly MethodElementSettingsApplePayLanguage DaDk = new(Values.DaDk);

    public static readonly MethodElementSettingsApplePayLanguage DeDe = new(Values.DeDe);

    public static readonly MethodElementSettingsApplePayLanguage NlNl = new(Values.NlNl);

    public static readonly MethodElementSettingsApplePayLanguage EnAu = new(Values.EnAu);

    public static readonly MethodElementSettingsApplePayLanguage EnGb = new(Values.EnGb);

    public static readonly MethodElementSettingsApplePayLanguage FiFi = new(Values.FiFi);

    public static readonly MethodElementSettingsApplePayLanguage FrCa = new(Values.FrCa);

    public static readonly MethodElementSettingsApplePayLanguage FrFr = new(Values.FrFr);

    public static readonly MethodElementSettingsApplePayLanguage ElGr = new(Values.ElGr);

    public static readonly MethodElementSettingsApplePayLanguage HeIl = new(Values.HeIl);

    public static readonly MethodElementSettingsApplePayLanguage HiIn = new(Values.HiIn);

    public static readonly MethodElementSettingsApplePayLanguage HuHu = new(Values.HuHu);

    public static readonly MethodElementSettingsApplePayLanguage IdId = new(Values.IdId);

    public static readonly MethodElementSettingsApplePayLanguage ItIt = new(Values.ItIt);

    public static readonly MethodElementSettingsApplePayLanguage JaJp = new(Values.JaJp);

    public static readonly MethodElementSettingsApplePayLanguage KoKr = new(Values.KoKr);

    public static readonly MethodElementSettingsApplePayLanguage MsMy = new(Values.MsMy);

    public static readonly MethodElementSettingsApplePayLanguage NbNo = new(Values.NbNo);

    public static readonly MethodElementSettingsApplePayLanguage PlPl = new(Values.PlPl);

    public static readonly MethodElementSettingsApplePayLanguage PtBr = new(Values.PtBr);

    public static readonly MethodElementSettingsApplePayLanguage PtPt = new(Values.PtPt);

    public static readonly MethodElementSettingsApplePayLanguage RoRo = new(Values.RoRo);

    public static readonly MethodElementSettingsApplePayLanguage RuRu = new(Values.RuRu);

    public static readonly MethodElementSettingsApplePayLanguage SkSk = new(Values.SkSk);

    public static readonly MethodElementSettingsApplePayLanguage EsMx = new(Values.EsMx);

    public static readonly MethodElementSettingsApplePayLanguage EsEs = new(Values.EsEs);

    public static readonly MethodElementSettingsApplePayLanguage SvSe = new(Values.SvSe);

    public static readonly MethodElementSettingsApplePayLanguage ThTh = new(Values.ThTh);

    public static readonly MethodElementSettingsApplePayLanguage TrTr = new(Values.TrTr);

    public static readonly MethodElementSettingsApplePayLanguage UkUa = new(Values.UkUa);

    public static readonly MethodElementSettingsApplePayLanguage ViVn = new(Values.ViVn);

    public MethodElementSettingsApplePayLanguage(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static MethodElementSettingsApplePayLanguage FromCustom(string value)
    {
        return new MethodElementSettingsApplePayLanguage(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(MethodElementSettingsApplePayLanguage value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MethodElementSettingsApplePayLanguage value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MethodElementSettingsApplePayLanguage value) =>
        value.Value;

    public static explicit operator MethodElementSettingsApplePayLanguage(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string EnUs = "en-US";

        public const string ArAb = "ar-AB";

        public const string CaEs = "ca-ES";

        public const string ZhCn = "zh-CN";

        public const string ZhHk = "zh-HK";

        public const string ZhTw = "zh-TW";

        public const string HrHr = "hr-HR";

        public const string CsCz = "cs-CZ";

        public const string DaDk = "da-DK";

        public const string DeDe = "de-DE";

        public const string NlNl = "nl-NL";

        public const string EnAu = "en-AU";

        public const string EnGb = "en-GB";

        public const string FiFi = "fi-FI";

        public const string FrCa = "fr-CA";

        public const string FrFr = "fr-FR";

        public const string ElGr = "el-GR";

        public const string HeIl = "he-IL";

        public const string HiIn = "hi-IN";

        public const string HuHu = "hu-HU";

        public const string IdId = "id-ID";

        public const string ItIt = "it-IT";

        public const string JaJp = "ja-JP";

        public const string KoKr = "ko-KR";

        public const string MsMy = "ms-MY";

        public const string NbNo = "nb-NO";

        public const string PlPl = "pl-PL";

        public const string PtBr = "pt-BR";

        public const string PtPt = "pt-PT";

        public const string RoRo = "ro-RO";

        public const string RuRu = "ru-RU";

        public const string SkSk = "sk-SK";

        public const string EsMx = "es-MX";

        public const string EsEs = "es-ES";

        public const string SvSe = "sv-SE";

        public const string ThTh = "th-TH";

        public const string TrTr = "tr-TR";

        public const string UkUa = "uk-UA";

        public const string ViVn = "vi-VN";
    }
}
