namespace LibraryManagementApi.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public int PublishedYear { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}