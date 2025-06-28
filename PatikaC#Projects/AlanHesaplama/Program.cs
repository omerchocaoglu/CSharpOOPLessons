using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlanHesaplama
{
    public interface IShape
    {
        double AlanHesapla();
        double CevreHesapla();
    }
    class Program
    {
        static void Main()
        {
            var input = new InputHandler();
            var sekil = input.SekilSec();

            var hesaplamaTuru = input.HesaplamaTuruSec();

            double sonuc = 0;

            switch (hesaplamaTuru)
            {
                case "Alan":
                    sonuc = sekil.AlanHesapla();
                    break;
                case "Cevre":
                    sonuc = sekil.CevreHesapla();
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim!");
                    return;
            }

            Console.WriteLine($"{hesaplamaTuru} sonucu: {sonuc:F2}");
        }
    }
    public class InputHandler
    {
        public IShape SekilSec()
        {
            Console.WriteLine("Þekil seçiniz: 1-Daire, 2-Kare, 3-Dikdörtgen, 4-Üçgen");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    double yaricap = VeriAl("Yarýçapý giriniz:");
                    return new Daire(yaricap);
                case "2":
                    double kenar = VeriAl("Kenar uzunluðunu giriniz:");
                    return new Kare(kenar);
                case "3":
                    double en = VeriAl("En uzunluðunu giriniz:");
                    double boy = VeriAl("Boy uzunluðunu giriniz:");
                    return new Dikdortgen(en, boy);
                case "4":
                    double taban = VeriAl("Taban uzunluðunu giriniz:");
                    double yukseklik = VeriAl("Yüksekliði giriniz:");
                    return new Ucgen(taban, yukseklik);
                default:
                    Console.WriteLine("Geçersiz seçim, varsayýlan: Daire");
                    return new Daire(1);
            }
        }

        public string HesaplamaTuruSec()
        {
            Console.WriteLine("Hangi hesaplama yapýlacak? (Alan / Cevre)");
            return Console.ReadLine();
        }
        private double VeriAl(string mesaj)
        {
            Console.Write(mesaj + " ");
            double deger;  // burda tanýmla

            while (!double.TryParse(Console.ReadLine(), out deger) || deger <= 0)
            {
                Console.WriteLine("Lütfen pozitif bir sayý giriniz.");
                Console.Write(mesaj + " ");
            }
            return deger;  // artýk burada eriþilebilir
        }
    }
    public class Daire : IShape
    {
        public double YariCap { get; }

        public Daire(double yariCap)
        {
            YariCap = yariCap;
        }

        public double AlanHesapla()
        {
            return Math.PI * YariCap * YariCap;
        }

        public double CevreHesapla()
        {
            return 2 * Math.PI * YariCap;
        }
    }
    public class Kare : IShape
    {
        public double Kenar { get; }

        public Kare(double kenar)
        {
            Kenar = kenar;
        }

        public double AlanHesapla()
        {
            return Kenar * Kenar;
        }

        public double CevreHesapla()
        {
            return 4 * Kenar;
        }
    }
    public class Dikdortgen : IShape
    {
        public double En { get; }
        public double Boy { get; }

        public Dikdortgen(double en, double boy)
        {
            En = en;
            Boy = boy;
        }

        public double AlanHesapla()
        {
            return En * Boy;
        }

        public double CevreHesapla()
        {
            return 2 * (En + Boy);
        }
    }
    public class Ucgen : IShape
    {
        public double Taban { get; }
        public double Yukseklik { get; }

        public Ucgen(double taban, double yukseklik)
        {
            Taban = taban;
            Yukseklik = yukseklik;
        }

        public double AlanHesapla()
        {
            return (Taban * Yukseklik) / 2;
        }

        public double CevreHesapla()
        {
            // Basitçe tabanýn üç katý kabul edildi (eþkenar üçgen)
            return 3 * Taban;
        }
    }
}
