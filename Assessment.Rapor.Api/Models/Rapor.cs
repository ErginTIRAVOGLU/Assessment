using Assessment.Rapor.Api.Models.Enums;

namespace Assessment.Rapor.Api.Models
{
    public class Rapor:IEntity
    {
        public DateTime TalepTarihi { get; set; } = DateTime.Now;
        public RaporDurumu RaporDurumu { get; set; } = RaporDurumu.Hazirlaniyor;
    }
}
