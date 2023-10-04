### Next Level Bootcamp Final Work

Proje bir quiz uygulamasını içermektedir. Kullanıcıların üye olması, giriş yapması, sisteme soru eklemesi, sorulardan seçerek kendilerine ait quizler oluşturması gibi özellikleri içermektedir.

#### Kurulum
- Projeyi indirmek:
```Git I'm A tab
git clone https://github.com/omerbilalusta/NextLevel-Bootcamp.git
```

- Veritabanını kurduktan sonra tabloları eklemek:
```Package Manager Console I'm A tab
update-database
```
- Projeyi çalıştırmak:
```Console I'm A tab
dotnet run
```

#### Packages:
- AutoMapper: 12.0.1
- AutoMapper.Extensions.Microsoft.DependencyInjection: 12.0.1
- Microsoft.EntityFrameworkCore.SqlServer: 7.0.11
- Microsoft.EntityFrameworkCore.Tools: 7.0.11
- Microsoft.EntityFrameworkCore.Relational: 7.0.11
- Microsoft.AspNetCore.Authentication.JwtBearer: 7.0.11


#### Dosya yapısı
- Application => Controller tarafında kullanılan Command ve Query'leri içerir.
- Common => AutoMapper için gerekli olan MappingProfile.cs dosyasını içerir.
- Contollers => Gelecek istekleri karşılayacak olan sınıfları içerir.
- Models => Veri tabanı konfigürasyonu, Entity'ler ve DTO'ları içerir.
- Views => Cilent'a gösterilecek olan sistem arayüzü dosyalarını içerir.

![](https://github.com/omerbilalusta/NextLevel-Bootcamp/blob/main/images/FolderStructure.png?raw=true)


#### Projeye ait veri tabanı şeması
![](https://github.com/omerbilalusta/NextLevel-Bootcamp/blob/main/images/DatabaseStructure.png?raw=true)



#### Proje ilgili notlar
Proje eksiklikler mevcut.
JWT implementasyonunu %100 başarıyla yapamadım. Kullanıcılar sisteme üye olabiliyor ve ardından bu bilgileri ile giriş yapabiliyor ve akabinde mail adreslerine özel token'ı oluşturabiliyorum. Ancak bu token'ı sistemde gezindiği sırada her isteğine Header'ına ekleyerek rol bazlı Authorization yapmam gerekirde ancak bunu başaramadım. Dolayısıyla kullanıcılar sisteme üye olsalarda varsayılan kullanıcının üzerinden sisteme quiz ekleyebiliyorlar, kendi oluşturdukları bilgiler kaydolup giriş yapsalarda o bilgileri kullanamıyorlar.

İlk olarak sisteme kayıt olun ve ardından ilgili testleri yapınız.