Çalışan İzin Portalı

Bu proje, bir çalışan takip sistemini simüle etmek için geliştirilmiştir. Proje, çalışanların temel bilgilerini saklama, izin günlerini yönetme ve kullanıcıların sisteme giriş yaparak yönetici veya çalışan olarak işlem yapabilmesini sağlamaktadır.

ÖZELLİKLER

1) Çalışan Ekleme ve Çıkarma
Yöneticiler, yeni çalışanları sisteme ekleyebilir ve mevcut çalışanları sistemden çıkarabilir.

2) Giriş Sistemi
Çalışanlar ve yöneticiler, isim, soyisim ve şifre ile sisteme giriş yapabilir.

3) İzin Yönetimi
Çalışanlar, izin talebinde bulunabilir.
Yöneticiler kendi izinlerini yönetebilir ve çalışanların izin taleplerini onaylayabilir veya reddedebilir.

4) Şifre Doğrulama ve Gizleme
Kullanıcı şifreleri giriş sırasında gizlenerek güvenlik sağlanır.

Sınıflar ve Fonksiyonlar

1. Calisan Sınıfı
Çalışanların bilgilerini ve izinlerini yönetmek için kullanılır.

Özellikler:

Ad: Çalışanın adı.
Soyad: Çalışanın soyadı.
Yas: Çalışanın yaşı.
Departman: Çalışanın çalıştığı departman.
Pozisyon: Çalışanın pozisyonu.
KalanIzinGunleri: Çalışanın kalan izin gün sayısı.
TcKimlikNo: Çalışanın TC Kimlik Numarası.
YoneticiMi: Çalışanın yönetici olup olmadığını belirler.

   
   
   Metotlar:

IzinGunleriEkle(int gun): Çalışana ek izin günü ekler.
IzinKullan(int gun): Çalışanın izin talebini değerlendirir.
SifreDogrula(string sifre): Çalışanın şifresini doğrular.

2. CalisanYonetici Sınıfı

Tüm çalışanları yönetmek için kullanılır.

Metotlar:

CalisanEkle(Calisan calisan): Yeni bir çalışan ekler.
CalisanCikar(string tcKimlikNo): Belirtilen TC Kimlik Numarasına sahip çalışanı sistemden çıkarır.
GirisYap(string ad, string soyad, string sifre): Kullanıcının giriş yapmasını sağlar.

3. Program Sınıfı

Sistemin ana akışını yöneten sınıftır.


Kullanım
Projenin Çalıştırılması

1) Projeyi bir C# geliştirme ortamında (örneğin, Visual Studio) açın.
2) Program.cs dosyasını çalıştırın.

Sistem Akışı

1) Sistem başlarken kullanıcıları karşılayan bir giriş ekranı sunulur.
2) Kullanıcı, ad, soyad ve şifre bilgileriyle giriş yapar.

Yönetici: Yöneticiye özel işlemleri gerçekleştirebilir (çalışan ekleme, çıkarma, izin taleplerini onaylama).
Çalışan: İzin talebinde bulunabilir.

Giriş başarılı olduğunda kullanıcının detayları ekrana yazdırılır ve yönetici veya çalışan işlemleri başlar.



2) Kullanıcı, ad, soyad ve şifre bilgileriyle giriş yapar.
   Yönetici: Yöneticiye özel işlemleri gerçekleştirebilir (çalışan ekleme, çıkarma, izin taleplerini onaylama).
   Çalışan: İzin talebinde bulunabilir.
3) Giriş başarılı olduğunda kullanıcının detayları ekrana yazdırılır ve yönetici veya çalışan işlemleri başlar.
