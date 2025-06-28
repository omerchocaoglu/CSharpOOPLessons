using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritma
{
    class Program
    {
        static void Main()
        {
            Console.Write("L�tfen bir metin ve index giriniz (�rnek: Algoritma,3): ");
            string input = Console.ReadLine();

            var girdi = new GirdiIsleyici();
            var (metin, index) = girdi.Parse(input);

            if (index < 0 || index >= metin.Length)
            {
                Console.WriteLine($"Ge�ersiz index: {index}. Metin uzunlu�u: {metin.Length}");
                return;
            }

            var silici = new KarakterSilici();
            string sonuc = silici.Sil(metin, index);

            Console.WriteLine($"Sonu�: {sonuc}");
        }
    }
    public class GirdiIsleyici
    {
        public (string metin, int index) Parse(string input)
        {
            var parcalar = input.Split(',');
            if (parcalar.Length != 2)
                throw new ArgumentException("Giri� 'metin,index' format�nda olmal�d�r.");

            string metin = parcalar[0];
            if (!int.TryParse(parcalar[1], out int index))
                throw new ArgumentException("Index ge�erli bir say� olmal�d�r.");

            return (metin, index);
        }
    }
    public class KarakterSilici
    {
        public string Sil(string metin, int index)
        {
            return metin.Remove(index, 1);
        }
    }
}
