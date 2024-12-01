# BestGuide
###### Bu proje, bir otel rehberi uygulamasını hayata geçirmek için mikroservis mimarisi kullanılarak geliştirilmiştir.
###### Aşağıda, projeyi nasıl çalıştıracağınız, kullanılan teknolojiler ve yapılandırma detaylarına ilişkin bilgiler yer almaktadır.

## Kullanılan Teknolojiler ve Sistem Gereksinimleri
- .NET 8
- PostgreSQL
- Entity Framework Core
- Swagger
- RabbitMQ
- Elasticsearch
- MSTest/Moq

Proje, mikroservis mimarisi kullanılarak tasarlanmıştır. Servisler birbirine esnek bağlıdır (Loose Coupling) ve Mesaj Kuyruğu (RabbitMQ) üzerinden iletişim kurar. Bu yaklaşım ile mikroservisler arası bağımlılığın en aza indirilmesi amaçlanmıştır. Projede veritabanı tabloları şema bazında ayrılmıştır. Aynı zamanda, sistem her bir mikroservis için bağımsız veritabanı kullanımına da uygundur. Projede CQRS ve Repository pattern'leri kullanılmıştır.

**- Modules Microservice**
- Otel ve iletişim bilgilerinin yönetimi konumlandırılmıştır.

**- Report Microservice**
- Rapor talebi ve listelenmesi yönetimi konumlandırılmıştır.

### Gereksinimler

Aşağıdaki komutları kullanarak PostgreSQL için gerekli tabloları oluşturabilirsiniz.

------------

Modules MS için {BestGuide.Modules.Infrastructure} konumunda:
```bash
{proje_dosya_yolu}\BestGuide\src\BestGuide.Modules.Infrastructure> dotnet ef database update --context ModulesDbContext --startup-project ../BestGuide.Modules
```

------------

Report MS için {BestGuide.Report.Infrastructure} konumunda:
```bash
{proje_dosya_yolu}\BestGuide\src\BestGuide.Report.Infrastructure> dotnet ef database update --context ReportDbContext --startup-project ../BestGuide.Report
```

*Not: Bu komutların çalışması için database.json içerisinde ConnectionStrings ayarlarını doğru yapılandırdığınızdan emin olun.*

------------

RabbitMQ bağlantı bilgileri *appsettings.json* içerisinde *RabbitMQOptions* altında bulunmaktadır.

------------

Elasticsearch bağlantı bilgileri *Configurations/Nlog.config* içerisinde bulunmaktadır.

------------

API Kullanımı: Swagger arayüzüne erişmek için, http://localhost:{port}/swagger adresine gidin.
