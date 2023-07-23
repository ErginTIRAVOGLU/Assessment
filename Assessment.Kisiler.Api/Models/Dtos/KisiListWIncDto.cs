namespace Assessment.Kisiler.Api.Models.Dtos
{
    public class KisiListWIncDto
    {
        public Guid UUID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
        public List<IletisimBilgisiListDto> IletisimBilgileri { get; set; } = new List<IletisimBilgisiListDto>();
    }
}
