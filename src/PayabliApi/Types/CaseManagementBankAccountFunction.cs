using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(
    typeof(CaseManagementBankAccountFunction.CaseManagementBankAccountFunctionSerializer)
)]
[Serializable]
public readonly record struct CaseManagementBankAccountFunction : IStringEnum
{
    public static readonly CaseManagementBankAccountFunction Deposits = new(Values.Deposits);

    public static readonly CaseManagementBankAccountFunction Withdrawals = new(Values.Withdrawals);

    public static readonly CaseManagementBankAccountFunction DepositsAndWithdrawals = new(
        Values.DepositsAndWithdrawals
    );

    public static readonly CaseManagementBankAccountFunction Remittances = new(Values.Remittances);

    public static readonly CaseManagementBankAccountFunction RemittancesAndDeposits = new(
        Values.RemittancesAndDeposits
    );

    public static readonly CaseManagementBankAccountFunction RemittancesAndWithdrawals = new(
        Values.RemittancesAndWithdrawals
    );

    public static readonly CaseManagementBankAccountFunction RemittancesDepositsAndWithdrawals =
        new(Values.RemittancesDepositsAndWithdrawals);

    public CaseManagementBankAccountFunction(string value)
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
    public static CaseManagementBankAccountFunction FromCustom(string value)
    {
        return new CaseManagementBankAccountFunction(value);
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

    public static bool operator ==(CaseManagementBankAccountFunction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CaseManagementBankAccountFunction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CaseManagementBankAccountFunction value) => value.Value;

    public static explicit operator CaseManagementBankAccountFunction(string value) => new(value);

    internal class CaseManagementBankAccountFunctionSerializer
        : JsonConverter<CaseManagementBankAccountFunction>
    {
        public override CaseManagementBankAccountFunction Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new CaseManagementBankAccountFunction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CaseManagementBankAccountFunction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CaseManagementBankAccountFunction ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new CaseManagementBankAccountFunction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CaseManagementBankAccountFunction value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Deposits = "Deposits";

        public const string Withdrawals = "Withdrawals";

        public const string DepositsAndWithdrawals = "DepositsAndWithdrawals";

        public const string Remittances = "Remittances";

        public const string RemittancesAndDeposits = "RemittancesAndDeposits";

        public const string RemittancesAndWithdrawals = "RemittancesAndWithdrawals";

        public const string RemittancesDepositsAndWithdrawals = "RemittancesDepositsAndWithdrawals";
    }
}
