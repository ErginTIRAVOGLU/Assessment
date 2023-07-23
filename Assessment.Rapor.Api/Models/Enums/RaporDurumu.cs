using System.ComponentModel;

namespace Assessment.Rapor.Api.Models.Enums
{
    public enum RaporDurumu
    {
        [Description("Hazırlanıyor")]
        Hazirlaniyor = 0,
        [Description("Tamamlandı")]
        Tamamlandi = 1
    }
}
