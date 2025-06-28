using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessizHarf
{
    class Program
    {
        static void Main()
        {
            var girdi = new GirdiIsleyici();
            string metin = girdi.MetinAl();

            var kontrol = new SessizKontrol();
            var sonuc = kontrol.ArdisikSessizVarMi(metin);

            Console.WriteLine(string.Join(" ", sonuc));
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
    public class SessizKontrol
    {
        private static readonly HashSet<char> SessizHarfler = new HashSet<char>
    {
        'b','c','ç','d','f','g','ð','h','j','k','l','m','n','p','r','s','þ','t','v','y','z',
        'B','C','Ç','D','F','G','Ð','H','J','K','L','M','N','P','R','S','Þ','T','V','Y','Z'
    };

        public List<bool> ArdisikSessizVarMi(string metin)
        {
            var kelimeler = metin.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var sonuc = new List<bool>();

            foreach (var kelime in kelimeler)
            {
                bool varMi = false;
                for (int i = 0; i < kelime.Length - 1; i++)
                {
                    if (SessizHarfler.Contains(kelime[i]) && SessizHarfler.Contains(kelime[i + 1]))
                    {
                        varMi = true;
                        break;
                    }
                }
                sonuc.Add(varMi);
            }

            return sonuc;
        }
    }
}
