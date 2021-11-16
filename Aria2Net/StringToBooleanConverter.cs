using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Aria2Net
{
    internal class StringToBooleanConverter : JsonConverter<bool>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var value = reader.GetString();

                return value?.ToLowerInvariant() == "true";
            }

            return false;
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value ? "true" : "false");
        }
    }
}
