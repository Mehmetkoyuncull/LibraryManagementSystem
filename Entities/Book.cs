namespace Entities
{
    public class Book
    {
        public int Id { get; set; }             // Otomatik artan ID
        public string Title { get; set; }       // Kitap Adı
        public string Author { get; set; }      // Yazar
        public string ISBN { get; set; }        // ISBN numarası
        public int PageCount { get; set; }      // Sayfa sayısı
        public int PublishYear { get; set; }    // Basım yılı
    }
}
