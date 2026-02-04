IntertekTask
Kısa açıklama
IntertekTask, ASP.NET Core (.NET 9) kullanılarak hazırlanmış örnek bir web uygulamasıdır. Uygulama temel olarak müşteri verilerini veri tabanından çekip JSON olarak sunan bir API/uygulama katmanı içerir.

Gereksinimler
.NET 9 SDK
SQL Server (veya bağlantı dizesine göre ulaşılabilen bir SQL sunucusu)
Visual Studio / VS Code veya dotnet CLI
Kurulum ve çalıştırma
Repo'yu klonlayın:
git clone https://github.com/berkayozturkk/IntertekTask.git
appsettings.json içinde DefaultConnection değerini kendi veritabanı bağlantı string'inizle güncelleyin.
Projeyi restore ve build edin:
dotnet restore
dotnet build
Uygulamayı çalıştırın:
dotnet run --project src/IntertekTask.Web
(Visual Studio kullanıyorsanız solution'u açıp başlatabilirsiniz.)
Konfigürasyon
appsettings.json içerisindeki ConnectionStrings:DefaultConnection veritabanı bağlantısı için kullanılır.
Önemli uç noktalar
Ana sayfa: / (Home/Index view)
Tüm müşteriler (JSON): /Customer/GetAllCustomersAsync
En çok harcayan müşteriler: /Customer/GetTopSpendingCustomersAsync
Mimari ve klasör yapısı (özet)
IntertekTask.Web - UI / Controller / Views
IntertekTask.Business - Servisler ve iş kuralları
IntertekTask.Data - Repository ve DB yardımcıları
IntertekTask.Model - Paylaşılan modeller/DTO'lar
İyileştirme önerileri
Unit/integration test ekleyin (tests/ klasörü)
nullable referans tiplerini etkinleştirin ve kod analizörleri ekleyin
Db erişimi için Dapper veya EF Core gibi kütüphaneler değerlendirilebilir
Katkıda bulunma
Pull requestler kabul edilir. Küçük, amaç odaklı değişiklikler ve açıklayıcı commit mesajları tercih edilir.

Lisans
Bu repoda lisans bilgisi yoksa proje sahibiyle iletişime geçin veya repo ayarlarını kontrol edin.

İletişim
Projeyle ilgili sorular için repository sahibi ile GitHub üzerinden iletişime geçebilirsiniz.
