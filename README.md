## 🎵 Jwt ile Bepop Müzik Platformu

Bepop, modern backend prensipleriyle geliştirilmiş, güvenli ve ölçeklenebilir bir müzik uygulamasıdır.
Proje, kullanıcı yönetimi ve kimlik doğrulama süreçlerini JWT ve ASP.NET Core Identity ile ele alarak gerçek dünya senaryolarına uygun bir API mimarisi sunar. Ml.Net ile en popüler 5 şarkıya göre sıradaki şarkı kaç kere tıklanır ve 30 günlük süre içinde hangi günlerde günlük dinleme sayısına göre tahinleme yapılmış ve grafiklerle görselleştirilerek dashboarda listelenmiştir. Sistem, kullanıcıların sahip olduğu abonelik paketlerine (Free/Elite) 6 farklı paket ve bireysel dinleme geçmişine göre özelleşen akıllı bir öneri motoruna sahiptir. Bu motor, kullanıcı alışkanlıklarını analiz ederek "size özel" içerikler üretir ve etkileşimi maksimize eder.

## ⚡ Temel Özellikler
- JWT ile stateless authentication
- ASP.NET Core Identity ile kullanıcı & rol yönetimi
- Müzik, favori ve playlist yönetimi
- Role-based authorization (User)
- Ml.Net ile Veri Tahminleme 

## 🛠️ Tech Stack
- .NET 8 / ASP.NET Core Web API
- Entity Framework Core
- ASP.NET Core Identity
- JWT Bearer Authentication
- Ml.Net (Öneri Sistemi)
- SQL Server

## 🧠 Mimari Yaklaşım
Bepop, temiz ve genişletilebilir bir yapı hedeflenerek geliştirilmiştir:

- Repository Pattern
- Service Layer abstraction
- DTO ile veri izolasyonu
- Dependency Injection

Bu yaklaşım sayesinde proje:
Daha okunabilir
Daha test edilebilir
Daha kolay genişletilebilir hale getirilmiştir.

##  🔐 Authentication Flow
- Kullanıcı giriş yapar
- Identity doğrulama işlemini gerçekleştirir
- Başarılı giriş sonrası JWT token üretilir
- Tüm istekler bu token ile authorize edilir

Bu yapı sayesinde sistem: 
Stateless çalışır
Session bağımlılığı içermez
Yüksek performans ve ölçeklenebilirlik sağlar

##  💡 Öne Çıkan Noktalar
Modern authentication yaklaşımı (JWT + Identity)
Clean Code ve SOLID prensiplerine uygun yapı
Gerçek projelere uygun backend mimarisi
Genişletilebilir ve maintainable kod yapısı

##  🎯 Proje Vizyonu

Bepop, sadece bir müzik uygulaması değil;
aynı zamanda modern backend ve veri tahminleme standartlarını yansıtan bir referans projedir.

## 📸 Proje Görselleri
<img width="1600" height="1344" alt="Öneriler" src="https://github.com/user-attachments/assets/68db699f-0f66-4a43-ac53-c6395a637acf" />
<img width="1600" height="1813" alt="sanatçılar" src="https://github.com/user-attachments/assets/39ac9ed2-b086-43e8-85de-9192cc0c71ff" />
<img width="1600" height="1528" alt="Albümler" src="https://github.com/user-attachments/assets/9f7adf75-94bf-4b5c-8c9f-9814b3cc9664" />
<img width="1600" height="741" alt="Kayıt" src="https://github.com/user-attachments/assets/87c9d7eb-6ea5-4b3d-afba-a7bcf906d369" />
<img width="1600" height="731" alt="Giriş" src="https://github.com/user-attachments/assets/07c28af8-9fbf-479b-b50e-895c6be91e17" />

## 📸 Elite Paket Kullanıcı
<img width="1600" height="1436" alt="Dashboard" src="https://github.com/user-attachments/assets/8c26e96c-3e59-4b4a-962d-ba16f5763806" />
<img width="1600" height="2011" alt="Şarkılar" src="https://github.com/user-attachments/assets/d123e99d-0d1e-4706-bb97-d3ccc28a73c4" />

## 📸 Standart Paket Kullanıcı
<img width="1600" height="1436" alt="2 kullanıcı" src="https://github.com/user-attachments/assets/d5f54563-fbca-4e0d-8136-f3d81242583c" />
<img width="1600" height="1170" alt="2 Şarkılar" src="https://github.com/user-attachments/assets/be204087-9cad-41df-82eb-52d571cf61f4" />

<img width="1600" height="895" alt="UserŞarkıcılar" src="https://github.com/user-attachments/assets/06eadf0a-3b8e-4981-ab83-b8a291e5b2f9" />
<img width="1600" height="943" alt="UserAlbümler" src="https://github.com/user-attachments/assets/33f7f5c0-af31-49e5-8032-4c0736928358" />







