using System;
using System.Collections.Generic;
using System.Linq;

namespace CalisanTakip
{
    public class Calisan
    {
        private string ad;
        private string soyad;
        private int yas;
        private string departman;
        private string pozisyon;
        private int izinGunleri;
        private string tcKimlikNo;
        private string sifre;
        private bool yoneticiMi;

        public string Ad => ad;
        public string Soyad => soyad;
        public int Yas => yas;
        public string Departman => departman;
        public string Pozisyon => pozisyon;
        public int KalanIzinGunleri => izinGunleri;
        public string TcKimlikNo => tcKimlikNo;
        public bool YoneticiMi => yoneticiMi;

        public Calisan(string ad, string soyad, int yas, string departman, string pozisyon, string tcKimlikNo, string sifre, int izinGunleri = 20, bool yoneticiMi = false)
        {
            if (yas <= 0)
            {
                Console.WriteLine("Hata: Yaş 0 veya negatif olamaz.");
                return;
            }
            this.ad = ad;
            this.soyad = soyad;
            this.yas = yas;
            this.departman = departman;
            this.pozisyon = pozisyon;
            this.tcKimlikNo = tcKimlikNo;
            this.sifre = sifre;
            this.izinGunleri = izinGunleri;
            this.yoneticiMi = yoneticiMi;
        }

        public void IzinGunleriEkle(int gun)
        {
            if (gun < 0)
            {
                Console.WriteLine("Hata: Gün sayısı negatif olamaz.");
                return;
            }
            izinGunleri += gun;
        }

        public bool IzinKullan(int gun)
        {
            if (gun <= 0)
            {
                Console.WriteLine("Hata: İzin günü 0 veya negatif olamaz.");
                return false;
            }
            if (gun > izinGunleri)
            {
                Console.WriteLine("Hata: Yeterli izin gününüz yok. Kalan izin günleriniz: " + izinGunleri);
                return false;
            }
            izinGunleri -= gun;
            Console.WriteLine("İzin talebiniz onaylandı. Kalan izin günleriniz: " + izinGunleri);
            return true;
        }

        public bool SifreDogrula(string sifre)
        {
            return this.sifre == sifre;
        }

        public override string ToString()
        {
            return "Ad: " + Ad + " " + Soyad + ", Yaş: " + Yas + ", Departman: " + Departman + ", Pozisyon: " + Pozisyon + ", Yönetici Mi: " + (YoneticiMi ? "Evet" : "Hayır");
        }
    }

    public class CalisanYonetici
    {
        private List<Calisan> calisanlar = new List<Calisan>();

        public void CalisanEkle(Calisan calisan)
        {
            if (calisan == null)
            {
                Console.WriteLine("Hata: Geçersiz çalışan nesnesi.");
                return;
            }
            calisanlar.Add(calisan);
        }

        public void CalisanCikar(string tcKimlikNo)
        {
            var calisan = calisanlar.FirstOrDefault(c => c.TcKimlikNo == tcKimlikNo);
            if (calisan != null)
            {
                calisanlar.Remove(calisan);
            }
            else
            {
                Console.WriteLine("Hata: Çalışan bulunamadı.");
            }
        }

        public void GirisYap(string ad, string soyad, string sifre)
        {
            foreach (var calisan in calisanlar)
            {
                if (calisan.Ad.Equals(ad, StringComparison.OrdinalIgnoreCase) &&
                    calisan.Soyad.Equals(soyad, StringComparison.OrdinalIgnoreCase))
                {
                    if (calisan.SifreDogrula(sifre))
                    {
                        Console.Clear();
                        Console.WriteLine("Giriş başarılı!");
                        Console.WriteLine("------------------------------------------------------");
                        Console.WriteLine(calisan);

                        if (calisan.YoneticiMi)
                        {
                            Console.WriteLine("------------------------------------------------------");
                            Console.WriteLine("Yönetici işlemleri:");
                            Console.WriteLine("1. Çalışan ekle");
                            Console.WriteLine("2. Çalışan çıkar");
                            Console.WriteLine("3. İzin talebi");
                            Console.WriteLine("Seçiminizi yapın:");
                            string secim = Console.ReadLine();

                            if (secim == "1")
                            {
                                Console.WriteLine("------------------------------------------------------");
                                Console.Write("Yeni çalışanın adı: ");
                                string adCalisan = Console.ReadLine();
                                Console.Write("Yeni çalışanın soyadı: ");
                                string soyadCalisan = Console.ReadLine();
                                Console.Write("Yeni çalışanın TC Kimlik No: ");
                                string tcKimlikNoCalisan = Console.ReadLine();
                                Console.Write("Yeni çalışanın şifresi: ");
                                string sifreCalisan = Program.SifreGizle();

                                Calisan yeniCalisan = new Calisan(adCalisan, soyadCalisan, 30, "Departman", "Pozisyon", tcKimlikNoCalisan, sifreCalisan);
                                Console.Write("Çalışan eklemek istiyor musunuz? (evet/hayır): ");
                                string onay = Console.ReadLine().ToLower();
                                if (onay == "evet")
                                {
                                    CalisanEkle(yeniCalisan);
                                    Console.WriteLine($"{yeniCalisan.Ad} {yeniCalisan.Soyad} başarıyla eklendi.");
                                }
                                else
                                {
                                    Console.WriteLine("Çalışan eklenmedi.");
                                }
                                Console.WriteLine("------------------------------------------------------");
                            }
                            else if (secim == "2")
                            {
                                Console.WriteLine("------------------------------------------------------");
                                Console.Write("Çıkarmak istediğiniz çalışanın TC Kimlik No: ");
                                string tcKimlikNoCikar = Console.ReadLine();
                                Console.Write("Çalışan çıkarmak istiyor musunuz? (evet/hayır): ");
                                string onay = Console.ReadLine().ToLower();
                                if (onay == "evet")
                                {
                                    CalisanCikar(tcKimlikNoCikar);
                                    Console.WriteLine("Çalışan başarıyla çıkarıldı.");
                                }
                                else
                                {
                                    Console.WriteLine("Çalışan çıkarılmadı.");
                                }
                                Console.WriteLine("------------------------------------------------------");
                            }
                            else if (secim == "3")
                            {
                                Console.WriteLine("------------------------------------------------------");
                                Console.Write("Yönetici izin talep etmek istiyor musunuz? (evet/hayır): ");
                                string izinOnay = Console.ReadLine().ToLower();
                                if (izinOnay == "evet")
                                {
                                    Console.Write("Kaç gün izin kullanmak istiyorsunuz?: ");
                                    int izinGun;
                                    if (int.TryParse(Console.ReadLine(), out izinGun) && izinGun > 0)
                                    {
                                        if (calisan.IzinKullan(izinGun))
                                        {
                                            Console.WriteLine("Yönetici izni onaylandı.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Yönetici izni reddedildi.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geçersiz izin günü.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Yönetici izin talebini reddetti.");
                                }
                                Console.WriteLine("------------------------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine("Geçersiz seçim.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("------------------------------------------------------");
                            Console.WriteLine("İzin talebiniz için yönetici onayı gerekmektedir.");
                            Console.WriteLine("Kaç gün izin kullanmak istiyorsunuz?: ");
                            int izinGun;
                            if (int.TryParse(Console.ReadLine(), out izinGun) && izinGun > 0)
                            {
                                Console.WriteLine("İzin talebiniz yöneticinize sunulacaktır.");
                                Console.WriteLine("------------------------------------------------------");
                                Console.Write("Yönetici adı: ");
                                string yoneticiAd = Console.ReadLine();
                                Console.Write("Yönetici soyadı: ");
                                string yoneticiSoyad = Console.ReadLine();
                                Console.Write("Yönetici şifresi: ");
                                string yoneticiSifre = Program.SifreGizle();
                                Console.WriteLine("------------------------------------------------------");

                                Calisan yonetici = calisanlar.Find(c => c.YoneticiMi && c.Ad.Equals(yoneticiAd, StringComparison.OrdinalIgnoreCase) && c.Soyad.Equals(yoneticiSoyad, StringComparison.OrdinalIgnoreCase));
                                if (yonetici != null && yonetici.SifreDogrula(yoneticiSifre))
                                {
                                    Console.WriteLine($"{yonetici.Ad} {yonetici.Soyad} onayı bekleniyor.");
                                    Console.Write("Yönetici izin onayını veriyor mu? (evet/hayır): ");
                                    string onay = Console.ReadLine().ToLower();

                                    if (onay == "evet")
                                    {
                                        calisan.IzinKullan(izinGun);
                                    }
                                    else
                                    {
                                        Console.WriteLine("İzin reddedildi.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Yönetici bulunamadı veya şifre yanlış.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Hatalı gün sayısı girdiniz.");
                            }
                            Console.WriteLine("------------------------------------------------------");
                        }
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Hata: Şifre yanlış.");
                        return;
                    }
                }
            }
            Console.WriteLine("Hata: Çalışan bulunamadı.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hoşgeldiniz!");
            Console.WriteLine("   *****     *****   ");
            Console.WriteLine("  *******   *******  ");
            Console.WriteLine(" ********* ********* ");
            Console.WriteLine(" ******************* ");
            Console.WriteLine("  *****************  ");
            Console.WriteLine("   ***************   ");
            Console.WriteLine("    *************    ");
            Console.WriteLine("     ***********     ");
            Console.WriteLine("      *********      ");
            Console.WriteLine("       *******       ");
            Console.WriteLine("        *****        ");
            Console.WriteLine("         ***         ");
            Console.WriteLine("          *          ");

            CalisanYonetici yonetici = new CalisanYonetici();
            var calisan1 = new Calisan("Nehir", "Saygılı", 20, "Mühendislik", "Kıdemli Mühendis", "12345678901", "333", 60, true);
            var calisan2 = new Calisan("Nursena", "Yağcı", 20, "Pazarlama", "Yönetici", "98765432109", "777", 60, true);
            var calisan3 = new Calisan("Ekin", "Koç", 35, "Muhasebe", "Uzman", "11223344556", "1992", 30);
            var calisan4 = new Calisan("Boran", "Kuzum", 32, "İK", "İK Uzmanı", "1111111111", "1881", 18);
            var calisan5 = new Calisan("Burçin", "Terzioğlu", 44, "Bilişim", "Kıdemli Yazılım Geliştirici", "55667788990", "5678", 45);
            yonetici.CalisanEkle(calisan1);
            yonetici.CalisanEkle(calisan2);
            yonetici.CalisanEkle(calisan3);
            yonetici.CalisanEkle(calisan4);
            yonetici.CalisanEkle(calisan5);

            Console.WriteLine("Giriş yapmak için adınızı, soyadınızı ve şifrenizi giriniz:");
            Console.Write("Ad: ");
            string ad = Console.ReadLine();
            Console.Write("Soyad: ");
            string soyad = Console.ReadLine();
            Console.Write("Şifre: ");
            string sifre = SifreGizle();

            yonetici.GirisYap(ad, soyad, sifre);

            Console.WriteLine("İyi günler!");
            Console.WriteLine("   *****     *****   ");
            Console.WriteLine("  *******   *******  ");
            Console.WriteLine(" ********* ********* ");
            Console.WriteLine(" ******************* ");
            Console.WriteLine("  *****************  ");
            Console.WriteLine("   ***************   ");
            Console.WriteLine("    *************    ");
            Console.WriteLine("     ***********     ");
            Console.WriteLine("      *********      ");
            Console.WriteLine("       *******       ");
            Console.WriteLine("        *****        ");
            Console.WriteLine("         ***         ");
            Console.WriteLine("          *          ");
        }

        public static string SifreGizle()
        {
            string sifre = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (sifre.Length > 0)
                    {
                        sifre = sifre.Substring(0, sifre.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    sifre += key.KeyChar;
                    Console.Write("*");
                }
            }
            return sifre;
        }
    }
}
