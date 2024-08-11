﻿using LibraryManagementApi.Data;
using LibraryManagementApi.DTOs;
using LibraryManagementApi.Models;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;

namespace LibraryManagementApi.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetBooks()
        {
            var books = db.Books.Include(b => b.Author).Select(b => new BookDTO
            {
                BookID = b.BookID,
                Title = b.Title,
                PublishedYear= b.PublishedYear,
                AuthorName = b.Author.Name
            }).ToList();

            if (!books.Any())
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetBookById")]
        public IHttpActionResult GetBook(int id)
        {
            var book = db.Books.Include("Author").FirstOrDefault(b => b.BookID == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult PostBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Books.Add(book);
            db.SaveChanges();
            return CreatedAtRoute("GetBookById", new { id = book.BookID }, book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}