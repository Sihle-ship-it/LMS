using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementApi.DTOs
{
    public class BookDTO
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public int PublishedYear { get; set; }
        public string AuthorName { get; set; } // Includes only the fields that are necessary
    }
}