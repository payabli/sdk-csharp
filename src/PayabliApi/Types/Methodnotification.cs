using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<Methodnotification>))]
[Serializable]
public readonly record struct Methodnotification : IStringEnum
{
    public static readonly Methodnotification Email = new(Values.Email);

    public static readonly Methodnotification Sms = new(Values.Sms);

    public static readonly Methodnotification Web = new(Values.Web);

    public static readonly Methodnotification ReportEmail = new(Values.ReportEmail);

    public static readonly Methodnotification ReportWeb = new(Values.ReportWeb);

    public Methodnotification(string value)
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
    public static Methodnotification FromCustom(string value)
    {
        return new Methodnotification(value);
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

    public static bool operator ==(Methodnotification value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Methodnotification value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Methodnotification value) => value.Value;

    public static explicit operator Methodnotification(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Email = "email";

        public const string Sms = "sms";

        public const string Web = "web";

        public const string ReportEmail = "report-email";

        public const string ReportWeb = "report-web";
    }
}
