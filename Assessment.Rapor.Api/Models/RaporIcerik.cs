namespace Assessment.Rapor.Api.Models
{
    public class RaporIcerik:IEntity
    {
        public string Konum { get; set; }
        public int KisiSayisi { get; set; }
        public int TelefonSayisi { get; set; }
        
        public Guid RaporlarId { get; set; }
        //public virtual Raporlar Raporlar { get; set; }
    }
}
