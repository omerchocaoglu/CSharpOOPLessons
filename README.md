# CSharpOOPLessons
## Bu repo [Patika.dev](https://www.patika.dev) tarafından verilen `CSharpOOPLessons` csharp projesini içermektedir.

Ödev 1 - Üniversite Yönetim Sistemi

1 - Üniversiteye ait sınıflıklar, çalışma ofisleri ve departmanlar vardır.

2 - Departmanlara ait ofisler vardır.

3 - Üniversiteye ait çalışanlar vardır. Bu çalışanlar profesör veya memur olabilir.

4 - Her çalışan bir ofiste çalışır.

Bu sistemi tasvir eden Class (Sınıf) diyagramını çiziniz.

Not : Sınıflara ait nitelik ve davranışların belirtilmesine gerek yoktur.

            +-----------------+
            |   Universite    |
            +-----------------+
            | - sinifliklar   |<>----> [Sınıflık]
            | - ofisler       |<>----> [Ofis]
            | - departmanlar  |<>----> [Departman]
            +-----------------+

                          |
                          |
                          v
                 +----------------+
                 |   Departman    |
                 +----------------+
                 | - ofisler      |<>----> [Ofis]
                 +----------------+

                          |
                          |
                          v
                     +----------+
                     |  Ofis    |
                     +----------+

                          ^
                          |
                          |
           +--------------+----------------+
           |                               |
  +----------------+            +----------------+
  |   Calisan      |<---------->|   Ofis         |
  +----------------+            +----------------+
  |# Ad, Soyad vs. |                     
  +----------------+                     
           ^
           |
    +-------------+
    |             |
+-------------+ +-------------+
|  Profesör   | |   Memur     |
+-------------+ +-------------+

class Universite
{
    public List<Siniflik> Sinifliklar { get; set; }
    public List<Ofis> Ofisler { get; set; }
    public List<Departman> Departmanlar { get; set; }
}

class Siniflik { }

class Departman
{
    public List<Ofis> Ofisler { get; set; }
}

class Ofis { }

abstract class Calisan
{
    public Ofis Ofisi { get; set; }
}

class Profesör : Calisan { }

class Memur : Calisan { }

---
Ödev 2 - Hayvanat Bahçesi Yönetimi
Bir hayvanat bahçesindeki hayvanlar hakkındaki bilgileri takip etmek için bir sistem tasarlıyorsunuz.

Hayvanlar:
Atlar (atlar, zebralar, eşekler vb.),
Kedigiller (kaplanlar, aslanlar vb.),
Kemirgenler (sıçanlar, kunduzlar vb.) gibi gruplardaki türlerle karakterize edilir.
Hayvanlar hakkında depolanan bilgilerin çoğu tüm gruplamalar için aynıdır.
tür adı, ağırlığı, yaşı vb.
Sistem ayrıca her hayvan için belirli ilaçların dozajını alabilmeli => getDosage ()
Sistem Yem verme zamanlarını hesaplayabilmelidir => getFeedSchedule ()
Sistemin bu işlevleri yerine getirme mantığı, her gruplama için farklı olacaktır. Örneğin, atlar için yem verme algoritması farklı olup, kaplanlar için farklı olacaktır.

Polimorfizm modelini kullanarak, yukarıda açıklanan durumu ele almak için bir sınıf diyagramı tasarlayın.
          +--------------------+
          |  abstract class    |
          |      Hayvan        |
          +--------------------+
          | - TurAdi : string  |
          | - Agirlik : double |
          | - Yas : int        |
          +--------------------+
          | + getDosage()      | (abstract)
          | + getFeedSchedule()| (abstract)
          +--------------------+
                   ▲
        ┌──────────┼──────────┐
        │          │          │
+----------------+ +----------------+ +----------------+
|      At        | |   Kedigil      | |   Kemirgen     |
+----------------+ +----------------+ +----------------+
| +getDosage()   | | +getDosage()   | | +getDosage()   |
| +getFeed...()  | | +getFeed...()  | | +getFeed...()  |
+----------------+ +----------------+ +----------------+
// Soyut sınıf
public abstract class Hayvan
{
    public string TurAdi { get; set; }
    public double Agirlik { get; set; }
    public int Yas { get; set; }

    public abstract double GetDosage();         // Her hayvan grubu kendisi hesaplar
    public abstract string GetFeedSchedule();   // Her hayvan grubu kendisi verir
}

// Alt sınıf - At
public class At : Hayvan
{
    public override double GetDosage()
    {
        return Agirlik * 0.05;  // Örneğin kilogram başına 0.05 ml ilaç
    }

    public override string GetFeedSchedule()
    {
        return "Günde 2 kez: Sabah 08:00, Akşam 18:00";
    }
}

// Alt sınıf - Kedigil
public class Kedigil : Hayvan
{
    public override double GetDosage()
    {
        return Agirlik * 0.03;
    }

    public override string GetFeedSchedule()
    {
        return "Günde 1 kez: Akşam 20:00";
    }
}

// Alt sınıf - Kemirgen
public class Kemirgen : Hayvan
{
    public override double GetDosage()
    {
        return Agirlik * 0.01;
    }

    public override string GetFeedSchedule()
    {
        return "Günde 3 kez: Sabah, Öğlen, Akşam";
    }
}

---
Ödev 3 - Uçuş Yönetim Sistemi
Uçuşların ve pilotların yönetimi için bir sistem tasarlayın.

Hava yolu şirketleri uçuşları gerçekleştirir. Her hava yolunun bir kimliği vardır.
Hava yolu şirketi, farklı tipteki uçaklara sahiptir.
Uçaklar çalışır veya onarım durumunda olabilir.
Her uçuşun benzersiz kimliği, kalkacağı ve ineceği havaalanı, kalkış ve iniş saatleri vardır.
Her uçuşun bir pilotu ve yardımcı pilotu vardır ve uçağı kullanırlar.
Havaalanlarının benzersiz kimlikleri ve isimleri vardır.
Hava yolu şirketlerinin pilotları vardır ve her pilotun bir deneyim seviyesi mevcuttur.
Bir uçak tipi, belirli sayıda pilota ihtiyaç duyabilir.
Bu sistemi tasvir eden Class(Sınıf) diyagramını çiziniz.

+-------------------------+
|   HavayoluSirketi       |
+-------------------------+
| - SirketID : int        |
| - SirketAdi : string    |
+-------------------------+
| +Ucaklar : List<Ucak>   |
| +Pilotlar : List<Pilot> |
+-------------------------+

            |
            | owns
            v

+--------------------+            +------------------+
|       Ucak         |            |     Pilot        |
+--------------------+            +------------------+
| - UcakID : int     |            | - PilotID : int  |
| - Durum : enum     |            | - Ad : string    |
|                    |            | - Deneyim : int  |
| - Tipi : UcakTipi  |<---------->| - Sirket : H.S.  |
+--------------------+            +------------------+

            ^
            | belongs to
            |
+--------------------------+
|       UcakTipi           |
+--------------------------+
| - TipAdi : string        |
| - GerekliPilotSayisi:int |
+--------------------------+

+------------------------------+
|          Ucus               |
+------------------------------+
| - UcusID : int               |
| - KalkisSaati : DateTime     |
| - InisSaati : DateTime       |
+------------------------------+
| - Pilot : Pilot              |
| - YardimciPilot : Pilot      |
| - Ucak : Ucak                |
| - KalkisHavalimani : Havalimani |
| - InisHavalimani : Havalimani   |
+------------------------------+

+--------------------------+
|      Havalimani          |
+--------------------------+
| - ID : int               |
| - Ad : string            |
+--------------------------+

public class HavayoluSirketi
{
    public int SirketID { get; set; }
    public string SirketAdi { get; set; }
    public List<Ucak> Ucaklar { get; set; }
    public List<Pilot> Pilotlar { get; set; }
}

public class Ucak
{
    public int UcakID { get; set; }
    public UcakDurumu Durum { get; set; }  // enum: Calisir, Onarimda
    public UcakTipi Tipi { get; set; }
}

public enum UcakDurumu
{
    Calisir,
    Onarimda
}

public class UcakTipi
{
    public string TipAdi { get; set; }
    public int GerekliPilotSayisi { get; set; }
}

public class Pilot
{
    public int PilotID { get; set; }
    public string Ad { get; set; }
    public int DeneyimSeviyesi { get; set; }
    public HavayoluSirketi Sirket { get; set; }
}

public class Havalimani
{
    public int ID { get; set; }
    public string Ad { get; set; }
}

public class Ucus
{
    public int UcusID { get; set; }
    public DateTime KalkisSaati { get; set; }
    public DateTime InisSaati { get; set; }

    public Pilot Pilot { get; set; }
    public Pilot YardimciPilot { get; set; }
    public Ucak Ucak { get; set; }
    public Havalimani KalkisHavalimani { get; set; }
    public Havalimani InisHavalimani { get; set; }
}
---

Ödev 4 - Online Film Sistemi
Online film satan veya kiralayan uygulamanın sistemini tasarlayın.

Uygulamada filmler listelenebilir, sıralanabilir ve kullanıcılar uygulamaya abone olabilir.
Kullanıcılar abonelik için sistem üzerinden kredi satın alır.
Sadece abone olan kullanıcılar, kredileri ile film kiralayabilir ve kiraladığı filmin kredi bedeli kadar hesabından düşülür.
Normal kullanıcılar ve aboneler film satın alabilirler.
Eğer film mevcut değil ise talep edilebilir.
Bu sistemi tasvir eden Class(Sınıf) diyagramını çiziniz.

        +-------------------+
        |  abstract Kullanici|
        +-------------------+
        | - ID : int         |
        | - AdSoyad : string |
        | - Email : string   |
        +-------------------+
        | +SatinAl(Film)     |
        | +TalepEt(Film)     |
        +-------------------+
               ▲
      ┌────────┴────────┐
      |                 |
+----------------+   +-------------------+
| NormalKullanici |   | AboneKullanici    |
+----------------+   +-------------------+
                    | - Kredi : double    |
                    | +KrediSatınAl()     |
                    | +Kirala(Film)       |
                    +-------------------+

+------------------------+
|        Film            |
+------------------------+
| - FilmID : int         |
| - Ad : string          |
| - Fiyat : double       |
| - KiralamaKredisi: int |
| - Mevcut : bool        |
+------------------------+

+------------------------+
|        Talep           |
+------------------------+
| - TalepID : int        |
| - Film : Film          |
| - Kullanici : Kullanici|
| - Tarih : DateTime     |
+------------------------+

+-------------------------+
|       Kiralama          |
+-------------------------+
| - ID : int              |
| - Film : Film           |
| - Abone : AboneKullanici|
| - Tarih : DateTime      |
+-------------------------+

+-------------------------+
|       SatinAlim         |
+-------------------------+
| - ID : int              |
| - Film : Film           |
| - Kullanici : Kullanici |
| - Tarih : DateTime      |
+-------------------------+

public abstract class Kullanici
{
    public int ID { get; set; }
    public string AdSoyad { get; set; }
    public string Email { get; set; }

    public virtual void SatinAl(Film film)
    {
        // Fiyat ödemesi vs.
    }

    public void TalepEt(Film film)
    {
        // Film talep listesine eklenir
    }
}

public class NormalKullanici : Kullanici
{
    // Sadece satın alabilir ve talep edebilir
}

public class AboneKullanici : Kullanici
{
    public double Kredi { get; set; }

    public void KrediSatinAl(double miktar)
    {
        Kredi += miktar;
    }

    public void Kirala(Film film)
    {
        if (Kredi >= film.KiralamaKredisi)
        {
            Kredi -= film.KiralamaKredisi;
            // Kiralama kaydı oluştur
        }
    }

    public override void SatinAl(Film film)
    {
        // Satın alabilir, tıpkı normal kullanıcı gibi
    }
}

public class Film
{
    public int FilmID { get; set; }
    public string Ad { get; set; }
    public double Fiyat { get; set; }
    public int KiralamaKredisi { get; set; }
    public bool Mevcut { get; set; }
}

public class Talep
{
    public int TalepID { get; set; }
    public Film Film { get; set; }
    public Kullanici Kullanici { get; set; }
    public DateTime Tarih { get; set; }
}

public class Kiralama
{
    public int ID { get; set; }
    public Film Film { get; set; }
    public AboneKullanici Abone { get; set; }
    public DateTime Tarih { get; set; }
}

public class SatinAlim
{
    public int ID { get; set; }
    public Film Film { get; set; }
    public Kullanici Kullanici { get; set; }
    public DateTime Tarih { get; set; }
}
---

Ödev - Asansör Simülasyonu
Aşağıdaki problem ifadesine göre bir sınıf diyagramı tasarlayın.

Nesne Yönelimli Programlamanın ilkelerini ve sınıflar arası ilişki durumlarını kullanmaya çalışın. (Encapsulation, Inheritance, Polymorphism, Abstraction)

Kodluyoruz Sigorta Şirketi 12 katlı bir ofis binası inşa etmek ve onu en son asansör teknolojisi ile donatmak istiyor. Şirket, bina içindeki trafik akışı ihtiyaçlarını karşılayıp karşılamayacaklarını görmek için binanın asansörlerinin işlemlerini modelleyen bir yazılım simülatörü oluşturmanızı istiyor.

Binada, her biri binanın 12 katına çıkabilecek beş asansör bulunacaktır. Her asansörün yaklaşık altı yetişkin yolcu kapasitesi vardır. Asansörler enerji tasarruflu olacak şekilde tasarlanmıştır, bu nedenle yalnızca gerektiğinde hareket ederler. Her asansörün kendi kapısı, kat gösterge ışığı ve kontrol paneli vardır. Kontrol panelinde hedef düğmeleri, kapı açma ve kapama düğmeleri ve bir acil durum sinyal düğmesi bulunur.

Binadaki her katta, beş asansör boşluğunun her biri için bir kapı ve her kapı için bir varış zili vardır. Varış zili, asansörlerin bir kata vardığını gösterir. Her kapının üzerinde bulunan bir sinyal ışığı, asansörün gelişini ve asansörün hareket ettiği yönü gösterir. Her katta ayrıca üç set asansör çağrı düğmesi vardır.

Bir kişi uygun çağrı düğmesine (yukarı veya aşağı) basarak bir asansörü çağırır. Bir programlayıcı, aramanın başladığı kata gitmek için beş asansörden birini görevlendirir. Asansöre girdikten sonra, bir yolcu tipik olarak bir veya daha fazla hedef düğmesine basar. Asansör kattan kata hareket ederken, asansörün içindeki bir gösterge ışığı yolcuları asansörün konumu hakkında bilgilendirir. Bir asansörün bir kata varması, dış asansör kapısının üzerindeki gösterge lambasının yakılması ve kat zilinin çalmasıyla belirtilir. Bir asansör bir katta durduğunda, her iki kapı grubu da önceden belirlenmiş bir süre boyunca otomatik olarak açılarak yolcuların asansöre girip çıkmalarına izin verir.

Simülatör, gerçek zaman geçişini simüle etmek ve simülasyonda meydana gelen olayları zaman damgası ve günlüğe kaydetmek için bir "saat" kullanır. Simülatör tarafından yolcu oluşturmak ve her yolcu için kalkış ve varış katlarını belirlemek için rastgele bir sayı üreteci kullanılır.
+--------------------+
|    Simulator       |
+--------------------+
| - saat : Saat      |
| - yolcuUretici     |
| - asansorList[]    |
| - katList[]        |
+--------------------+
| +Baslat()          |
| +Guncelle()        |
+--------------------+

+------------+       +------------+
|   Saat     |       | YolcuUretici |
+------------+       +--------------+
| +SimuleEt()|       | +YolcuUret() |
+------------+       +--------------+

+--------------------+
|     Asansor        |
+--------------------+
| - id : int         |
| - kapasite : int   |
| - mevcutKat : int  |
| - hedefKat[]       |
| - yolcular[]       |
| - kontrolPaneli    |
| - kapi             |
| - sinyalIsigi      |
+--------------------+
| +KataGit()         |
| +KapiAc/Kapa()     |
| +YolcuAl/Bırak()   |
+--------------------+

+--------------------+
|   KontrolPaneli    |
+--------------------+
| - hedefDugmeleri[] |
| - acKapaDugmeleri  |
| - acilDurumDugmesi |
+--------------------+
| +HedefSec()        |
+--------------------+

+------------+        +-------------+
|   Kat      |<>------|  CagriButonu|
+------------+        +-------------+
| - numara   |        | - yon       |
| - zil      |        | +Basildi()  |
| - sinyal   |
+------------+

+------------+        +----------+
|   Yolcu    |        |  Kapi    |
+------------+        +----------+
| - id       |        | - durum  |
| - kaynak   |        | +Ac()    |
| - hedef    |        | +Kapat() |
+------------+        +----------+

+------------------+
|   SinyalIsigi    |
+------------------+
| - yon : enum     |
| +Goster()        |
+------------------+

+--------+
|  Zil   |
+--------+
| +Cal() |
+--------+
public class Asansor
{
    public int ID { get; set; }
    public int Kapasite { get; set; } = 6;
    public int MevcutKat { get; set; } = 0;
    public List<Yolcu> Yolcular { get; set; } = new();
    public List<int> HedefKatlar { get; set; } = new();
    public KontrolPaneli Panel { get; set; } = new();
    public Kapi Kapi { get; set; } = new();
    public SinyalIsigi Sinyal { get; set; } = new();

    public void KataGit(int hedefKat)
    {
        // Basitçe konumu güncelle
        MevcutKat = hedefKat;
        Sinyal.Goster(hedefKat > MevcutKat ? Yon.Yukari : Yon.Asagi);
        // Zil çal, kapıyı aç/kapat vs.
    }
}
---
