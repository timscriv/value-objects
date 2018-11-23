using BookValueObject.ValueObjects;

namespace BookValueObject.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }
        public int PageCount { get; set; }
    }

    public class BookV2
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }
        public PageCount PageCount { get; set; }
    }

    public class BookV3
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public PublishYear PublishYear { get; set; }
        public PageCount PageCount { get; set; }
    }
}
