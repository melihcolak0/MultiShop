# 🛒 MultiShop E‑Commerce Microservice Projesi

Bu repository, Murat Yücedağ'ın Udemy'de bulunan Asp.Net Core MultiShop Mikroservis E-Ticaret Kursu'nu içermektedir. Bu eğitimde bana yol gösteren Murat Yücedağ'a çok teşekkür ederim.

ASP.NET Core 6.0 ve Web API teknolojilerini kullanarak MultiShop E‑Commerce Microservice Projesi'ni geliştirdim. Bu proje, ana sayfa (default), admin ve kullanıcı (user) paneli içeren tam kapsamlı bir e-ticaret ve yönetim sistemidir.

Bu proje, **Udemy üzerinden eşzamanlı takip edilen kapsamlı bir eğitim** doğrultusunda geliştirilmiş, **gerçek hayata yakın**, **kurumsal seviyede** bir **e‑ticaret mikroservis mimarisi** örneğidir. Amaç; sadece çalışan bir uygulama geliştirmek değil, aynı zamanda **ölçeklenebilir**, **bakımı kolay**, **güvenli** ve **modern backend mimarilerini** uçtan uca deneyimlemektir Eksikler muhakkak vardır, burada amacım birçok teknoloji ile ileri seviye bir proje çıkarmaktır.

Projem modern bir e-ticaret platformu olarak microservice mimarisi üzerine kuruludur.

## 🔥 Teknoloji Yığını

| Kategori          | Teknolojiler                                        | Kullanım Amacı                                                            |
| ----------------- | --------------------------------------------------- | ------------------------------------------------------------------------- |
| Backend Framework | .NET Core / .NET 6+                                 | Tüm mikroservislerin temeli, API'ler ve business logic                    |
| Veritabanları     | MongoDB, MSSQL, PostgreSQL, Redis                   | NoSQL (ürün katalogu), relational (siparişler), cache (sepet), mesajlaşma |
| ORM & Mapping     | Entity Framework Core, AutoMapper                   | Veritabanı işlemleri, DTO-entity dönüşümleri                              |
| API Gateway       | Ocelot                                              | Mikroservisleri tek giriş noktasında birleştirme                          |
| Authentication    | IdentityServer4/Duende IdentityServer, JWT          | Kullanıcı kimlik doğrulama ve yetkilendirme                               |
| Containerization  | Docker, Portainer                                   | Mikroservisleri container'larda çalıştırma ve yönetme                     |
| CQRS & Mediator   | MediatR                                             | Komut-sorgu ayrımı, order mikroservisi için                               |
| Mesajlaşma        | RabbitMQ, SignalR                                   | Asenkron iletişim, real-time bildirimler                                  |
| Frontend          | ASP.NET Core MVC, Razor Views, View Components      | UI katmanı, partial view'lar (header, carousel vb.)                       |
| Diğer             | Google Cloud Storage, RapidAPI, Localization (RESX) | Dosya depolama, harici API entegrasyonu, çok dilli destek                 |

<br><br>

## 🎯 Teknoloji Detayları
- 🔥 Backend Framework<br>
  ⚡ .NET Core / .NET 8+        (.csproj, Minimal APIs, Controllers)

- 🗄️ Veritabanları (Polyglot Persistence)<br>
  🟢 MongoDB                   (Catalog: Products/Categories/Images)<br>
  🟦 MSSQL Linux Container     (Order/Discount/Cargo/Comment)<br>
  🟣 PostgreSQL + PgAdmin      (Message microservice)<br>
  🔴 Redis Container           (Basket: Shopping cart cache)<br>

- ⚙️ Data Access & Mapping<br>
  📦 EntityFramework Core      (Code-first migrations)<br>
  🔄 AutoMapper                (Profile-based DTO mapping)<br>
  🗂️ Generic Repository        (Cargo servisi)<br>

- 🏗️ Architecture & Patterns<br>
  🧅 Onion Architecture        (Order: Domain/Application/Infrastructure)<br>
  ⚡ MediatR + CQRS             (Command/Query handlers)<br>
  🧩 Mediator Pattern          (Behavior pipeline)<br>

- 🌐 API Gateway & Auth<br>
  🚪 Ocelot Gateway            (JSON routing, Service Discovery)<br>
  🛡️ IdentityServer4           (OIDC/OAuth2, Duende package)<br>
  🔑 JSON Web Tokens (JWT)     (Bearer auth headers)<br>
  👤 Client Credentials Flow   (Service-to-service)<br>
  🔐 Resource Owner Password   (User login flow)<br>

- 🐳 DevOps & Containerization<br>
  🐳 Docker Compose            (Multi-container: DB + Services)<br>
  📊 Portainer CE              (Web UI container manager)<br>
  📦 Docker Volumes            (Data persistence)<br>
  🐛 DBeaver                   (DB visualization)<br>

- 📨 Communication & Real-time<br>
  🐰 RabbitMQ + Erlang         (Producer/Consumer, Direct Exchange)<br>
  ⚡ SignalR Hubs              (Admin notifications, Comment counts)<br>
  📧 SMTP Mail (Gmail)         (Contact form, Order confirmation)<br>

- 🎨 Frontend & UI/UX<br>
  🌐 ASP.NET Core MVC Areas    (Admin/User/Public layouts)<br>
  ✂️ Razor View Components     (Header, Carousel, ProductCard)<br>
  🎭 Partial Views             (ShoppingCart, ProductSlider)<br>
  🌈 Font Awesome Icons        (UI enhancements)<br>
  🎠 Bootstrap + Custom CSS    (Responsive design)<br>

- ☁️ Cloud & 3rd Party Integrations<br>
  📤 Google Cloud Storage      (Product images, JSON service account)<br>
  🌩️ RapidAPI                 (Weather, USD/EUR rates, E-commerce APIs)<br>
  🌍 RESX Localization         (Turkish/English support)<br>
  📊 Swagger + Postman         (API documentation/testing)<br>

- 🔒 Security & Best Practices<br>
  🛡️ CORS Policies             (SignalR cross-origin)<br>
  🍪 Cookie Configuration      (Secure session handling)<br>
  🔒 Authorize Attributes      ([Authorize(Policy="Manager")])<br>

---

## 🚀 Projenin Temel Yaklaşımı: Microservice Mimarisi

### 📌 Microservice Nedir?

**Microservice mimarisi**, bir uygulamanın tek parça (monolith) yerine; **birbirinden bağımsız**, **kendi veritabanına sahip**, **ayrı ayrı deploy edilebilen** küçük servisler halinde geliştirilmesini esas alır.

Bu projede her iş alanı (catalog, order, basket, identity vb.) **ayrı bir mikroservis** olarak ele alınmıştır.

### 🎯 Neden Microservice Kullandım?

- 🔹 Servislerin **bağımsız geliştirilmesi**
- 🔹 Farklı veritabanlarının aynı projede kullanılabilmesi
- 🔹 Yüksek **ölçeklenebilirlik**
- 🔹 Daha kolay **bakım ve test edilebilirlik**
- 🔹 Gerçek dünya projelerine birebir uyum

---

## 🧩 Projede Oluşturulan Mikroservisler

Aşağıdaki tabloda projede yer alan tüm mikroservisler ve temel sorumlulukları özetlenmiştir:

| Mikroservis | Açıklama | Kullanılan Teknolojiler |
|------------|---------|-------------------------|
| **Catalog** | Ürün, kategori, slider, brand, feature yönetimi | ASP.NET Core, MongoDB |
| **Discount** | Kupon & indirim işlemleri | ASP.NET Core, MSSQL |
| **Order** | Sipariş ve adres yönetimi | ASP.NET Core, MSSQL, CQRS |
| **Basket** | Kullanıcı sepet işlemleri | ASP.NET Core, Redis |
| **Cargo** | Kargo & gönderim süreçleri | ASP.NET Core, MSSQL |
| **Comment** | Ürün yorumları & puanlama | ASP.NET Core, MSSQL |
| **Message** | Kullanıcı mesajlaşma sistemi | ASP.NET Core, PostgreSQL |
| **Identity** | Kimlik doğrulama & yetkilendirme | IdentityServer, JWT |
| **Gateway** | Merkezi API yönlendirme | Ocelot |

---

## 🔍 Mikroservislere Genel Bakış

Aşağıda her mikroservis için **ne işe yaradığı** ve **neden ayrı bir servis olarak tasarlandığı** açıklanmıştır.

---

### 📦 Catalog Mikroservisi

**Ne İşe Yarar?**  
Ürünlerle ilgili tüm operasyonlardan sorumludur.

**Kapsamı:**
- Ürünler
- Kategoriler
- Ürün görselleri
- Ürün detayları
- Slider, feature, special offer, brand, about alanları

**Neden Ayrı?**
- Okuma ağırlıklı (read‑heavy)
- MongoDB ile esnek doküman yapısı
- UI tarafının en sık çağırdığı servis

**Kullanılan Teknolojiler:**
- MongoDB
- AutoMapper
- RESTful API

---

### 💸 Discount Mikroservisi

**Ne İşe Yarar?**  
Kupon bazlı indirimleri yönetir.

**Öne Çıkan Özellikler:**
- Kupon tanımlama
- Oransal indirim hesaplama
- Sepet ile entegre çalışma

**Veritabanı:** MSSQL  
**Neden?** Transactional veri ve migration ihtiyacı

---

### 🧾 Order Mikroservisi

**Ne İşe Yarar?**  
Sipariş ve adres işlemlerini yönetir.

**Mimari Özellikler:**
- **Onion Architecture**
- **CQRS (Command Query Responsibility Segregation)**
- **MediatR**

**Avantajı:**
- Okuma & yazma ayrımı
- Daha temiz domain modeli
- Test edilebilirlik

---

### 🛒 Basket Mikroservisi

**Ne İşe Yarar?**  
Kullanıcı sepetini yönetir.

**Neden Redis?**
- In‑memory cache
- Çok hızlı erişim
- Oturum bazlı veri saklama

**Özellikler:**
- Kullanıcıya özel sepet
- Ürün ekleme / çıkarma
- İndirim entegrasyonu

---

### 🚚 Cargo Mikroservisi

**Ne İşe Yarar?**  
Kargo şirketleri, gönderiler ve operasyonları yönetir.

**Öne Çıkan Yapılar:**
- Generic Repository
- Katmanlı mimari (DAL, Business)
- MSSQL

---

### 💬 Comment Mikroservisi

**Ne İşe Yarar?**  
Ürün yorumları ve puanlama sistemi.

**Ekstra:**
- Yorum istatistikleri
- SignalR entegrasyonu

---

### ✉️ Message Mikroservisi

**Ne İşe Yarar?**  
Kullanıcılar arası mesajlaşma.

**Neden PostgreSQL?**
- Farklı RDBMS deneyimi
- Text tabanlı veri yapısı

---

## 🔐 Identity Server & Authentication

### Identity Server Nedir?

**IdentityServer**, OAuth 2.0 ve OpenID Connect standartlarını kullanan bir **kimlik doğrulama sunucusudur**.

Bu projede:
- 🔑 JWT Token üretimi
- 👤 Kullanıcı yönetimi
- 🔒 Mikroservislerin güvenliği

sağlanmıştır.

### Kullanılan Akışlar

| Flow | Kullanım Amacı |
|----|---------------|
| **Resource Owner Password** | Kullanıcı login işlemleri |
| **Client Credentials** | Servis‑to‑servis iletişim |

---

## 🌐 Ocelot API Gateway

**Ocelot**, mikroservisler için merkezi bir giriş noktasıdır.

### Ne Sağladı?
- Tek URL üzerinden erişim
- Token doğrulama
- Yetkilendirme
- Route yönetimi

**Örnek:**
```
/api/catalog → Catalog Service
/api/order → Order Service
```

---

## 🐳 Docker & Portainer

### Docker

Tüm mikroservisler **container** olarak çalıştırılmıştır.

**Avantajlar:**
- Ortam bağımsız çalışma
- Kolay deploy
- Servis izolasyonu

### Portainer

Docker container’larını **web arayüzü** üzerinden yönetmek için kullanıldı.

---

## 🔑 JWT (JSON Web Token)

- Stateless authentication
- IdentityServer üzerinden üretildi
- UI ve mikroservislerde kullanıldı

---

## 🔄 Token Handler Yapıları

### Resource Owner Password Handler
- Kullanıcı adı & şifre ile token alma

### Client Credential Handler
- UI → API
- API → API iletişimi

---

## 📡 SignalR

**Gerçek zamanlı bildirimler** için kullanıldı.

- Yorum sayısı
- Mesaj sayısı
- Dashboard istatistikleri

---

## 🌍 Rapid API Entegrasyonu

Dış servis entegrasyonu amacıyla kullanıldı.

**Kullanım Alanları:**
- Döviz kurları (USD / EUR)
- Hava durumu
- ChatBot

---

## ✅ Sonuç

Bu proje;
- Mikroservis mimarisi
- Güvenlik
- Dağıtık sistemler
- Modern backend yaklaşımları

konularında **uçtan uca** bir referans çalışmadır.

📌 *Gerçek dünya projelerinde karşılaşılabilecek hemen her backend senaryosu bu projede deneyimlenmiştir. Projede eksikler olabilir. Çünkü bu bir eğitim projesidir.*

<br> <br>

### 🖼️ Projeden Ekran Görüntüleri
## ➡️ Ana Sayfa
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/mainpanelss/screencapture-localhost-7156-Default-Index-2026-01-11-21_43_15.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/mainpanelss/screencapture-localhost-7156-Products-2026-01-11-21_44_28.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/mainpanelss/screencapture-localhost-7156-Products-ProductDetail-6962d4b9064e5ae00ae4dbe4-2026-01-11-21_50_04.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/mainpanelss/screencapture-localhost-7156-Products-ProductDetail-6962d4b9064e5ae00ae4dbe4-2026-01-11-21_56_10.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/mainpanelss/screencapture-localhost-7156-ShoppingCart-2026-01-11-21_46_57.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/mainpanelss/screencapture-localhost-7156-Order-Index-2026-01-11-21_47_14.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/mainpanelss/screencapture-localhost-7156-Payment-2026-01-11-21_48_12.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/mainpanelss/screencapture-localhost-7156-Contact-Index-2026-01-11-21_44_42.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/mainpanelss/screencapture-localhost-7156-Register-Index-2026-01-11-21_57_42.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/mainpanelss/screencapture-localhost-7156-LogIn-Index-2026-01-11-21_57_27.png" alt="image alt">
</div>

---

## ➡️ Admin Paneli
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-Dashboard-Index-2026-01-11-21_59_36.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-About-Index-2026-01-11-22_00_27.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-About-CreateAbout-2026-01-11-22_00_35.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-About-UpdateAbout-6925cf348c55eaf48782772b-2026-01-11-22_00_47.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-Category-Index-2026-01-11-22_01_01.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202026-01-11%20222547.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202026-01-11%20220153.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202026-01-11%20220221.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-Slider-Index-2026-01-11-22_03_06.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-SpecialOffer-Index-2026-01-11-22_03_15.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-Feature-Index-2026-01-11-22_03_23.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-UserComment-Index-2026-01-11-22_03_51.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-User-Index-2026-01-11-22_04_02.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-User-GetUserCargoDetails-2026-01-11-22_07_27.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-Order-Index-2026-01-11-22_04_13.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-Order-OrderDetails-4002-2026-01-11-22_07_53.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-Statistic-Index-2026-01-11-22_04_33.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-CargoCompany-Index-2026-01-11-22_04_51.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-CargoCustomer-Index-2026-01-11-22_05_01.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-CargoDetail-Index-2026-01-11-22_05_18.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-CargoOperation-Index-2026-01-11-22_05_38.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-Discount-Index-2026-01-11-22_05_50.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-Message-Index-2026-01-11-22_06_02.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/adminpanelss/screencapture-localhost-7156-Admin-Contact-Index-2026-01-11-22_06_40.png" alt="image alt">
</div>

---

## ➡️ Kullanıcı Paneli
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/userpanelss/screencapture-localhost-7156-User-Profile-Index-2026-01-11-22_08_34.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/userpanelss/screencapture-localhost-7156-User-Order-Index-2026-01-11-22_08_44.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/userpanelss/screencapture-localhost-7156-User-Message-Inbox-2026-01-11-22_09_03.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/MultiShop/blob/c8a1bf667388491607661fced7514db366b6327e/ss/userpanelss/screencapture-localhost-7156-User-Message-Sendbox-2026-01-11-22_09_19.png" alt="image alt">
</div>
