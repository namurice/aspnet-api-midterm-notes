using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using midterm.Models;
using midterm;
using midterm.Models;

namespace midterm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ApplcationDBContext _context;

        public PostsController(ApplcationDBContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts(int pageNumber, int pageSize, string sortKey = "id", bool isAssending = true, string searchKey = null)
        {
            var orderBy = string.IsNullOrWhiteSpace(sortKey) ? "id" : sortKey.ToLower();

            var query = _context.Posts.AsQueryable();

            // Apply search filtering if searchKey is not null or empty
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                query = query.Where(c => c.Title.Contains(searchKey) || c.Content.Contains(searchKey));
            }

            // Dynamic sorting based on the orderBy value
            switch (orderBy)
            {
                case "createdat":
                    query = isAssending ?
                        query.OrderBy(c => c.CreateAt) :
                        query.OrderByDescending(c => c.CreateAt);
                    break;
                case "positivity":
                    query = isAssending ?
                        query.OrderBy(c => c.Upvotes) :
                        query.OrderByDescending(c => c.Upvotes);
                    break;
                case "id":
                default:
                    query = isAssending ?
                        query.OrderBy(c => c.Id) :
                        query.OrderByDescending(c => c.Id);
                    break;
            }
            // Pagination
            var pagedPosts = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return pagedPosts;
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post createPost)
        {
            if (createPost == null)
            {
                return BadRequest("Post data is required.");
            }

            var post = new Post() { Title = createPost.Title, Content = createPost.Content };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }


        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}