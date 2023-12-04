# Hava-Durumu-Program-
Hava Durumu Projesi, C# dilinde yazılmış bir konsol uygulamasıdır.

Program, kullanıcıyı hoş geldiniz mesajıyla karşılar ve ardından hava durumu bilgilerini görmek istediği şehri girmesini ister. Girilen şehir adı geçerli bir şehir olup olmadığı kontrol edilir.Eğer geçerli bir şehir değil ise uyarı verir. Eğer geçerli bir şehir ise, program HttpClient kullanarak belirli bir hava durumu API'sine HTTP GET isteği gönderir. API'den gelen yanıt, Newtonsoft.Json kütüphanesi kullanılarak C# nesnelerine dönüştürülerek elde edilen hava durumu verileri konsol ekranına yazdırılır. Ardından kullanıcıya diğer şehirlere bakmak isteyip istemediği sorulur. Eğer kullanıcı "e" tuşuna basarsa, döngü tekrar başa döner ve bir sonraki şehir girişi için kullanıcıdan bilgi alınır. Aksi takdirde, program kapatılır. 

Sonuç olarak uygulama gerekli kütüphaneleri kullanarak belirli şehirlerin 4 günlük hava tahminini alır ve istenileni konsola yazdırır.

# Kullanılan Kütüphaneler
-HttpClient: HTTP istekleri göndermek ve yanıtları almak için kullanılır.

-Newtonsoft.Json: JSON verilerini C# nesnelerine dönüştürmek için kullanılır.
