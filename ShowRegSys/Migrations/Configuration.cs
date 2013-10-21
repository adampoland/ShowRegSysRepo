namespace ShowRegSys.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ShowRegSys.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ShowRegSys.DAL.ShowContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShowRegSys.DAL.ShowContext context)
        {

            var breeds = new List<Breed>
            {
                new Breed { Name = "Afghan Hound", Group = 10 },
                new Breed { Name = "Aidi", Group = 02 },
                new Breed { Name = "Airedle Terrier", Group = 03 },
                new Breed { Name = "Akita Inu", Group = 05 },
                new Breed { Name = "Alaskan Malamute", Group = 05 },
                new Breed { Name = "Alpine Dashsbracke", Group = 06 },
                new Breed { Name = "American Akita", Group = 05 },
                new Breed { Name = "American Foxhound", Group = 06 },
                new Breed { Name = "American Staffordshire Terrier", Group = 03 },
                new Breed { Name = "Australian Silky Terrier", Group = 02 },
                new Breed { Name = "Beagle", Group = 06 },
                new Breed { Name = "York Shire Terier", Group = 03 },
                new Breed { Name = "Dachshund", Group = 01 },
                new Breed { Name = "Pomeranian", Group = 05 },
            };

            breeds.ForEach(b => context.Breeds.AddOrUpdate(p => p.Name, b));
            context.SaveChanges();

            var users = new List<User>
            {
                new User { Name = "Adam Grabarek",
                    City = "Kwidzyn", Adress = "Rzemie�lnica 6" },
                new User { Name = "Adrianna Adamowicz",
                    City = "Kwidzyn", Adress = "Toru�ska 25" },
                new User { Name = "Aneta Kolenda",
                    City = "Warszawa", Adress = "Nowoursynowska 166"},
                new User { Name = "Zofia Tosiak",
                    City = "Bydgoszcz", Adress = "Pozna�ska 4" }
            };

            users.ForEach(u => context.Users.AddOrUpdate(n => n.Adress, u));
            context.SaveChanges();

            var organizer = new List<Organizer>
            {
                new Organizer { Name = "B�dzin", City = "B�dzin",
                    Address = "Ul. Rubna 1", Email = "biuro@zkwp.bedzin.pl",
                    Telephone = "32-263-70-05", 
                    BankAccount = "Alior Bank 83 2490 0005 0000 4500 6028 8749" },
                new Organizer { Name = "Bia�ystok", City = "Bia�ystok",
                    Address = "Ul. Jurowiecka 33", Email = "biuro@zkwp.bialystok.pl",
                    Telephone = "85-653 77 95",
                    BankAccount = "PKO BP S.A. I O/Bia�ystok 59 1020 1332 0000 1502 0025 9333" },
                new Organizer { Name = "Bielsko-Bia�a", City = "Bielsko-Bia�a",
                    Address = "Ul. Sowieskiego 132", Email = "zkwpbielsko@gmail.com",
                    Telephone = "33-812-63-89",
                    BankAccount = "Pekao S.A. O/Bielsko-Bia�a 34 1240 6449 1111 0010 5313 7101" },
                new Organizer { Name = "Bydgoszcz", City = "Bydgoszcz",
                    Address = "Ul. U�a�ska 4a", Email = "zkwpbydgoszcz@onet.pl",
                    Telephone = "52-328-49-07",
                    BankAccount = "PeKaO SA O/Bydgoszcz 38 1240 3493 1111 0000 4305 7832" },
                new Organizer { Name = "Bytom", City = "Bytom", 
                    Address = "Ul. Mickiewicza 13", Email = "zkwp_bytom@op.pl",
                    Telephone = "32-281-73-84",
                    BankAccount = "BZ Wroc�aw I O/Bytom 84 1090 2011 0000 0005 3200 0037" },
                new Organizer { Name = "Chojnice", City = "Chojnice",
                    Address = "Pl. Jagiello�ski 2", Email = "chojnice@zkwp.pl",
                    Telephone = "52-397-06",
                    BankAccount = "Bank Sp�dzielczy w Chojnicach 51 8146 0003 0000 0211 2000 0010" },
                new Organizer { Name = "Chorz�w", City = "Chorz�w",
                    Address = "Ul. Powsta�c�w 41", Email = "biuro@zkwp-chorzow.net",
                    Telephone = "32-241-08-30",
                    BankAccount = "ING BSK O/Chorz�w 74 1050 1243 1000 0010 0000 2764" },
                new Organizer { Name = "Cz�stochowa", City = "Cz�stochowa",
                    Address = "Ul. Sobieskiego 19a lok. 3", Email = "info@zkwp-czestochowa.org.pl",
                    Telephone = "34-324-46-13",
                    BankAccount = "Bank Millenium, 63 1160 2202 0000 0001 7562 5445" },
                new Organizer { Name = "Gdynia", City = "Gdynia",
                    Address = "Ul. Bohater�w Star�wki Warszawskiej 6", Email = "gdynia@zkwp.pl",
                    Telephone = "58-622-64-42",
                    BankAccount = "PKO SA I O/Gdynia 92 1240 1239 1111 0000 1642 8100" },
                new Organizer { Name = "Gorz�w Wlkp.", City = "Gorz�w Wlkp.",
                    Address = "Ul. Kosynier�w Gdy�skich 98", Email = "biuro@kynologia.gorzow.pl",
                    Telephone = "95-735-03-45",
                    BankAccount = "Polbank EFG 85 2340 0009 0610 2460 0000 0051" },
                new Organizer { Name = "Grudz�dz", City = "Grudz�dz",
                    Address = "Ul. Moniuszki 19", Email = "zkwp.grudz@wp.pl",
                    Telephone = "56-426-64-12",
                    BankAccount = "Bank BG� 81 2030 0045 1110 0000 0187 2590" },
                new Organizer { Name = "Inowroc�aw", City = "Inowroc�aw",
                    Address = "Ul. Dworcowa 25", Email = "zw_kyn_ino1@poczta.onet.pl",
                    Telephone = "52-566-24-42",
                    BankAccount = "BZ WBK SA O/I-w 26 1090 1069 0000 0000 0701 4199" },
                new Organizer { Name = "Jelenia G�ra", City = "Jelenia G�ra",
                    Address = "Ul. 1 Maja 67", Email = "jeleniagora@zkwp.pl",
                    Telephone = "75-752-57-15",
                    BankAccount = "PKO BP 88 1020 2124 0000 8602 0006 8585" },
                new Organizer { Name = "Kalisz", City = "Kalisz",
                    Address = "Al. Wojska Polskiego 10B", Email = "zk-kalicz@o2.pl",
                    Telephone = "62-757-43-15",
                    BankAccount = "WBK O/Kalisz 22 1090 1128 0000 0000 1201 5716" },
                new Organizer { Name = "Katowice", City = "Katowice",
                    Address = "Ul. Ko�ciuszki 42", Email = "info@zkwp.katowice.pl",
                    Telephone = "32-251-67-80",
                    BankAccount = "PKO BP II O/Katowice 05 1020 2313 0000 3802 0019 7871" },
                new Organizer { Name = "Kielce", City = "Kielce",
                    Address = "Ul. �l�ska 10", Email = "kielce@zkwp.pl",
                    Telephone = "41-368-74-68",
                    BankAccount = "ING BS 60 1050 1416 1000 0023 1575 9072" },
                new Organizer { Name = "Koszalin", City = "Koszalin",
                    Address = "Ul. Jana z Kolna 26/5", Email = "biuro@zkwp-koszalin.pl",
                    Telephone = "94-348-06-86", 
                    BankAccount = "PKO SA II O/Koszalin 95 1240 3653 1111 0000 4188 3468" },
                new Organizer { Name = "Krak�w", City = "Krak�w",
                    Address = "Ul. �ywiecka 36", Email = "biuro@zkwpkrakow.pl",
                    Telephone = "12-266-70-85",
                    BankAccount = "Bank Pekao SA 80 1240 4432 1111 0000 4722 3693" },
                new Organizer { Name = "Krosno", City = "Krosno",
                    Address = "Ul. Betleja 1a", Email = "rasowe@interia.pl",
                    Telephone = "13-436-85-74",
                    BankAccount = "PKO BP O/Krosno 19 1020 2964 0000 6502 0003 4587" },
                new Organizer { Name = "Legionowo", City = "Legionowo",
                    Address = "Ul. Jagiello�ska 20", Email = "biuro@zkwp-legionowo.pl",
                    Telephone = "22-784-27-66",
                    BankAccount = "ING BSK SA O/Legionowo 43 1050 1012 1000 0022 1151 3888" },
                new Organizer { Name = "Legnica", City = "Legnica",
                    Address = "Ul. Libana 10", Email = "legnica@zkwp.pl",
                    Telephone = "76-852-35-83",
                    BankAccount = "Kredyt Bank S.A. O/Legnica 83 1500 1504 1215 0000 4148 0000" },
                new Organizer { Name = "Leszno", City = "Leszno",
                    Address = "Ul. �rednia 9", Email = "zkwpleszno@gmail.com",
                    Telephone = "65-529-59-92",
                    BankAccount = "PKO SA O/Leszno 77 1240 1499 1111 0000 1881 9014" },
                new Organizer { Name = "Lublin", City = "Lublin",
                    Address = "Ul. Dolna Panny Marii 53", Email = "biuro@zk.lublin.pl",
                    Telephone = "81-532-75-50",
                    BankAccount = "PKO II O/Lublin 35 1020 3150 0000 3702 0002 8795" },
                new Organizer { Name = "��d�", City = "��d�",
                    Address = "Al. Ko�ciuszki 48", Email = "lodz@zkwp.pl",
                    Telephone = "42-637-62-62",
                    BankAccount = "PKO SA VI O/��d� 35 1240 3031 1111 0000 3426 6805" },
                new Organizer { Name = "Nowy S�cz", City = "Nowy S�cz",
                    Address = "Ul. Broniewskiego 26", Email = "wystawans@gmail.com",
                    Telephone = "18-442-02-37",
                    BankAccount = "PKO BP SA Nowy S�cz 43 1020 3453 0000 8602 0008 1281" },
                new Organizer { Name = "Nowy Targ", City = "Nowy Targ",
                    Address = "Ul. PArkowa 14", Email = "zkwpnt@wp.pl",
                    Telephone = "18-264-01-66",
                    BankAccount = "63 1240 5136 1111 0000 5221 5427" },
                new Organizer { Name = "Olsztyn", City = "Olsztyn",
                    Address = "Ul. Warmi�ska 4", Email = "olsztyn@zkwp.pl",
                    Telephone = "89-535-14-41",
                    BankAccount = "ING BSK O/Olsztyn 22 1050 1807 1000 0022 5330 5441" },
                new Organizer { Name = "Opole", City = "Opole",
                    Address = "Ul. 1 Maja 92", Email = "zkwpopole@zkwp-opole.pl",
                    Telephone = "7-453-72-86",
                    BankAccount = "Citi Handlowy S.A. 75 1030 0019 0109 8530 0037 6685" },
                new Organizer { Name = "P�ock", City = "P�ock",
                    Address = "Ul. Jasienna 10", Email = "biuro@zkwpplock.pl",
                    Telephone = "24-263-68-38",
                    BankAccount = "LUKAS Bank 04 1940 1076 3087 8639 0000 0000" },
                new Organizer { Name = "Pozna�", City = "Pozna�",
                    Address = "Ul. Piwoniowa 16", Email = "poznan@zkwp.pl",
                    Telephone = "61-852-27-84", 
                    BankAccount = "BZ WBK SA III O/P-� 49 1090 1359 0000 0000 3501 8426" },
                new Organizer { Name = "Przemy�l", City = "Przemy�l",
                    Address = "Ul. Lwowska 71", Email = "zkwpprzemysl@op.pl",
                    Telephone = "16-678-85-82",
                    BankAccount = "KB S.A. O/Przemy�l 74 1500 1634 1216 3005 1386 0000" },
                new Organizer { Name = "Racib�rz", City = "Racib�rz",
                    Address = "Ul. Ks. Londzina 49", Email = "zkwp-raciborz@world.pl",
                    Telephone = "32-415-59-44",
                    BankAccount = "ING BSK O/Racib�rz 62 1050 1328 1000 0022 4267 4410" },
                new Organizer { Name = "Radom", City = "Radom",
                    Address = "Ul. Wernera 29/31", Email = "zkwp@home.pl",
                    Telephone = "48-363-16-70",
                    BankAccount = "BS O/Radom 77 9147 0009 0000 0853 2000 0001" },
                new Organizer { Name = "Rybnik", City = "Rybnik",
                    Address = "Ul. Jankowicka 3", Email = "zk-rybnik@wp.pl",
                    Telephone = "32-423-58-52",
                    BankAccount = "Kredyt Bank SA I/Rybnik 60 1500 1214 1212 1001 7988 0000" },
                new Organizer { Name = "Rzesz�w", City = "Rzesz�w",
                    Address = "ul. �wirki i Wigury 8", Email = "biuro@zkwp.rzeszow.pl",
                    Telephone = "17-854-17-40",
                    BankAccount = "PKO BP SA 11 1020 4391 0000 6302 0079 8694" },
                new Organizer { Name = "S�upsk", City = "S�upsk", 
                    Address = "Ul. Lutos�awskiego 33", Email = "info@zkwp.eslupsk.pl",
                    Telephone = "59-841-47-84",
                    BankAccount = "49 1020 4649 0000 7702 0065 8914" },
                new Organizer { Name = "Sopot", City = "Sopot",
                    Address = "Al. Niepodleg�o�ci 825", Email = "sopot@zkwp.pl",
                    Telephone = "58-551-33-69",
                    BankAccount = "ING BSK SA 71 1050 1764 1000 0091 3316 5309" },
                new Organizer { Name = "Szczecin", City = "Szczecin",
                    Address = "Al. Papie�a Jana Paw�a II nr 44", Email = "szczecin@zkwp.pl",
                    Telephone = "91-434-65-09",
                    BankAccount = "PKO BP SA II O/Szczecin 58 1020 4795 0000 9602 0155 3585" },
                new Organizer { Name = "Toru�", City = "Toru�",
                    Address = "Ul. Sk�odowskiej-cuire 84", Email = "torun@zkwp.pl",
                    Telephone = "56-622-30-20",
                    BankAccount = "Pekao SA I O/Toru� 05 1240 4009 1111 0000 4490 8816" },
                new Organizer { Name = "Wa�brzych", City = "Wa�brzych",
                    Address = "Ul. P�uga 7", Email = "zkwp.walbrzych@gmail.com",
                    Telephone = "74-842-39-96",
                    BankAccount = "BPH SA O/Wa�brzych 21 1060 0076 0000 3200 0125 4537" },
                new Organizer { Name = "Warszawa", City = "Warszawa",
                    Address = "Ul. Lubelska 5/7", Email = "warszawa@zkwp.pl",
                    Telephone = "22-618-25-70",
                    BankAccount = "ING BSK 74 1050 1025 1000 0023 0027 0143" },
                new Organizer { Name = "W�oc�awek", City = "W�oc�awek",
                    Address = "Ul. Starod�bska 26", Email = "wloclawek@zkwp.pl",
                    Telephone = "54-232-64-52",
                    BankAccount = "PKO BP SA O/W�oc�awek 03 1020 5170 0000 1302 0061 5153" },
                new Organizer { Name = "Wroc�aw", City = "Wroc�aw",
                    Address = "Ul. Leszczy�skiego 7", Email = "biuro@zkwp.wroclaw.pl",
                    Telephone = "71-343-25-22",
                    BankAccount = "PKO BP IV O/Wroc�aw 34 1020 5242 0000 2602 0019 8408" },
                new Organizer { Name = "Zabrze", City = "Zabrze",
                    Address = "Ul. Wolno�ci 360", Email = "zabrze@zkwp.pl",
                    Telephone = "32-271-42-80",
                    BankAccount = "Volkswagen Bank Direct 92 2130 0004 2001 0409 0411 0001" },
                new Organizer { Name = "Zakopane", City = "Zakopane",
                    Address = "Ul. Kasprusie 35a", Email = "zkwp-zakopane@o2.pl",
                    Telephone = "18-201-23-28",
                    BankAccount = "PBS 08 8821 0009 0000 0000 0345 0001" },
                new Organizer { Name = "Zielona G�ra", City = "Zielona G�ra",
                    Address = "Ul. D�bowskiego 35", Email = "info@zkwp.zgora.pl",
                    Telephone = "68-327-18-55",
                    BankAccount = "PKO II O/Zielona G�ra 19 1020 5402 0000 0802 0142 2898" }                    
            };

            organizer.ForEach(o => context.Organizers.AddOrUpdate(a => a.Name, o));
            context.SaveChanges();

            var rank = new List<Rank>
            {
                new Rank { Name = "National" },
                new Rank { Name = "International" }
            };

            rank.ForEach(r => context.Ranks.AddOrUpdate(a => a.Name, r));
            context.SaveChanges();

            var color = new List<Color>
            {
                new Color { NameEN = "Blue-steel", NamePL = "Stalowo-z�oty" },
                new Color { NameEN = "Black", NamePL = "Czarny"}
            };
            color.ForEach(c => context.Colors.AddOrUpdate(a => a.NameEN, c));
            context.SaveChanges();

            var gender = new List<Gender>
            {
                new Gender { NameEN = "Male", NamePL = "Pies" },
                new Gender { NameEN = "Female", NamePL = "Suka" }
            };
            gender.ForEach(g => context.Genders.AddOrUpdate(a => a.NameEN, g));
            context.SaveChanges();
        }
    }
}
