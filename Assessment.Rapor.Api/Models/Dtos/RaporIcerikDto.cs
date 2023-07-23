namespace Assessment.Rapor.Api.Models.Dtos
{
    public class RaporIcerikDto
    {
        public Guid UUID { get; set; }
        public string Konum { get; set; }
        public int KisiSayisi { get; set; }
        public int TelefonSayisi { get; set; }

        public Guid RaporlarId { get; set; }
        //public virtual RaporlarDto Raporlar { get; set; }
    }
}
