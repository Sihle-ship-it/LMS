using LibraryManagementApi.Data;
using LibraryManagementApi.Models;
using System.Linq;
using System.Web.Http;

namespace LibraryManagementApi.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetUsers()
        {
            var users = db.Users.ToList();
            if (!users.Any())
            {
                return NotFound();
            }
            return Ok(users);
        }

        // GET api/users/{id}
        [HttpGet]
        [Route("{id:int}", Name = "GetUserById")]
        public IHttpActionResult GetUser(int id)
        {
            var user = db.Users.FirstOrDefault(u => u.UserID == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

            [HttpPost]
        [Route("")]
        public IHttpActionResult PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Users.Add(user);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = user.UserID }, user);
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