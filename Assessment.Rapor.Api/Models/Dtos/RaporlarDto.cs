using Assessment.Rapor.Api.Models.Enums;

namespace Assessment.Rapor.Api.Models.Dtos
{
    public class RaporlarDto
    {
        public Guid UUID { get; set; }
        public DateTime TalepTarihi { get; set; } = DateTime.Now;
        public RaporDurumu RaporDurumu { get; set; } = RaporDurumu.Hazirlaniyor;

        public List<RaporIcerikDto> RaporIcerigi { get; set; } = new List<RaporIcerikDto>();
    }
}
