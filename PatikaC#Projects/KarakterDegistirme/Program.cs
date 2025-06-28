using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarakterDegistirme
{
    class Program
    {
        static void Main()
        {
            var girdi = new GirdiIsleyici();
            string metin = girdi.MetinAl();

            var degistirici = new KarakterDegistirici();
            string sonuc = degistirici.Degistir(metin);

            Console.WriteLine($"Sonuç: {sonuc}");
        }
    }
    public class GirdiIsleyici
    {
        public string MetinAl()
        {
            Console.Write("Bir metin giriniz: ");
            return Console.ReadLine();
        }
    }
    public class KarakterDegistirici
    {
        public string Degistir(string metin)
        {
            if (string.IsNullOrEmpty(metin) || metin.Length == 1)
                return metin;

            char[] karakterler = metin.ToCharArray();

            // Ýlk ve son karakteri deðiþtir
            char temp = karakterler[0];
            karakterler[0] = karakterler[karakterler.Length - 1];
            karakterler[karakterler.Length - 1] = temp;

            return new string(karakterler);
        }
    }
}
