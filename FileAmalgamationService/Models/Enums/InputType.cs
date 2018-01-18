using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FileAmalgamationService.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum InputType
    {
        Text,
        FileSearchExpressionFilter,
        FileSearchExpressionRegex
    }
}
