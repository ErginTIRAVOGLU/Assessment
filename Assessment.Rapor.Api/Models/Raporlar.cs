using Assessment.Rapor.Api.Models.Enums;

namespace Assessment.Rapor.Api.Models
{
    public class Raporlar:IEntity
    {
        public DateTime TalepTarihi { get; set; } = DateTime.Now;
        public RaporDurumu RaporDurumu { get; set; } = RaporDurumu.Hazirlaniyor;
        
         
        public List<RaporIcerik> RaporIcerigi { get; set; }=new List<RaporIcerik>();
    }
}
