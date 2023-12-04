# Hava-Durumu-Program-
Hava Durumu Projesi, C# dilinde yazılmış bir konsol uygulamasıdır. Program, kullanıcıyı hoş geldiniz mesajıyla karşılar ve ardından hava durumu bilgilerini görmek istediği şehri girmesini ister. Girilen şehir adı küçük harfe çevrilir ve geçerli bir şehir olup olmadığı kontrol edilir. Eğer geçerli bir şehir ise, program HttpClient kullanarak belirli bir hava durumu API'sine HTTP GET isteği gönderir. API'den gelen yanıt, Newtonsoft.Json kütüphanesi kullanılarak C# nesnelerine dönüştürülerek elde edilen hava durumu verileri renkli bir şekilde konsol ekranına yazdırılır. Kullanıcıya diğer şehirlere bakmak isteyip istemediği sorulur. Eğer kullanıcı "e" tuşuna basarsa, döngü tekrar başa döner ve bir sonraki şehir girişi alınır. Aksi takdirde, program kapatılır. Bu uygulama, kullanıcının belirli şehirlerin güncel hava durumu bilgilerini öğrenmesini sağlamak için basit bir araç sunar.

# Kullanılan Kütüphaneler-
-HttpClient: HTTP istekleri göndermek ve yanıtları almak için kullanılır.
-Newtonsoft.Json: JSON verilerini C# nesnelerine dönüştürmek için kullanılır.
