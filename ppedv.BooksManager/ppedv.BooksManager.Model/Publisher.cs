﻿namespace ppedv.BooksManager.Model
{
    public class Publisher : Entity
    {
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }

}