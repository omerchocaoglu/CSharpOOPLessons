using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutlakKareAlma
{
    class Program
    {
        static void Main()
        {
            var girdi = new GirdiIsleyici();
            var sayilar = girdi.SayilariAl();

            var hesaplayici = new Hesaplayici();
            (int kucukToplam, int buyukToplam) = hesaplayici.Hesapla(sayilar);

            Console.WriteLine($"{kucukToplam} {buyukToplam}");
        }
    }
    public class GirdiIsleyici
    {
        public List<int> SayilariAl()
        {
            Console.WriteLine("Sayýlarý boþlukla giriniz:");
            string input = Console.ReadLine();

            var parcalar = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var sayilar = new List<int>();

            foreach (var parca in parcalar)
            {
                if (int.TryParse(parca, out int sayi))
                    sayilar.Add(sayi);
                else
                    Console.WriteLine($"Geçersiz sayý: {parca}");
            }
            return sayilar;
        }
    }
    public class Hesaplayici
    {
        public (int, int) Hesapla(List<int> sayilar)
        {
            int kucukToplam = 0;
            int buyukToplam = 0;
            int referans = 67;

            foreach (var sayi in sayilar)
            {
                if (sayi < referans)
                    kucukToplam += (referans - sayi);
                else
                {
                    int fark = sayi - referans;
                    buyukToplam += fark * fark;
                }
            }

            return (kucukToplam, buyukToplam);
        }
    }
}
