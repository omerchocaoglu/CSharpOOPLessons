using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcgenCizme
{
    class Program
    {
        static void Main()
        {
            var girdi = new KullanicidanGirdiAl();
            int boyut = girdi.BoyutAl();

            var ucgen = new UcgenCizici();
            ucgen.Ciz(boyut);
        }
    }
    public class KullanicidanGirdiAl
    {
        public int BoyutAl()
        {
            Console.Write("Üçgenin boyutunu giriniz: ");
            if (int.TryParse(Console.ReadLine(), out int boyut) && boyut > 0)
            {
                return boyut;
            }

            Console.WriteLine("Geçersiz giriþ! Varsayýlan boyut: 5");
            return 5;
        }
    }
    public class UcgenCizici
    {
        public void Ciz(int boyut)
        {
            for (int i = 1; i <= boyut; i++)
            {
                string satir = new string(' ', boyut - i) + new string('*', 2 * i - 1);
                Console.WriteLine(satir);
            }
        }
    }
}
