using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Assessment.Kisiler.Api.Models
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PgConnectionString"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Kisi kisi1 = new Kisi { UUID = Guid.Parse("da1319dd-4e81-4f50-9d4b-846b83abf0a3"), Ad = "Amanda", Soyad = "Youngs", Firma = "Edgewire" };
            Kisi kisi2 = new Kisi { UUID = Guid.Parse("ecadbd93-39f9-43a7-9c76-eea2be8686b0"), Ad = "Jarrad", Soyad = "Agglione", Firma = "Devshare" };
            Kisi kisi3 = new Kisi { UUID = Guid.Parse("136ce6bf-5eeb-468d-ba30-bb7ce1843cd0"), Ad = "Kenyon", Soyad = "Waylen", Firma = "Twitterwire" };
            Kisi kisi4 = new Kisi { UUID = Guid.Parse("36aec2e1-3aa7-4d9e-91f3-d0efbee71b87"), Ad = "Linea", Soyad = "Duigan", Firma = "Fivechat" };
            Kisi kisi5 = new Kisi { UUID = Guid.Parse("8b746864-eff7-49f6-ac4e-79a48fbf7c39"), Ad = "Lock", Soyad = "Molyneaux", Firma = "Feedfish" };

            modelBuilder.Entity<Kisi>().HasData(kisi1);
            modelBuilder.Entity<Kisi>().HasData(kisi2);
            modelBuilder.Entity<Kisi>().HasData(kisi3);
            modelBuilder.Entity<Kisi>().HasData(kisi4);
            modelBuilder.Entity<Kisi>().HasData(kisi5);
            modelBuilder.Entity<Kisi>().HasData(new Kisi { UUID = Guid.Parse("cf9b359d-8097-48c2-8a74-85619aecc868"), Ad = "Kandy", Soyad = "Hairs", Firma = "Rhyzio" });
            modelBuilder.Entity<Kisi>().HasData(new Kisi { UUID = Guid.Parse("77c6a1e7-f295-497f-9d4b-31b18c8d73f6"), Ad = "Priscella", Soyad = "Eul", Firma = "Photobean" });
            modelBuilder.Entity<Kisi>().HasData(new Kisi { UUID = Guid.Parse("3f174232-8ecd-4908-a239-d080e6749e97"), Ad = "Therine", Soyad = "Bancroft", Firma = "Quire" });
            modelBuilder.Entity<Kisi>().HasData(new Kisi { UUID = Guid.Parse("e128ad20-dc81-4cd1-81de-e5e7d9dfe53f"), Ad = "Pincus", Soyad = "Portingale", Firma = "Riffwire" });
            modelBuilder.Entity<Kisi>().HasData(new Kisi { UUID = Guid.Parse("b7e13b1a-be3f-4d7b-b170-38d696e47d0b"), Ad = "Melva", Soyad = "Simnor", Firma = "Thoughtbeat" });
            modelBuilder.Entity<Kisi>().HasData(new Kisi { UUID = Guid.Parse("5e0adc61-cc87-4ad3-9462-5d1364dbe598"), Ad = "Reed", Soyad = "Saynor", Firma = "Livetube" });
            modelBuilder.Entity<Kisi>().HasData(new Kisi { UUID = Guid.Parse("c90207e1-352a-4dbd-96a4-1cb914a5b936"), Ad = "Kyrstin", Soyad = "Yea", Firma = "Rhyzio" });
            modelBuilder.Entity<Kisi>().HasData(new Kisi { UUID = Guid.Parse("684fc466-b6de-4214-a4db-856c63703eb6"), Ad = "Rene", Soyad = "Faley", Firma = "Shufflebeat" });
            modelBuilder.Entity<Kisi>().HasData(new Kisi { UUID = Guid.Parse("1bd60b22-87bb-4163-b47c-07426928e89f"), Ad = "Rosalie", Soyad = "O'Neill", Firma = "Flashpoint" });
            modelBuilder.Entity<Kisi>().HasData(new Kisi { UUID = Guid.Parse("b97cb918-e9c2-42d2-8934-5cd420a0d86c"), Ad = "Carlota", Soyad = "Semble", Firma = "Photobug" });
            modelBuilder.Entity<Kisi>().HasData(new Kisi { UUID = Guid.Parse("ed7cf807-35d3-481b-8525-540a02b4f68d"), Ad = "Dario", Soyad = "Jobey", Firma = "Camido" });
            modelBuilder.Entity<Kisi>().HasData(new Kisi { UUID = Guid.Parse("a0bf6b9e-05d6-4675-8d25-0b72aa0a0735"), Ad = "Prescott", Soyad = "Tinsey", Firma = "Twitterwire" });
            modelBuilder.Entity<Kisi>().HasData(new Kisi { UUID = Guid.Parse("c9adfe33-ac0f-438e-b4bf-149a0b68e809"), Ad = "Romeo", Soyad = "Paterno", Firma = "Quamba" });
            modelBuilder.Entity<Kisi>().HasData(new Kisi { UUID = Guid.Parse("9a70a61b-d2db-4b1a-b3d3-1cb70eff0239"), Ad = "Kristofer", Soyad = "Salzberg", Firma = "Mycat" });
            modelBuilder.Entity<Kisi>().HasData(new Kisi { UUID = Guid.Parse("adaedde8-a3ae-4b1f-8130-70dce3ab1b11"), Ad = "Dulcie", Soyad = "Heintze", Firma = "Pixoboo" });

            modelBuilder.Entity<IletisimBilgisi>().HasData(new IletisimBilgisi { UUID = Guid.NewGuid(), BilgiTipi = Enums.BilgiTipi.EPosta, Icerik = "Amanda.Youngs@Edgewire.com", KisiId = kisi1.UUID });
            modelBuilder.Entity<IletisimBilgisi>().HasData(new IletisimBilgisi { UUID = Guid.NewGuid(), BilgiTipi = Enums.BilgiTipi.EPosta, Icerik = "Jarrad.Agglione@Devshare.com", KisiId = kisi2.UUID });
            modelBuilder.Entity<IletisimBilgisi>().HasData(new IletisimBilgisi { UUID = Guid.NewGuid(), BilgiTipi = Enums.BilgiTipi.EPosta, Icerik = "Kenyon.Waylen@Twitterwire.com", KisiId = kisi3.UUID });
            modelBuilder.Entity<IletisimBilgisi>().HasData(new IletisimBilgisi { UUID = Guid.NewGuid(), BilgiTipi = Enums.BilgiTipi.EPosta, Icerik = "Linea.Duigan@Fivechat.com", KisiId = kisi4.UUID });
            modelBuilder.Entity<IletisimBilgisi>().HasData(new IletisimBilgisi { UUID = Guid.NewGuid(), BilgiTipi = Enums.BilgiTipi.EPosta, Icerik = "Lock.Molyneaux@Feedfish.com", KisiId = kisi5.UUID });

            modelBuilder.Entity<IletisimBilgisi>().HasData(new IletisimBilgisi { UUID = Guid.NewGuid(), BilgiTipi = Enums.BilgiTipi.Telefon, Icerik = "584-128-3271", KisiId = kisi1.UUID });
            modelBuilder.Entity<IletisimBilgisi>().HasData(new IletisimBilgisi { UUID = Guid.NewGuid(), BilgiTipi = Enums.BilgiTipi.Telefon, Icerik = "410-174-8583", KisiId = kisi3.UUID });
            modelBuilder.Entity<IletisimBilgisi>().HasData(new IletisimBilgisi { UUID = Guid.NewGuid(), BilgiTipi = Enums.BilgiTipi.Telefon, Icerik = "744-961-7350", KisiId = kisi5.UUID });

            modelBuilder.Entity<IletisimBilgisi>().HasData(new IletisimBilgisi { UUID = Guid.NewGuid(), BilgiTipi = Enums.BilgiTipi.Konum, Icerik = "İstanbul", KisiId = kisi1.UUID });
            modelBuilder.Entity<IletisimBilgisi>().HasData(new IletisimBilgisi { UUID = Guid.NewGuid(), BilgiTipi = Enums.BilgiTipi.Konum, Icerik = "İstanbul", KisiId = kisi2.UUID });
            modelBuilder.Entity<IletisimBilgisi>().HasData(new IletisimBilgisi { UUID = Guid.NewGuid(), BilgiTipi = Enums.BilgiTipi.Konum, Icerik = "İzmir", KisiId = kisi3.UUID });
            modelBuilder.Entity<IletisimBilgisi>().HasData(new IletisimBilgisi { UUID = Guid.NewGuid(), BilgiTipi = Enums.BilgiTipi.Konum, Icerik = "İstanbul", KisiId = kisi4.UUID });
            modelBuilder.Entity<IletisimBilgisi>().HasData(new IletisimBilgisi { UUID = Guid.NewGuid(), BilgiTipi = Enums.BilgiTipi.Konum, Icerik = "İstanbul", KisiId = kisi5.UUID });
        }

        public DbSet<Kisi> Kisiler { get; set; }



    }


}
