namespace ppedv.BooksManager.Model
{
    public class Book : Entity
    {
  
        public string Title { get; set; } = string.Empty;
        public string SubTitle { get; set; } = string.Empty;
        public DateTime Published { get; set; }
        public int PageCount { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public virtual ICollection<Author> Authors { get; set; } = new HashSet<Author>();
        public virtual Publisher? Publisher { get; set; }
    }

}