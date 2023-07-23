using Assessment.Kisiler.Api.Models.Enums;

namespace Assessment.Kisiler.Api.Models
{
    public class IletisimBilgisi:IEntity
    {       
        public BilgiTipi BilgiTipi { get; set; }
        public string Icerik { get; set; }

        public Guid KisiId { get; set; }
        public virtual Kisi Kisi { get; set; }
    }
}
