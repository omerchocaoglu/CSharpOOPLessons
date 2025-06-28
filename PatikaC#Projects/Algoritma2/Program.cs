using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritma2
{
    class Program
    {
        static void Main()
        {
            var girdi = new GirdiIsleyici();
            var sayilar = girdi.SayiCiftleriniAl();

            var islem = new Islemci();
            var sonu�lar = islem.Isle(sayilar);

            Console.WriteLine(string.Join(" ", sonu�lar));
        }
    }
    public class GirdiIsleyici
    {
        public List<(int, int)> SayiCiftleriniAl()
        {
            Console.WriteLine("L�tfen say�lar� bo�luklarla girin (�rn: 2 3 1 5 2 5 3 3):");
            string input = Console.ReadLine();

            var parcalar = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var ciftler = new List<(int, int)>();
            for (int i = 0; i < parcalar.Length - 1; i += 2)
            {
                if (int.TryParse(parcalar[i], out int a) && int.TryParse(parcalar[i + 1], out int b))
                {
                    ciftler.Add((a, b));
                }
                else
                {
                    Console.WriteLine("Ge�ersiz giri� alg�land�, l�tfen sadece say�lar� bo�lukla ay�rarak girin.");
                    break;
                }
            }

            return ciftler;
        }
    }
    public class Islemci
    {
        public List<int> Isle(List<(int, int)> ciftler)
        {
            var sonuc = new List<int>();

            foreach (var (a, b) in ciftler)
            {
                if (a == b)
                    sonuc.Add((a + b) * (a + b)); // toplam�n karesi
                else
                    sonuc.Add(a + b);             // toplam
            }

            return sonuc;
        }
    }
}
