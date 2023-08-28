using Microsoft.EntityFrameworkCore;
using RegistrationApp.Models;

namespace RegistrationApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users{ get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries{ get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.City)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Country)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CountryId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<City>()
                .HasOne(c => c.Country)
                .WithMany(cntr => cntr.Cities)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.SetNull);

            Country ukraine = new Country() { Id = 1, Name = "Ukraine" };
            Country poland = new Country() { Id = 2, Name = "Poland" };
            Country germany = new Country() { Id = 3, Name = "Germany" };
            Country france = new Country() { Id = 4, Name = "France" };
            Country italy = new Country() { Id = 5, Name = "Italy" };

            City kyiv = new City() { Id = 1, Name = "Kyiv", CountryId = ukraine.Id };
            City rivne = new City() { Id = 2, Name = "Rivne", CountryId = ukraine.Id };
            City kharkiv = new City() { Id = 3, Name = "Kharkiv", CountryId = ukraine.Id };
            City dnipro = new City() { Id = 4, Name = "Dnipro", CountryId = ukraine.Id };
            City lviv = new City() { Id = 5, Name = "Lviv", CountryId = ukraine.Id };

            City warszaw = new City() { Id = 6, Name = "Warszaw", CountryId = poland.Id };
            City gdansk = new City() { Id = 7, Name = "Gdansk", CountryId = poland.Id };
            City krakow = new City() { Id = 8, Name = "Krakow", CountryId = poland.Id };
            City poznan = new City() { Id = 9, Name = "Poznan", CountryId = poland.Id };
            City lublin = new City() { Id = 10, Name = "Lublin", CountryId = poland.Id };

            City berlin = new City() { Id = 11, Name = "Berlin", CountryId = germany.Id };
            City hamburg = new City() { Id = 12, Name = "Hamburg", CountryId = germany.Id };
            City munich = new City() { Id = 13, Name = "Munich", CountryId = germany.Id };
            City cologne = new City() { Id = 14, Name = "Cologne", CountryId = germany.Id };
            City stuttgart = new City() { Id = 15, Name = "Stuttgart", CountryId = germany.Id };

            City paris = new City() { Id = 16, Name = "Paris", CountryId = france.Id };
            City marseille = new City() { Id = 17, Name = "Marseille", CountryId = france.Id };
            City lyon = new City() { Id = 18, Name = "Lyon", CountryId = france.Id };
            City toulouse = new City() { Id = 19, Name = "Toulouse", CountryId = france.Id };
            City bordeaux = new City() { Id = 20, Name = "Bordeaux", CountryId = france.Id };

            City rome = new City() { Id = 21, Name = "Rome", CountryId = italy.Id };
            City milan = new City() { Id = 22, Name = "Milan", CountryId = italy.Id };
            City naples = new City() { Id = 23, Name = "Naples", CountryId = italy.Id };
            City turin = new City() { Id = 24, Name = "Turin", CountryId = italy.Id };
            City palermo = new City() { Id = 25, Name = "Palermo", CountryId = italy.Id };

            User user1 = new User()
            {
                Id = 1,
                Name = "Elizabeth",
                Age = 18,
                Email = "elizabeth@gmail.com",
                PhoneNumber = "+380986815309",
                Password = "elizabethpassword123weq",
                CountryId = ukraine.Id,
                CityId = kyiv.Id           
            };

            User user2 = new User() 
            {
                Id = 2,
                Name = "flower",
                Age = 32,
                Email = "flower@gmail.com",
                PhoneNumber = "+380967815495",
                Password = "flower678jhnj",
                CountryId = ukraine.Id,
                CityId = rivne.Id
               
            };

            User user3 = new User() 
            {
                Id = 3,
                Name = "grimace_shake",
                Age = 25,
                Email = "grimace_shake@gmail.com",
                PhoneNumber = "+380762190863",
                Password = "grimaceshake89765as",
                CountryId = ukraine.Id,
                CityId = kharkiv.Id            
            };

            User user4 = new User()
            {
                Id = 4,
                Name = "jumpstyle",
                Age = 43,
                Email = "jumpstyle@gmail.com",
                PhoneNumber = "+380567812094",
                Password = "jumpstyle009977hj",
                CountryId = ukraine.Id,
                CityId = dnipro.Id
            };

            User user5 = new User()
            {
                Id = 5,
                Name = "keshakaef",
                Age = 21,
                Email = "keshakaef@gmail.com",
                PhoneNumber = "+380876541098",
                Password = "keshakaef009977hj",
                CountryId = ukraine.Id,
                CityId = lviv.Id
            };

            User user6 = new User()
            {
                Id = 6,
                Name = "LiveWallpaper",
                Age = 31,
                Email = "LiveWallpaper@gmail.com",
                PhoneNumber = "+480908765621",
                Password = "LiveWallpaperqweasd123",
                CountryId = poland.Id,
                CityId = gdansk.Id
            };

            User user7 = new User()
            {
                Id = 7,
                Name = "Payton",
                Age = 25,
                Email = "Payton@gmail.com",
                PhoneNumber = "+480890017682",
                Password = "Paytonolewqwe",
                CountryId = poland.Id,
                CityId = lublin.Id
            };

            User user8 = new User()
            {
                Id = 8,
                Name = "One_Piece",
                Age = 19,
                Email = "onepiece@gmail.com",
                PhoneNumber = "+480780981123",
                Password = "onepiece1234fcd",
                CountryId = poland.Id,
                CityId = krakow.Id
            };

            User user9 = new User()
            {
                Id = 9,
                Name = "Isrhaul",
                Age = 29,
                Email = "isrhaul@gmail.com",
                PhoneNumber = "+480776671205",
                Password = "isrhaulqwefgvvv223",
                CountryId = poland.Id,
                CityId = warszaw.Id
            };

            User user10 = new User()
            {
                Id = 10,
                Name = "username_ideas",
                Age = 36,
                Email = "username_ideas@gmail.com",
                PhoneNumber = "+480786548821",
                Password = "username_ideas567811",
                CountryId = poland.Id,
                CityId = poznan.Id
            };

            User user11 = new User()
            {
                Id = 11,
                Name = "Yum_Yum",
                Age = 24,
                Email = "Yum_Yum@gmail.com",
                PhoneNumber = "+580872317850",
                Password = "Yum_Yum87ygh9",
                CountryId = germany.Id,
                CityId = berlin.Id
            };

            User user12 = new User()
            {
                Id = 12,
                Name = "tocaboca",
                Age = 33,
                Email = "tocaboca@gmail.com",
                PhoneNumber = "+580907613411",
                Password = "tocaboca23edfgy54",
                CountryId = germany.Id,
                CityId = hamburg.Id
            };

            User user13 = new User()
            {
                Id = 13,
                Name = "roblox23",
                Age = 38,
                Email = "roblox23@gmail.com",
                PhoneNumber = "+580896641289",
                Password = "roblox23dcaw231",
                CountryId = germany.Id,
                CityId = munich.Id
            };

            User user14 = new User()
            {
                Id = 14,
                Name = "efilonova",
                Age = 20,
                Email = "efilonova@gmail.com",
                PhoneNumber = "+580987654409",
                Password = "efilonovaeqwdase23",
                CountryId = germany.Id,
                CityId = cologne.Id
            };

            User user15 = new User()
            {
                Id = 15,
                Name = "widgetable",
                Age = 28,
                Email = "widgetable@gmail.com",
                PhoneNumber = "+580987886520",
                Password = "widgetable312ed213edsa",
                CountryId = germany.Id,
                CityId = stuttgart.Id
            };

            User user16 = new User()
            {
                Id = 16,
                Name = "queencard",
                Age = 22,
                Email = "queencard@gmail.com",
                PhoneNumber = "+180128751677",
                Password = "queencard67uyhju182",
                CountryId = france.Id,
                CityId = paris.Id
            };

            User user17 = new User()
            {
                Id = 17,
                Name = "AfterDark",
                Age = 26,
                Email = "AfterDark@gmail.com",
                PhoneNumber = "+180886789012",
                Password = "AfterDark213edqaw32",
                CountryId = france.Id,
                CityId = marseille.Id
            };

            User user18 = new User()
            {
                Id = 18,
                Name = "stray_kids",
                Age = 31,
                Email = "stray_kids@gmail.com",
                PhoneNumber = "+180987655567",
                Password = "stray_kids123edq2",
                CountryId = france.Id,
                CityId = lyon.Id
            };

            User user19 = new User()
            {
                Id = 19,
                Name = "DemonSlayer",
                Age = 19,
                Email = "DemonSlayer@gmail.com",
                PhoneNumber = "+180986782162",
                Password = "DemonSlayer23edaww31",
                CountryId = france.Id,
                CityId = toulouse.Id
            };

            User user20 = new User()
            {
                Id = 20,
                Name = "CapCut56",
                Age = 23,
                Email = "CapCut56@gmail.com",
                PhoneNumber = "+180237872134",
                Password = "CapCut56312eqwdw",
                CountryId = france.Id,
                CityId = bordeaux.Id
            };

            User user21 = new User()
            {
                Id = 21,
                Name = "xbadmix",
                Age = 29,
                Email = "xbadmix@gmail.com",
                PhoneNumber = "+280909876751",
                Password = "xbadmix34rfwess3",
                CountryId = italy.Id,
                CityId = rome.Id
            };

            User user22 = new User()
            {
                Id = 22,
                Name = "Vendetta",
                Age = 26,
                Email = "vendetta@gmail.com",
                PhoneNumber = "+280118978905",
                Password = "vendetta213dghhht",
                CountryId = italy.Id,
                CityId = milan.Id
            };

            User user23 = new User()
            {
                Id = 23,
                Name = "new_jeans",
                Age = 21,
                Email = "new_jeans@gmail.com",
                PhoneNumber = "+280896547812",
                Password = "new_jeans32eqda23",
                CountryId = italy.Id,
                CityId = palermo.Id
            };

            User user24 = new User()
            {
                Id = 24,
                Name = "Blackpink",
                Age = 25,
                Email = "Blackpink@gmail.com",
                PhoneNumber = "+280897872134",
                Password = "Blackpink3eqdw34123",
                CountryId = italy.Id,
                CityId = turin.Id
            };

            User user25 = new User()
            {
                Id = 25,
                Name = "minecraft",
                Age = 23,
                Email = "minecraft@gmail.com",
                PhoneNumber = "+280900761127",
                Password = "minecraft23eda23",
                CountryId = italy.Id,
                CityId = naples.Id
            };

            modelBuilder.Entity<Country>().HasData(ukraine, poland, germany, france, italy);
            modelBuilder.Entity<City>().HasData(kyiv, rivne, kharkiv, dnipro,
                lviv, warszaw, gdansk, lublin, poznan, krakow,
                berlin, munich, stuttgart, cologne, hamburg,
                paris, bordeaux, toulouse, marseille, lyon,
                rome, milan, naples, turin, palermo);
            modelBuilder.Entity<User>().HasData(user1, user2, user3, user4, user5,
                user6, user7, user8, user9, user10,
                user11, user12, user13, user14, user15,
                user16, user17, user18, user19, user20,
                user21, user22, user23, user24, user25);
        }
    }
}
