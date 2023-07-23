using Assessment.Kisiler.Api.Models.Enums;

namespace Assessment.Kisiler.Api.Models.Dtos
{
    public class IletisimBilgisiListDto
    {
        public Guid UUID { get; set; }
        public BilgiTipi BilgiTipi { get; set; }
        public string Icerik { get; set; }
    }
}
