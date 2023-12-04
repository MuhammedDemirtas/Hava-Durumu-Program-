using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading.Tasks;
using Hava_Durumu_Projesi;
using Newtonsoft.Json;

class Program
{
    static async Task Main()
    {   //Hoş geldin yazısını yazdırır.
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("".PadLeft((Console.WindowWidth - 19) / 2) + "HAVA DURUMU PROGRAMINA HOŞ GELDİNİZ \n \n");
        Console.ResetColor();

        do
        {   // Kullanıcıdan şehir girişini iste
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("".PadLeft((Console.WindowWidth - 19) / 3) + "LÜTFEN HAVA DURUMUNU GÖRMEK İSTEDİĞİNİZ ŞEHRİ YAZINIZ (İSTANBUL - İZMİR - ANKARA) =");
            string IstenenSehir = Console.ReadLine().ToLower();
            Console.ResetColor();
            // Girilen şehir geçerli mi kontrol et
            if (SehirKontrol(IstenenSehir))
            {   // Kullanıcının girişi geçerliyse konsolu temizler, hava durumu bilgilerini gösterir ve kullanıcıya diğer şehirlere bakmak isteyip istemediğini sorar.
                Console.Clear();
                await GetWeather(IstenenSehir);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("".PadLeft((Console.WindowWidth - 19) / 4) + "DİĞER ŞEHİRLERE BAKMAK İSTER MİSİNİZ ? İsterseniz (e) Tuşuna İstemezseniz (Enter) Tuşuna Basınız.\n");
                if (Console.ReadLine().ToLower() != "e")
                {   // e tuşuna basılmazsa döngüden çık enter derse kapat
                    break;
                }
                Console.Clear();
            }
            else
            {   // Geçersiz şehir girilirse hata mesajını yazdır.
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("".PadLeft((Console.WindowWidth - 19) / 2) + "LÜTFEN GEÇERLİ BİR ŞEHİR GİRİN !");
            }
           
        } while (true);

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Program kapatılıyor.");
    }

    //İstenilen şehir adına göre http isteği yapar ve durumları alır
    static async Task GetWeather(string city)
    {   // HttpClient sınıfını kullanarak belirli bir şehir için hava durumu verilerini bir uzak sunucudan çekme işlemini gerçekleştirir.
        // HttpClient sınıfını Istemci parametresine dönüştürüyor.
        using (HttpClient Istemci = new HttpClient())
        {
            try
            {   //Belirli bir şehir için hava durumu bilgilerini almak için kullanılacak olan API'nin URL'si oluşturuluyor.
                string website = $"https://goweather.herokuapp.com/weather/{city}";//city kullanıcının girişinden geliyor.
                HttpResponseMessage response = await Istemci.GetAsync(website);
                //nucudan gelen yanıtın başarılı olup olmadığı kontrol edilir. Eğer başarılıysa bu olur.
                if (response.IsSuccessStatusCode)
                {   // Sunucudan gelen içeriği okur ve bir JSON string olarak json değişkenine atar.
                    //JSON stringini, Veriler sınıfına (ya da başka bir nesne türüne) dönüştürmek için JsonConvert sınıfının DeserializeObject metodu kullanılır.
                    //Bu, JSON verilerini C# nesnelerine çevirmek için Newtonsoft.Json kütüphanesinin sağladığı bir işlemdir.
                    string json = await response.Content.ReadAsStringAsync();
                    Veriler weatherData = JsonConvert.DeserializeObject<Veriler>(json);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("".PadLeft((Console.WindowWidth - 19) / 2) + $"HAVA DURUMU PROGRAMI \n \n \n \n \n");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("".PadLeft((Console.WindowWidth - 19) / 3) + $"{city.ToUpper()} HAVA DURUMU \n ");
                    Console.WriteLine("".PadLeft((Console.WindowWidth - 19) / 3) + $"Bugün = {weatherData.Temperature} - {weatherData.Description} - Rüzgar: {weatherData.Wind} \n");

                    Console.WriteLine("".PadLeft((Console.WindowWidth - 19) / 3) + "SONRAKİ 3 GÜNÜN TAHMİNLERİ DE BURADA BULUNUYOR = \n");
                    foreach (var forecast in weatherData.Forecast)
                    {
                        Console.WriteLine("".PadLeft((Console.WindowWidth - 19) / 3) + $"- {forecast.Day} Gün Sonra : {forecast.Temperature} - Rüzgar: {forecast.Wind} \n \n \n");
                    }

                    Console.WriteLine();
                }
                //Başarısızsa bu olur.
                else
                {   //HTTP uygun değilse uygun mesajları yazdırır.
                    //servisin kullanılamaz olduğunu belirtir.
                    if (response.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
                    {
                        Console.WriteLine("Servis şu anda kullanılamıyor. Lütfen daha sonra tekrar deneyin.");
                    }
                    else
                    {
                        Console.WriteLine($"Hava durumu bilgileri alınamadı. Hata Kodu: {response.StatusCode}, Hata Mesajı: {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
            }
        }
    }
    //Şehir Kontrol Fonksiyonu Verilen şehir adının geçerli olup olmadığını kontrol eder.
    static bool SehirKontrol(string city)
    {
        return city == "istanbul" || city == "ankara" || city == "izmir";
    }
}