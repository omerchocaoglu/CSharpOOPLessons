using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaC_Projects
{
    class Program
    {
        static void Main()
        {
            Console.Write("Fibonacci serisi için derinlik giriniz: ");
            if (int.TryParse(Console.ReadLine(), out int derinlik) && derinlik > 0)
            {
                var fibonacci = new FibonacciGenerator();
                List<int> seri = fibonacci.Uret(derinlik);

                var hesaplayici = new OrtalamaHesaplayici();
                double ortalama = hesaplayici.Hesapla(seri);

                Console.WriteLine($"Fibonacci Serisi: {string.Join(", ", seri)}");
                Console.WriteLine($"Ortalama: {ortalama:F2}");
            }
            else
            {
                Console.WriteLine("Lütfen pozitif bir sayý giriniz.");
            }
        }
    }
    public class FibonacciGenerator
    {
        public List<int> Uret(int adet)
        {
            var liste = new List<int> { 0, 1 };

            while (liste.Count < adet)
            {
                int sonraki = liste[liste.Count - 1] + liste[liste.Count - 2];
                liste.Add(sonraki);
            }

            return liste.GetRange(0, adet);
        }
    }
    public class OrtalamaHesaplayici
    {
        public double Hesapla(List<int> sayilar)
        {
            if (sayilar == null || sayilar.Count == 0) return 0;
            return sayilar.Average();
        }
    }
}
