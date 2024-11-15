using System;
using System.Collections.Generic;
using System.Linq;

class Dizi
{
    public string DiziAdi { get; set; }
    public string DiziTuru { get; set; }
    public string Yonetmen { get; set; }
    public int Yil { get; set; }
}

class Program
{
    static void Main()
    {
        // Dizilerin saklanacağı liste
        List<Dizi> diziler = new List<Dizi>();
        bool devamEt = true;

        // Kullanıcıdan dizi bilgilerini alıyoruz
        while (devamEt)
        {
            // Yeni bir dizi oluşturmak için kullanıcıdan bilgiler alıyoruz
            Dizi yeniDizi = new Dizi();

            Console.Write("Dizi adı: ");
            yeniDizi.DiziAdi = Console.ReadLine();

            Console.Write("Dizi türü (örnek: Komedi, Dram, Aksiyon): ");
            yeniDizi.DiziTuru = Console.ReadLine();

            Console.Write("Yönetmen adı: ");
            yeniDizi.Yonetmen = Console.ReadLine();

            int yil;
            // Yıl bilgisini kullanıcıdan alırken doğru formatta olmasını sağlıyoruz
            Console.Write("Yıl: ");
            while (!int.TryParse(Console.ReadLine(), out yil))
            {
                Console.Write("Geçersiz yıl! Lütfen geçerli bir yıl girin: ");
            }
            yeniDizi.Yil = yil;  // Yıl başarılı şekilde alındıktan sonra atama yapıyoruz

            // Diziyi listeye ekliyoruz
            diziler.Add(yeniDizi);

            // Kullanıcıya başka bir dizi eklemek isteyip istemediğini soruyoruz
            Console.Write("Başka bir dizi eklemek ister misiniz? (Evet için 'e', Hayır için 'h' tuşlayınız): ");
            string cevap = Console.ReadLine().ToLower();
            if (cevap == "h")
            {
                devamEt = false;
            }
        }

        // Komedi dizilerini filtreleyelim
        List<Dizi> komediDizileri = diziler.Where(d => d.DiziTuru.ToLower() == "komedi").ToList();

        // Yeni listeyi sıralıyoruz: İlk önce dizi adı, sonra yönetmen ismi ile sıralama yapıyoruz
        var siraliKomediDizileri = komediDizileri.OrderBy(d => d.DiziAdi).ThenBy(d => d.Yonetmen).ToList();

        // Yeni listeyi yazdırıyoruz
        Console.WriteLine("\nKomedi Dizileri (Dizi Adı, Türü, Yönetmen):");
        foreach (var dizi in siraliKomediDizileri)
        {
            Console.WriteLine($"Dizi Adı: {dizi.DiziAdi}, Türü: {dizi.DiziTuru}, Yönetmen: {dizi.Yonetmen}");
        }

        // Programı sonlandırıyoruz
        Console.WriteLine("\nProgram sonlandırılıyor...");
    }
}
