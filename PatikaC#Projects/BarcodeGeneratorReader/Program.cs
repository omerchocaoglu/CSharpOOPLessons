using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using static System.Net.Mime.MediaTypeNames;

namespace BarcodeGeneratorReader
{
    class Program
    {
        static void Main()
        {
            var barcodeHelper = new BarcodeHelper();

            Console.Write("Barcode için metin girin: ");
            string metin = Console.ReadLine();

            string dosyaYolu = Environment.CurrentDirectory + @"\barcode.png";

            // Barkod oluþtur ve kaydet
            barcodeHelper.GenerateBarcode(metin, dosyaYolu);
            Console.WriteLine($"Barcode '{dosyaYolu}' konumuna kaydedildi.");

            // Barkodu oku ve göster
            string okunanMetin = barcodeHelper.ReadBarcode(dosyaYolu);
            Console.WriteLine($"Okunan barcode metni: {okunanMetin}");
        }
    }
    public class BarcodeHelper
    {
        // Barkod oluþtur ve dosyaya kaydet
        public void GenerateBarcode(string text, string filePath)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 300,
                    Height = 100,
                    Margin = 10
                }
            };

            using (Bitmap bitmap = writer.Write(text))
            {
                bitmap.Save(filePath, ImageFormat.Png);
            }
        }

        // Barkodu dosyadan oku
        public string ReadBarcode(string filePath)
        {
            var reader = new BarcodeReader();

            using (Bitmap bitmap = (Bitmap)System.Drawing.Image.FromFile(filePath))
            {
                var result = reader.Decode(bitmap);
                return result?.Text ?? "Barkod okunamadý.";
            }
        }
    }
}
