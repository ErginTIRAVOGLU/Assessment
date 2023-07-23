namespace Assessment.Kisiler.Api.Models
{
    public class Kisi:IEntity
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
        public List<IletisimBilgisi> IletisimBilgileri { get; set; } = new List<IletisimBilgisi>();
    }
}
