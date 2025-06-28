using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarakterTerstenYazma
{
    class Program
    {
        static void Main()
        {
            var girdi = new GirdiIsleyici();
            string metin = girdi.MetinAl();

            var degistirici = new KarakterYerDegistirici();
            string sonuc = degistirici.YerDegistir(metin);

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
    public class KarakterYerDegistirici
    {
        public string YerDegistir(string metin)
        {
            if (string.IsNullOrEmpty(metin) || metin.Length == 1)
                return metin;

            char[] karakterler = metin.ToCharArray();

            char onceki = karakterler[0];
            for (int i = 1; i < karakterler.Length; i++)
            {
                char temp = karakterler[i];
                karakterler[i] = onceki;
                onceki = temp;
            }

            karakterler[0] = onceki;

            return new string(karakterler);
        }
    }
}
