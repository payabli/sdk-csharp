using global::System.Text.Json.Serialization;

namespace PayabliApi.Core;

public interface IStringEnum : IEquatable<string>
{
    public string Value { get; }
}
