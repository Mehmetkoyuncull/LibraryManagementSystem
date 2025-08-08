# 📚 Library Management System

Bu proje, **C# Windows Forms** kullanılarak geliştirilmiş bir **Kütüphane Yönetim Sistemi**dir.  
Katmanlı mimari kullanılmıştır (**Entities**, **DataAccess**, **Business**, **FormsUI**).  
Kitap, üye ve ödünç işlemleri kolayca yapılabilir.

---

## 🚀 Özellikler
- **Kitap İşlemleri**
  - Kitap ekleme, silme, güncelleme
  - ISBN kontrolü
  - Listeleme
- **Üye İşlemleri**
  - Üye ekleme, silme, güncelleme
  - TC Kimlik kontrolü
  - Listeleme
- **Ödünç İşlemleri**
  - Kitap ödünç verme
  - İade alma
  - Maksimum 15 gün ödünç süresi (sonrası her gün için 10 TL ceza)
  - Aynı kitabın aynı anda iki farklı kişiye verilmesi engellenir
- **JSON veri kaydı** (kalıcı depolama)
- **Kullanıcı dostu arayüz**

---

## 🛠 Kullanılan Teknolojiler
- **C# .NET Framework 4.8**
- **Windows Forms**
- **JSON** ile veri depolama
- **Katmanlı Mimari**
- **Kitap Üye CRUD**

---
📂 Proje Yapısı

| **Klasör / Dosya**    | **Açıklama**                                                |
| --------------------- | ----------------------------------------------------------- |
| **Entities/**         | Temel veri modelleri (POCO sınıfları)                       |
| ├─ `Book.cs`          | Kitap: ISBN, Başlık, Yazar, Sayfa, Yıl, Durum vb.           |
| ├─ `Member.cs`        | Üye: Ad-Soyad, TCKN, Telefon/E-posta vb.                    |
| └─ `Loan.cs`          | Ödünç: KitapId, ÜyeId, Veriliş/İade tarihleri, Ceza bilgisi |
| **DataAccess/**       | Veri erişim katmanı                                         |
| └─ `FileHelper.cs`    | JSON okuma/yazma; liste yükleme/kaydetme yardımcıları       |
| **Business/**         | İş kuralları ve uygulama mantığı                            |
| ├─ `BookManager.cs`   | Kitap ekleme, silme, güncelleme, listeleme mantığı          |
| ├─ `MemberManager.cs` | Üye ekleme, silme, güncelleme, listeleme mantığı            |
| └─ `LoanManager.cs`   | Ödünç verme, iade alma, gecikme/ceza hesaplama              |
| **FormsUI/**          | Windows Forms arayüz katmanı                                |
| ├─ `MainForm.cs`      | Ana menü: Kitap, Üye, Ödünç butonları                       |
| ├─ `BookForm.cs`      | Kitap işlemleri ekranı                                      |
| ├─ `MemberForm.cs`    | Üye işlemleri ekranı                                        |
| └─ `LoanForm.cs`      | Ödünç/iade işlemleri ekranı                                 |

**USER INTERFACES:**
## Ekran Görüntüleri :
<img width="783" height="566" alt="anamaneü" src="https://github.com/user-attachments/assets/c569baf1-e8c7-4e1d-92b1-e2fd0222fa31" />
<img width="803" height="543" alt="üye" src="https://github.com/user-attachments/assets/083ac467-d335-4bff-8ab1-fa5a8a9d23fc" />
<img width="1002" height="562" alt="ödünç" src="https://github.com/user-attachments/assets/88587233-cd1e-4d27-84e9-9f3e0d0213b9" />
<img width="767" height="620" alt="kitapişlemleri" src="https://github.com/user-attachments/assets/b56ffb1a-5e48-41dd-817b-70202df1e007" />



---

## ⚙️ How It Works

1. **🚀 Uygulamayı Başlatma**

   * `FormsUI` projesinden `MainForm` çalıştırılır.
   * **Ana Menü** açılır: **Books**, **Members**, **Loans** butonları.

2. **📖 Kitap İşlemleri (`BookForm`)**

   * Yeni kitap ekleme (**Title, Author, ISBN, Page Count, Publish Year**).
   * Kitap bilgilerini düzenleme veya silme.
   * Veriler `books.json` dosyasında saklanır.

3. **👤 Üye İşlemleri (`MemberForm`)**

   * Yeni üye kaydı (**Name, TCKN, İletişim bilgileri**).
   * Üye bilgilerini düzenleme veya silme.
   * Veriler `members.json` dosyasında saklanır.

4. **📦 Ödünç İşlemleri (`LoanForm`)**

   * Kitap ve üye seçilerek ödünç kaydı oluşturma.
   * İade sırasında gecikme kontrolü ve **otomatik ceza hesaplama**.
   * Veriler `loans.json` dosyasında saklanır.

5. **💾 Veri Kalıcılığı**

   * **`DataAccess/FileHelper.cs`** JSON dosyalarına veri okuma/yazma işlemlerini yönetir.
   * Uygulama kapatıldığında tüm bilgiler korunur.

6. **🧠 İş Mantığı**

   * **Business katmanı** (`BookManager`, `MemberManager`, `LoanManager`):

     * Doğrulama (ör. ISBN tekrar etmesin)
     * CRUD işlemleri
     * Ödünç verme kuralları ve ceza hesaplama

7. **🖥️ Kullanıcı Arayüzü**

   * **Windows Forms** ile basit ve kullanıcı dostu ekranlar.
   * Tüm işlemler butonlar ve listeler üzerinden yapılır — kod bilmeye gerek yok.

---






