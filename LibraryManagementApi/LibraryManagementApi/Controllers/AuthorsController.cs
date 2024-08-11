using LibraryManagementApi.Data;
using LibraryManagementApi.Models;
using System.Linq;
using System.Web.Http;

namespace LibraryManagementApi.Controllers
{
    [RoutePrefix("api/authors")]
    public class AuthorsController : ApiController
    {
        private LibraryContext db = new LibraryContext();
        
        // GET: api/authors
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAuthors()
        {
            var authors = db.Authors.ToList();
            if (!authors.Any())
            {
                return NotFound();
            }
            return Ok(authors); 
        }

        // GET: api/authors/5
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetAuthor(int id)
        {
            var author = db.Authors.FirstOrDefault(a => a.AuthorID == id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        // POST: api/authors
        [HttpPost]
        [Route("")]
        public IHttpActionResult PostAuthor([FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Authors.Add(author);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = author.AuthorID }, author);
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