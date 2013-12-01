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
            var classes = new List<Class>
            {
                new Class { NamePL = "Baby", NameEN = "Baby" },
                new Class { NamePL = "Szczeni�t", NameEN = "Puppy" },
                new Class { NamePL = "M�odzie�y", NameEN = "Junior" },
                new Class { NamePL = "Po�rednia", NameEN = "Intermediate" },
                new Class { NamePL = "Otwarta", NameEN = "Open" },
                new Class { NamePL = "U�ytkowa", NameEN = "Working" },
                new Class { NamePL = "Champion�w", NameEN = "Champion" },
                new Class { NamePL = "Weteran�w", NameEN = "Veteran" }
            };
            classes.ForEach(p => context.Classes.AddOrUpdate(a => a.NamePL, p));
            context.SaveChanges();

            var pkrs = new List<Pkr>
            {
                new Pkr { Name = "PKR.I", Number = 1 },
                new Pkr { Name = "PKR.II", Number = 2 },
                new Pkr { Name = "PKR.III", Number = 3 },
                new Pkr { Name = "PKR.IV", Number = 4 },
                new Pkr { Name = "PKR.V", Number = 5 },
                new Pkr { Name = "PKR.VI", Number = 6 },
                new Pkr { Name = "PKR.VII", Number = 7 },
                new Pkr { Name = "PKR.VIII", Number = 8 },
                new Pkr { Name = "PKR.IX", Number = 9 },
                new Pkr { Name = "PKR.X", Number = 10 }
            };
            pkrs.ForEach(p => context.Pkrs.AddOrUpdate(a => a.Name, p));
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
                new Color { NameEN = "Black", NamePL = "Czarny" },
                new Color { NameEN = "White", NamePL = "Bia�y"  },
                new Color { NameEN = "Smoke", NamePL = "Podpalany" }
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


            var breeds = new List<Breed>
            {
                new Breed { Name = "Australian CattleDog", PkrID = 1},
                new Breed { Name = "Bearded Collie", PkrID = 1},
                new Breed { Name = "Bergamasco", PkrID = 1},
                new Breed { Name = "Bia�y owczarek szwajcarski", PkrID = 1},
                new Breed { Name = "Borded Collie", PkrID = 1},
                new Breed { Name = "Bouvier des Ardennes", PkrID = 1},
                new Breed { Name = "Bouvier des Flandes", PkrID = 1},
                new Breed { Name = "Cao de Serra de Aires", PkrID = 1},
                new Breed { Name = "Ceskoslovensky Vlcak", PkrID = 1},
                new Breed { Name = "Komondor", PkrID = 1},
                new Breed { Name = "Kuvaz", PkrID = 1},
                new Breed { Name = "Maremmano-Abruzzese", PkrID = 1},
                new Breed { Name = "Mudi", PkrID = 1},
                new Breed { Name = "Owczarek australijski - Kelpie", PkrID = 1},
                new Breed { Name = "Owczarek australijski(typ ameryka�ski)", PkrID = 1},
                new Breed { Name = "Owczarek belgijski - Groenendael", PkrID = 1},
                new Breed { Name = "Owczarek belgijski - Laekenois", PkrID = 1},
                new Breed { Name = "Owczarek belgijski - Malinois", PkrID = 1},
                new Breed { Name = "Owczarek belgijski - Tervurern", PkrID = 1},
                new Breed { Name = "Owczarek chorwacki", PkrID = 1},
                new Breed { Name = "Owczarek francuski Beauceron", PkrID = 1},
                new Breed { Name = "Owczare kfrancuski Briard", PkrID = 1},
                new Breed { Name = "Owczarek holenderski d�ugow�osy", PkrID = 1},
                new Breed { Name = "Owczarek holenderski kr�tkow�osy", PkrID = 1},
                new Breed { Name = "Owczarek holenderski szkorstkow�osy", PkrID = 1},
                new Breed { Name = "Owczarek katalo�ski d�gow�osy", PkrID = 1},
                new Breed { Name = "Owczarek katalo�ski g�adkow�osy", PkrID = 1},
                new Breed { Name = "Owczarek niemiecki d�ugow�osy", PkrID = 1},
                new Breed { Name = "Owczarek niemiecki kr�tkow�osy", PkrID = 1},
                new Breed { Name = "Owczarek pikardyjski", PkrID = 1},
                new Breed { Name = "Owczarek pierenejski ( a face rase)", PkrID = 1},
                new Breed { Name = "Owczarek pirenejski ( a poil long)", PkrID = 1},
                new Breed { Name = "Owczarek podhala�ski", PkrID = 1},
                new Breed { Name = "Owczarek po�udnioworosyjski Ju�ak", PkrID = 1},
                new Breed { Name = "Owczarek staroangielski Bobtail", PkrID = 1},
                new Breed { Name = "Owczarek szetlandzki", PkrID = 1},
                new Breed { Name = "Owczarek szkocki d�ugow�osy", PkrID = 1},
                new Breed { Name = "Owczarek szkocki kr�tkow�osy", PkrID = 1},
                new Breed { Name = "Owczarek z Majorki d�ugow�osy", PkrID = 1},
                new Breed { Name = "Owczarek z Majorki kr�tkow�osy", PkrID = 1},
                new Breed { Name = "Polski owczarek nizinny", PkrID = 1},
                new Breed { Name = "Puli", PkrID = 1},
                new Breed { Name = "Pumi", PkrID = 1},
                new Breed { Name = "Saarlooswolfhund", PkrID = 1},
                new Breed { Name = "Schapendoes", PkrID = 1},
                new Breed { Name = "Slovensky Cuvac", PkrID = 1},
                new Breed { Name = "Welsh Corgi Cordigan", PkrID = 1},
                new Breed { Name = "Welsh Corgi Pembroke", PkrID = 1},

                //---------------------------------
                //--------------GRUPA 2------------
                //---------------------------------
                new Breed { Name = "Aidi", PkrID = 2},
                new Breed { Name = "Anatolian", PkrID = 2},
                new Breed { Name = "Appenzeller", PkrID = 2},
                new Breed { Name = "Bernardyn d�ugow�osy", PkrID = 2},
                new Breed { Name = "Bernardyn kr�tkow�osy", PkrID = 2},
                new Breed { Name = "Berne�ski pies pasterski", PkrID = 2},
                new Breed { Name = "Bokser pr�gowany", PkrID = 2},
                new Breed { Name = "Bokser ��ty", PkrID = 2},
                new Breed { Name = "Broholmer", PkrID = 2},
                new Breed { Name = "Buldog angielski", PkrID = 2},
                new Breed { Name = "Bullmastiff", PkrID = 2},
                new Breed { Name = "Cane Corso Italiano", PkrID = 2},
                new Breed { Name = "Cao de Serra da Estrela pelo comprido", PkrID = 2},
                new Breed { Name = "Cao de Serra da Estrela pelo lizo", PkrID = 2},
                new Breed { Name = "Cao Fila de Sao Miguel", PkrID = 2},
                new Breed { Name = "Czarny terier rosyjski", PkrID = 2},
                new Breed { Name = "Doberman", PkrID = 2},
                new Breed { Name = "Dog argenty�ski", PkrID = 2},
                new Breed { Name = "Dog kanaryjski", PkrID = 2},
                new Breed { Name = "Dog niemiecki arlekin", PkrID = 2},
                new Breed { Name = "Dog niemiecki b��kitny", PkrID = 2},
                new Breed { Name = "Dog niemiecki czarny", PkrID = 2},
                new Breed { Name = "Dog niemiecki pr�gowany", PkrID = 2},
                new Breed { Name = "Dog niemiecki ��ty", PkrID = 2},
                new Breed { Name = "Dog z Majorki", PkrID = 2},
                new Breed { Name = "Dogue de Bordeaux", PkrID = 2},
                new Breed { Name = "Du�y szwajcarski pies pasterski", PkrID = 2},
                new Breed { Name = "Entlebucher", PkrID = 2},
                new Breed { Name = "Fila Brasileiro", PkrID = 2},
                new Breed { Name = "Hollandse Smoushond", PkrID = 2},
                new Breed { Name = "Hovawart", PkrID = 2},
                new Breed { Name = "Kraski Ovcar", PkrID = 2},
                new Breed { Name = "Landseer ( typ kontynentalno=europejski", PkrID = 2},
                new Breed { Name = "Leonberger", PkrID = 2},
                new Breed { Name = "Mastif angielski", PkrID = 2},
                new Breed { Name = "Mastif hiszpa�ski", PkrID = 2},
                new Breed { Name = "Mastif neapolita�ski", PkrID = 2},
                new Breed { Name = "Mastif pirenejski", PkrID = 2},
                new Breed { Name = "Mastif tybeta�ski", PkrID = 2},
                new Breed { Name = "Nowofundland", PkrID = 2},
                new Breed { Name = "Owczarek kaukaski", PkrID = 2},
                new Breed { Name = "Owczarek �rodkowoazjatycki", PkrID = 2},
                new Breed { Name = "Pinczer austriacki", PkrID = 2},
                new Breed { Name = "Pinczer ma�pi", PkrID = 2},
                new Breed { Name = "Pinczer miniaturowy", PkrID = 2},
                new Breed { Name = "Pinczer �redni", PkrID = 2},
                new Breed { Name = "Pirenejski pies g�rski", PkrID = 2},
                new Breed { Name = "Rafeiro do Alentejo", PkrID = 2},
                new Breed { Name = "Rottweiler", PkrID = 2},
                new Breed { Name = "Sarplaninac", PkrID = 2},
                new Breed { Name = "Shar Pei", PkrID = 2},
                new Breed { Name = "Sznaucer miniaturowy bia�y", PkrID = 2},
                new Breed { Name = "Sznaucer miniaturowy czarno-srebrny", PkrID = 2},
                new Breed { Name = "Sznaucer miniaturowy czarny", PkrID = 2},
                new Breed { Name = "Sznaucer miniaturowy pieprz i s�l", PkrID = 2},
                new Breed { Name = "Sznaucer olbrzym czarny", PkrID = 2},
                new Breed { Name = "Sznaucer olbrzym pieprz i s�l", PkrID = 2},
                new Breed { Name = "Sznaucer �redni czarny", PkrID = 2},
                new Breed { Name = "Sznaucer �redni pieprz i s�l", PkrID = 2},
                new Breed { Name = "Tosa", PkrID = 2},


                //---------------------------------
                //--------------GRUPA 3------------
                //---------------------------------
                new Breed { Name = "Airedale Terrier", PkrID = 3},
                new Breed { Name = "American Staffordshire Terrier", PkrID = 3},
                new Breed { Name = "Australian Silky Terrier", PkrID = 3},
                new Breed { Name = "Bedlington Terrier", PkrID = 3},
                new Breed { Name = "Bulterier", PkrID = 3},
                new Breed { Name = "Bulterier miniaturowy", PkrID = 3},
                new Breed { Name = "Cairn Terrier", PkrID = 3},
                new Breed { Name = "Dandie Dinmont Terrier", PkrID = 3},
                new Breed { Name = "English Toy Terrier", PkrID = 3},
                new Breed { Name = "Foksterier kr�tkow�osy", PkrID = 3},
                new Breed { Name = "Foksterier szorstkow�osy", PkrID = 3},
                new Breed { Name = "Irish Glen of Imaal Terrier", PkrID = 3},
                new Breed { Name = "Irish Soft Coated Wheaten Terrier", PkrID = 3},
                new Breed { Name = "Jack Russell Terrier", PkrID = 3},
                new Breed { Name = "Kerry Blue Terrier", PkrID = 3},
                new Breed { Name = "Lakeland Terrier", PkrID = 3},
                new Breed { Name = "Manchester Terrier", PkrID = 3},
                new Breed { Name = "Niemiecki terier my�liwski", PkrID = 3},
                new Breed { Name = "Nihon Teria", PkrID = 3},
                new Breed { Name = "Norfolk Terrier", PkrID = 3},
                new Breed { Name = "Norwich Terrier", PkrID = 3},
                new Breed { Name = "Parson Russell Terrier", PkrID = 3},
                new Breed { Name = "Sealyham Terrier", PkrID = 3},
                new Breed { Name = "Skye Terrier", PkrID = 3},
                new Breed { Name = "Staffordshire Bull Terrier", PkrID = 3},
                new Breed { Name = "Terier australijski", PkrID = 3},
                new Breed { Name = "Terier brazylijski", PkrID = 3},
                new Breed { Name = "Terier czeski", PkrID = 3},
                new Breed { Name = "Terier irlandzki", PkrID = 3},
                new Breed { Name = "Terier szkocki", PkrID = 3},
                new Breed { Name = "Terier walijski", PkrID = 3},
                new Breed { Name = "West Highland White Terrier", PkrID = 3},
                new Breed { Name = "Yorkshire Terrier", PkrID = 3},

                //---------------------------------
                //--------------GRUPA 4------------
                //---------------------------------
                new Breed { Name = "Jamnik kr�tkow�osy standardowy", PkrID = 4},
                new Breed { Name = "Jamnik d�ugow�osy standardowy", PkrID = 4},
                new Breed { Name = "Jamnik szorstkow�osy standardowy", PkrID = 4},
                new Breed { Name = "Jamnik kr�tkow�osy miniaturowy", PkrID = 4},
                new Breed { Name = "Jamnik d�ugow�osy miniaturowy", PkrID = 4},
                new Breed { Name = "Jamnik szorstkow�osy miniaturowy", PkrID = 4},
                new Breed { Name = "Jamnik kr�tkow�osy kr�liczy", PkrID = 4},
                new Breed { Name = "Jamnik d�ugow�osy kr�liczy", PkrID = 4},
                new Breed { Name = "Jamnik szorstkow�osy kr�liczy", PkrID = 4},

                //---------------------------------
                //--------------GRUPA 5------------
                //---------------------------------
                new Breed { Name = "Akita", PkrID = 5},
                new Breed { Name = "Akia ameryka�ska", PkrID = 5},
                new Breed { Name = "Alaskan Malamute", PkrID = 5},
                new Breed { Name = "Basenji", PkrID = 5},
                new Breed { Name = "Canaan Dog", PkrID = 5},
                new Breed { Name = "Chow Chow", PkrID = 5},
                new Breed { Name = "Cirenco dell'Etna", PkrID = 5},
                new Breed { Name = "Elkhund czarny", PkrID = 5},
                new Breed { Name = "Elkhund szary", PkrID = 5},
                new Breed { Name = "Eurasier", PkrID = 5},
                new Breed { Name = "Hokkaido", PkrID = 5},
                new Breed { Name = "Islandzki szpic pasterski", PkrID = 5},
                new Breed { Name = "Jamthund", PkrID = 5},
                new Breed { Name = "Kai", PkrID = 5},
                new Breed { Name = "Karelski pies na nied�wiedzie", PkrID = 5},
                new Breed { Name = "Kishu", PkrID = 5},
                new Breed { Name = "Korea Jindo Dog", PkrID = 5},
                new Breed { Name = "Lapinporokoira", PkrID = 5},
                new Breed { Name = "�ajka rosyjsko-europejska", PkrID = 5},
                new Breed { Name = "�ajka wschodniosyberyjska", PkrID = 5},
                new Breed { Name = "�ajka zachodniosyberyjska", PkrID = 5},
                new Breed { Name = "Nagi pies meksyka�ski miniaturowy", PkrID = 5},
                new Breed { Name = "Nagi pies meksyka�ski standard", PkrID = 5},
                new Breed { Name = "Nagi pies meksyka�ski �redni", PkrID = 5},
                new Breed { Name = "Nagi pies peruwia�ski du�y", PkrID = 5},
                new Breed { Name = "Nagi pies peruwia�ski miniaturowy", PkrID = 5},
                new Breed { Name = "Nagi pies peruwia�ski �redni", PkrID = 5},
                new Breed { Name = "Norrbottenspets", PkrID = 5},
                new Breed { Name = "Norsk Buthund", PkrID = 5},
                new Breed { Name = "Norsk Lundehund", PkrID = 5},
                new Breed { Name = "Pies Faraona", PkrID = 5},
                new Breed { Name = "Pies grenlandzki", PkrID = 5},
                new Breed { Name = "Podenco kanaryjski", PkrID = 5},
                new Breed { Name = "Podenco z Ibizy kr�tkow�osy", PkrID = 5},
                new Breed { Name = "Podenco z Ibizy szorstkow�osy", PkrID = 5},
                new Breed { Name = "Podengo portugalski szorstkow�osy du�y", PkrID = 5},
                new Breed { Name = "Podengo portugalski szorstkow�osy �redni", PkrID = 5},
                new Breed { Name = "Podengo protugalski szorstkow�osy miniaturowy", PkrID = 5},
                new Breed { Name = "Podengo postugalski kr�tkow�osy du�y", PkrID = 5},
                new Breed { Name = "Podengo portugalski kr�tkow�osy �redni", PkrID = 5},
                new Breed { Name = "Podengo portugalski kr�tkow�osy miniaturowy", PkrID = 5},
                new Breed { Name = "Samoyed", PkrID = 5},
                new Breed { Name = "Shiba", PkrID = 5},
                new Breed { Name = "Shikoku", PkrID = 5},
                new Breed { Name = "Siberian Husky", PkrID = 5},
                new Breed { Name = "Suomenlapinkoira", PkrID = 5},
                new Breed { Name = "Svensk Lapphund", PkrID = 5},
                new Breed { Name = "Szpic du�y bia�y", PkrID = 5},
                new Breed { Name = "Szpic du�y kolorowy", PkrID = 5},
                new Breed { Name = "Szpic fi�ski", PkrID = 5},
                new Breed { Name = "Szpic japo�ski", PkrID = 5},
                new Breed { Name = "Szpic ma�y bia�y", PkrID = 5},
                new Breed { Name = "Szpic ma�y kolorowy klasyczny", PkrID = 5},
                new Breed { Name = "Szpic ma�y kolorowy wsp�lczesny", PkrID = 5},
                new Breed { Name = "Szpic miniaturowy", PkrID = 5},
                new Breed { Name = "Szpic �redni bia�y", PkrID = 5},
                new Breed { Name = "Szpic �redni klasyczny", PkrID = 5},
                new Breed { Name = "Szpic �rednio kolorowy wsp�czesny", PkrID = 5},
                new Breed { Name = "Szpic wilczy", PkrID = 5},
                new Breed { Name = "Szpic w�oski", PkrID = 5},
                new Breed { Name = "Thai Ridgeback Dog", PkrID = 5},
                new Breed { Name = "Vastgotaspets", PkrID = 5},

                //---------------------------------
                //--------------GRUPA 6------------
                //---------------------------------
                new Breed { Name = "Alpejski go�czy kr�tkono�ny", PkrID = 6},
                new Breed { Name = "Ariegeois", PkrID = 6},
                new Breed { Name = "Basset artezyjsko-normandzki", PkrID = 6},
                new Breed { Name = "Basset breto�ski", PkrID = 6},
                new Breed { Name = "Basset gasko�ski", PkrID = 6},
                new Breed { Name = "Basset Hound", PkrID = 6},
                new Breed { Name = "Beagle", PkrID = 6},
                new Breed { Name = "Beagle-Harrier", PkrID = 6},
                new Breed { Name = "Billy", PkrID = 6},
                new Breed { Name = "Black and Tan Coonhound", PkrID = 6},
                new Breed { Name = "Bloodhund", PkrID = 6},
                new Breed { Name = "Cien d'Artois", PkrID = 6},
                new Breed { Name = "Dalmaty�czyk", PkrID = 6},
                new Breed { Name = "Drever", PkrID = 6},
                new Breed { Name = "Dunker", PkrID = 6},
                new Breed { Name = "Du�y go�czy anglo-francuski bia�o-czarny", PkrID = 6},
                new Breed { Name = "Du�y go�czy anglo-francuski bia�o-pomara�czony", PkrID = 6},
                new Breed { Name = "Du�y go�czy anglo-francuski tr�jkolorowy", PkrID = 6},
                new Breed { Name = "Du�y go�czy gasko�ski", PkrID = 6},
                new Breed { Name = "Foxhound ameryka�ski", PkrID = 6},
                new Breed { Name = "Foxhound angielski", PkrID = 6},
                new Breed { Name = "Go�czy austriacki - Brandlbracke", PkrID = 6},
                new Breed { Name = "Go�czy berne�ski", PkrID = 6},
                new Breed { Name = "Go�czy berne�ski kr�tkono�ny kr�tkow�osy", PkrID = 6},
                new Breed { Name = "Go�czy berne�ski kr�tkono�ny szorstkow�osy", PkrID = 6},
                new Breed { Name = "Go�czy bo�niacki szorstkow�osy Barak", PkrID = 6},
                new Breed { Name = "Go�czy chorwacki", PkrID = 6},
                new Breed { Name = "Go�czy fi�ski", PkrID = 6},
                new Breed { Name = "Go�czy francuski bia�o-czarny", PkrID = 6},
                new Breed { Name = "Go�czy francuski bia�o-pomara�czowy", PkrID = 6},
                new Breed { Name = "Go�czy francuski tr�jkolorowy", PkrID = 6},
                new Breed { Name = "Go�czy grecki", PkrID = 6},
                new Breed { Name = "Go�czy Hamiltona", PkrID = 6},
                new Breed { Name = "Go�czy hiszpa�ski", PkrID = 6},
                new Breed { Name = "Go�czy istryjski kr�tkow�osy", PkrID = 6},
                new Breed { Name = "Go�czy istryjski szorstkow�osy", PkrID = 6},
                new Breed { Name = "Go�czy jugos�owia�ski tr�jkolorowy", PkrID = 6},
                new Breed { Name = "Go�czy lucere�ski", PkrID = 6},
                new Breed { Name = "Go�czy lucere�ski kr�tkono�ny", PkrID = 6},
                new Breed { Name = "go�czy niemiecki", PkrID = 6},
                new Breed { Name = "Go�czy Schillera", PkrID = 6},
                new Breed { Name = "Go�czy serbski", PkrID = 6},
                new Breed { Name = "Go�czy s�owacki", PkrID = 6},
                new Breed { Name = "Go�czy smalandzki", PkrID = 6},
                new Breed { Name = "Go�czy stryjski", PkrID = 6},
                new Breed { Name = "Go�czy szwajcarski", PkrID = 6},
                new Breed { Name = "Go�czy tyrolski", PkrID = 6},
                new Breed { Name = "Go�czy w�gierski", PkrID = 6},
                new Breed { Name = "Go�czy w�oski kr�tkow�osy", PkrID = 6},
                new Breed { Name = "Go�czy w�oski szorstkow�osy", PkrID = 6},
                new Breed { Name = "Go�czy z Jury", PkrID = 6},
                new Breed { Name = "Go�czy z Jury kr�tkono�ny", PkrID = 6},
                new Breed { Name = "Go�czy ze Schwyz", PkrID = 6},
                new Breed { Name = "Go�czy ze Schwyz kr�tkono�ny", PkrID = 6},
                new Breed { Name = "Go�czy Basset griffon vendeen", PkrID = 6},
                new Breed { Name = "Grand gascon saintongeois", PkrID = 6},
                new Breed { Name = "Grand griffon vendeen", PkrID = 6},
                new Breed { Name = "Haldenstovare", PkrID = 6},
                new Breed { Name = "Harrier", PkrID = 6},
                new Breed { Name = "Hygenhund", PkrID = 6},
                new Breed { Name = "Jugos�owia�ski go�czy g�rski", PkrID = 6},
                new Breed { Name = "Ma�y go�czy anglo-francuski", PkrID = 6},
                new Breed { Name = "Ma�y go�czy gasko�ski", PkrID = 6},
                new Breed { Name = "Ogar polski", PkrID = 6},
                new Breed { Name = "Otterbound", PkrID = 6},
                new Breed { Name = "Petit Basset griffon vendeen", PkrID = 6},
                new Breed { Name = "Petit gascon saintongeois", PkrID = 6},
                new Breed { Name = "Poitevin", PkrID = 6},
                new Breed { Name = "Porcelaine", PkrID = 6},
                new Breed { Name = "Posokowiec bawarki", PkrID = 6},
                new Breed { Name = "Posokowiec hanowerski", PkrID = 6},
                new Breed { Name = "Rhiodesian Ridgeback", PkrID = 6},
                new Breed { Name = "Szorskow�osy go�czy breto�ski", PkrID = 6},
                new Breed { Name = "Szorstkow�osy go�czy gasko�ski", PkrID = 6},
                new Breed { Name = "Szorstkow�osy go�czy wandejski", PkrID = 6},
                new Breed { Name = "Szorstkow�osy go�czy z Nivernais", PkrID = 6},
                new Breed { Name = "Westfalski go�czy kr�tkono�ny", PkrID = 6},

                //---------------------------------
                //--------------GRUPA 2------------
                //---------------------------------
                /*new Breed { Name = "", PkrID = 7},
                new Breed { Name = "", PkrID = 7},
                new Breed { Name = "", PkrID = 7},
                new Breed { Name = "", PkrID = 7},
                new Breed { Name = "", PkrID = 7},
                new Breed { Name = "", PkrID = 7},
                new Breed { Name = "", PkrID = 7},
                new Breed { Name = "", PkrID = 7},
                new Breed { Name = "", PkrID = 7},
                new Breed { Name = "", PkrID = 7},
                new Breed { Name = "", PkrID = 7},
                new Breed { Name = "", PkrID = 7},
                new Breed { Name = "", PkrID = 7},
                new Breed { Name = "", PkrID = 7},
                */
            };

            breeds.ForEach(b => context.Breeds.AddOrUpdate(p => p.Name, b));
            context.SaveChanges();
        }
    }
}
