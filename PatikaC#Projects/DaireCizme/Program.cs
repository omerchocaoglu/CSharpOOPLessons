using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaireCizme
{
    class Program
    {
        static void Main()
        {
            var girdi = new KullanicidanGirdiAl();
            int yaricap = girdi.YaricapAl();

            var daire = new DaireCizici();
            daire.Ciz(yaricap);
        }
    }
    public class KullanicidanGirdiAl
    {
        public int YaricapAl()
        {
            Console.Write("Dairenin yarýçapýný giriniz: ");
            if (int.TryParse(Console.ReadLine(), out int yaricap) && yaricap > 0)
            {
                return yaricap;
            }

            Console.WriteLine("Geçersiz giriþ! Varsayýlan yarýçap: 5");
            return 5;
        }
    }
    public class DaireCizici
    {
        public void Ciz(int r)
        {
            double aspectRatio = 2.0; // konsol karakter oraný düzeltmesi

            for (double y = r; y >= -r; y--)
            {
                for (double x = -r; x <= r; x++)
                {
                    double dx = x / aspectRatio;
                    if (dx * dx + y * y <= r * r)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
