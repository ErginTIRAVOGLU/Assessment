using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Assessment.Kisiler.Api.Models.Enums
{
    //[JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BilgiTipi
    {
        [Description("Telefon")]
        Telefon =0,
        [Description("EPosta")]
        EPosta =1,
        [Description("Konum")]
        Konum =2
    }
}
