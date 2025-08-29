Öğrenci ve Sekreter Yönetim Sistemi
Bu proje, bir üniversite ortamı için C# üzerinde geliştirilmiş, rol temelli bir yönetim sistemidir. İki farklı kullanıcı rolüne sahiptir: kişisel bilgiye sınırlı erişim olan öğrenci ve öğrenci verileri ile bölümler üzerinde tam idari kontrole sahip sekreter. Uygulama, güvenli giriş, veri kalıcılığı ve farklı erişim durumları tek bir sistem sergiler.

Ana Özellikler
Güvenli Kullanıcı Kimlik Doğrulaması:

Öğrenci Girişi: öğrenciler, benzersiz öğrenci numarası ve şifrelerini kullanarak giriş yapabilirler. Kimlik bilgileri bir veri tabanına karşı doğrulanır.
    ÖRNEK/ Numara : 22334 Şifre : a
    
Sekreter Girişi: Sekreter, önceden belirlenmiş kullanıcı adı ( 00000) ve şifre ( 000) ile yönetici paneline erişebilir.

Öğrenci Portalı:

Öğrencilerin kendi kişisel bilgilerini (örn. öğrenci numarası, şifre) görüntüleyebilir ve güncelleyebilir.

Erişim sadece kişisel verilerle mümkündür.

Sekreter Yönetim Paneli:

Sekreter, öğrenci ve bölümlerin düzeni için kapsamlı yetkilere sahiptir.

Öğrenci Veri Yönetimi: Yeni öğrenci ekleme, mevcut kayıtları güncelleme, öğrenci hesaplarını silme ve tüm bunların günlüğünü görüntüleme gibi tam CRUD (Oluşturma, Okuma, Güncelleme, Silme) kapasitesi.

Bölüm Yönetimi: Bölümlerin eklenmesi, güncellenmesi, silinmesi ve listeleme yeteneği.

Kullanılan Teknolojiler
Dil: C#

Çerçeve: .NET 

Veritabanı: SQL Server (veya SQLite)

ORM (Nesne-İlişkisel Eşleme): Varlık Çerçevesi Çekirdeği

Geliştirme Ortamı: Visual Studio

Kurulum ve Kullanım
Projeyi kendi başınıza çalıştırmak için Visual Studio'ya ihtiyacınız olacaktır.

Depoyu Klonla:

Bash

git clone https://github.com/your-username/student-secretary-system.git
Projeyi Aç:

Visual Studio'yu başlatıp karşılamanız durumunda "Bir proje veya çözüm aç" (Bir proje veya çözüm aç) seçeneğini seçin.

Klonladığınız proje parçalarına bölünme ve .slnparçalı çözüm sonuçlarını açın.

Paketleri Yükle:

Proje otomatik olarak gerekli NuGet paketlerini yükleyebilir. Eğer yüklenmezse, "Tools" > "NuGet Package Manager" > "Package Manager Console" yolunu izleyip nuget restoreçalıştırılır.

Uygulamayı Çalıştır:

Visual Studio'da "Çalıştır" butonu veya F5tuşlarıyla uygulamayı çalıştırın.
