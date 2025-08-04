using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<MethodElementSettingsApplePayButtonType>))]
[Serializable]
public readonly record struct MethodElementSettingsApplePayButtonType : IStringEnum
{
    public static readonly MethodElementSettingsApplePayButtonType Plain = new(Values.Plain);

    public static readonly MethodElementSettingsApplePayButtonType Buy = new(Values.Buy);

    public static readonly MethodElementSettingsApplePayButtonType Donate = new(Values.Donate);

    public static readonly MethodElementSettingsApplePayButtonType CheckOut = new(Values.CheckOut);

    public static readonly MethodElementSettingsApplePayButtonType Book = new(Values.Book);

    public static readonly MethodElementSettingsApplePayButtonType Continue = new(Values.Continue);

    public static readonly MethodElementSettingsApplePayButtonType TopUp = new(Values.TopUp);

    public static readonly MethodElementSettingsApplePayButtonType Order = new(Values.Order);

    public static readonly MethodElementSettingsApplePayButtonType Rent = new(Values.Rent);

    public static readonly MethodElementSettingsApplePayButtonType Support = new(Values.Support);

    public static readonly MethodElementSettingsApplePayButtonType Contribute = new(
        Values.Contribute
    );

    public static readonly MethodElementSettingsApplePayButtonType Tip = new(Values.Tip);

    public static readonly MethodElementSettingsApplePayButtonType Pay = new(Values.Pay);

    public MethodElementSettingsApplePayButtonType(string value)
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
    public static MethodElementSettingsApplePayButtonType FromCustom(string value)
    {
        return new MethodElementSettingsApplePayButtonType(value);
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

    public static bool operator ==(MethodElementSettingsApplePayButtonType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MethodElementSettingsApplePayButtonType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MethodElementSettingsApplePayButtonType value) =>
        value.Value;

    public static explicit operator MethodElementSettingsApplePayButtonType(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Plain = "plain";

        public const string Buy = "buy";

        public const string Donate = "donate";

        public const string CheckOut = "check-out";

        public const string Book = "book";

        public const string Continue = "continue";

        public const string TopUp = "top-up";

        public const string Order = "order";

        public const string Rent = "rent";

        public const string Support = "support";

        public const string Contribute = "contribute";

        public const string Tip = "tip";

        public const string Pay = "pay";
    }
}
